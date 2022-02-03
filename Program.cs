using System;
using System.Windows.Forms;

namespace RouletteBot
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(new Models.Game(new Models.MouseRouletteControls())));
        }
    }
}
