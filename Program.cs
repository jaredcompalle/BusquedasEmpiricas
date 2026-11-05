using System;
using System.Windows.Forms;

namespace BusquedasEmpiricas
{
    /// <summary>
    /// Punto de entrada de la aplicación.
    /// </summary>
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
