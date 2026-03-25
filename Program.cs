using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThermalGuard_Mega_EcoAI // <--- Make sure this matches!
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // This line must match the name of your class in Form1.cs
            Application.Run(new Form1());
        }
    }
}