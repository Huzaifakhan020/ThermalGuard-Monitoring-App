using LibreHardwareMonitor.Hardware;
using ManagedCuda.Nvml;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ThermalGuard_Mega_EcoAI
{
    public partial class Form1 : Form
    {
        
        Computer myPC = new Computer { IsCpuEnabled = true, IsGpuEnabled = true };
        PredictionEngine<GpuData, GpuPrediction> predictionEngine = null;
        nvmlDevice gpuDevice = new nvmlDevice();
        bool isNvidiaReady = false;

        public Form1()
        {
            InitializeComponent();
            this.Text = "ThermalGuard Mega-Eco AI";

            myPC.Open();
            InitializeNvidiaDriver();
            TrainAIModel(); 
        }

        private void InitializeNvidiaDriver()
        {
            try
            {
                NvmlNativeMethods.nvmlInit();
                NvmlNativeMethods.nvmlDeviceGetHandleByIndex(0, ref gpuDevice);
                isNvidiaReady = true;
            }
            catch
            {
                isNvidiaReady = false;
                lblStatus.Text = "AI STATUS: NVIDIA DRIVER NOT FOUND";
            }
        }

        private void TrainAIModel()
        {
            try
            {
                string logFile = "gpu_eco_data.csv";

                if (!File.Exists(logFile) || File.ReadAllLines(logFile).Length < 10)
                {
                    return;
                }

                var mlContext = new MLContext();
                IDataView dataView = mlContext.Data.LoadFromTextFile<GpuData>(logFile, hasHeader: true, separatorChar: ',');

                var pipeline = mlContext.Transforms.CopyColumns("Label", nameof(GpuData.PowerWatts))
                    .Append(mlContext.Transforms.Concatenate("Features", nameof(GpuData.GPULoad)))
                    .Append(mlContext.Regression.Trainers.Sdca());

                var model = pipeline.Fit(dataView);
                predictionEngine = mlContext.Model.CreatePredictionEngine<GpuData, GpuPrediction>(model);
            }
            catch { /* Fails silently and will retry on the next timer tick */ }
        }

        private void ecoTimer_Tick(object sender, EventArgs e)
        {
            // --- 1. Retry AI Training if it's stuck ---
            if (predictionEngine == null)
            {
                TrainAIModel();
            }

            // --- 2. Setup Variables ---
            uint powerMW = 0, tempG = 0;
            nvmlUtilization util = new nvmlUtilization();
            float currentCpuTemp = 0;

            // --- 3. Fetch GPU Data ---
            if (isNvidiaReady)
            {
                NvmlNativeMethods.nvmlDeviceGetPowerUsage(gpuDevice, ref powerMW);
                NvmlNativeMethods.nvmlDeviceGetUtilizationRates(gpuDevice, ref util);
                NvmlNativeMethods.nvmlDeviceGetTemperature(gpuDevice, nvmlTemperatureSensors.Gpu, ref tempG);
            }

            // --- 4. Fetch CPU Data ---
            var cpu = myPC.Hardware.FirstOrDefault(h => h.HardwareType == HardwareType.Cpu);
            if (cpu != null)
            {
                cpu.Update();
                var tempSensor = cpu.Sensors.FirstOrDefault(s => s.SensorType == SensorType.Temperature);
                if (tempSensor != null) currentCpuTemp = tempSensor.Value ?? 0;
            }

            // --- 5. Do the Math ---
            float powerWatts = powerMW / 1000f;
            float gpuLoad = (float)util.gpu;
            float efficiencyCalc = (powerWatts > 2) ? (gpuLoad / (powerWatts + 1)) * 10 : 0;

            // --- 6. Update UI Labels (Using F1 so the numbers are REAL) ---
            lblPower.Text = $"GPU POWER: {powerWatts:F1}W";
            lblGpuTemp.Text = $"GPU TEMP: {tempG}°C";
            lblCPU.Text = $"CPU TEMP: {currentCpuTemp:F0}°C";
            lblEcoScore.Text = $"EFFICIENCY INDEX: {efficiencyCalc:F1}";

            // --- 7. Update UI Bars ---
            barPower.Width = Math.Min((int)(powerWatts * 3), 200); // Increased multiplier so lower wattage laptops show a decent bar
            barGpuTemp.Width = Math.Min((int)(tempG * 2), 200);
            barTemp.Width = Math.Min((int)(currentCpuTemp * 2), 200);
            barEco.Width = Math.Min((int)(efficiencyCalc * 8), 200);

            // --- 8. Log Data ---
            string logFile = "gpu_eco_data.csv";
            if (!File.Exists(logFile)) File.WriteAllText(logFile, "Time,PowerWatts,GPULoad,CPUTemp\n");
            File.AppendAllText(logFile, $"{DateTime.Now:HH:mm:ss},{powerWatts:F1},{gpuLoad},{currentCpuTemp:F0}\n");

            // --- 9. AI Status ---
            if (predictionEngine != null)
            {
                var prediction = predictionEngine.Predict(new GpuData { GPULoad = gpuLoad });
                if (powerWatts > (prediction.PredictedPower + 20) && gpuLoad > 10)
                {
                    this.BackColor = Color.Maroon;
                    lblStatus.Text = "AI ALERT: UNUSUAL POWER DRAW";
                }
                else
                {
                    this.BackColor = Color.FromArgb(15, 15, 15); // Returns to dark theme
                    lblStatus.Text = "AI STATUS: SYSTEM STABLE";
                }
            }
            else
            {
                lblStatus.Text = "AI STATUS: INITIALIZING (GATHERING DATA)...";
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                string logFile = "gpu_eco_data.csv";
                if (!File.Exists(logFile)) { MessageBox.Show("No data logged yet!"); return; }

                var lines = File.ReadAllLines(logFile).Skip(1).ToList();
                if (lines.Count == 0) return;

                var powerValues = lines.Select(l => float.Parse(l.Split(',')[1])).ToList();
                string report = $"--- THERMALGUARD HEALTH REPORT ---\n" +
                               $"Generated: {DateTime.Now}\n" +
                               $"Avg Power: {powerValues.Average():F1}W\n" +
                               $"Peak Power: {powerValues.Max():F1}W\n" +
                               $"Status: OPERATIONAL\n" +
                               $"----------------------------------";

                File.WriteAllText("Hardware_Health_Report.txt", report);
                MessageBox.Show("Report saved to Hardware_Health_Report.txt", "Success");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myPC.Close();
            if (isNvidiaReady) NvmlNativeMethods.nvmlShutdown();
        }
    }

    // AI Models
    public class GpuData
    {
        [LoadColumn(1)] public float PowerWatts { get; set; }
        [LoadColumn(2)] public float GPULoad { get; set; }
    }

    public class GpuPrediction
    {
        [ColumnName("Score")] public float PredictedPower { get; set; }
    }
}