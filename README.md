ThermalGuard is an intelligent hardware telemetry and monitoring application built in C# (WinForms). It tracks real-time CPU temperatures and NVIDIA GPU power utilization, utilizing a local Machine Learning model to detect anomalous power spikes and calculate hardware efficiency.

!!!Key Features
Real-Time Telemetry Live tracking of GPU Power (Watts), GPU Temperature, and CPU Temperature.
AI Anomaly Detection: Utilizes `Microsoft.ML` (SDCA RegressionTrainer) to predict expected power draw based on GPU load. If actual power exceeds the predicted safe margin, the system triggers a visual thermal/power alert.
Efficiency Scoring: Calculates a dynamic performance-per-watt efficiency index in real time.
Health Reporting: Generates and exports local hardware stability reports.
Dark UI Theme: Designed with a clean, cyberpunk-inspired neon UI for easy readability.

!!!Technologies Used
C# / .NET (WinForms)
Microsoft.ML (Machine Learning / SDCA Regression)
ManagedCuda.Nvml (NVIDIA GPU Interfacing)
LibreHardwareMonitor (CPU Sensor Telemetry)

Getting Started

!!!Prerequisites
An NVIDIA GPU (for NVML telemetry).
Visual Studio (if building from source).
Important: This application *must* be run as an **Administrator** to properly read CPU temperature sensors via the LibreHardwareMonitor library.
