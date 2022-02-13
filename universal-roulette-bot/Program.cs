using System;
using System.IO;
using System.Windows.Forms;
using RouletteBot.Views;

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

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\RouletteBot");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
