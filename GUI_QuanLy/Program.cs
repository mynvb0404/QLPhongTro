using System;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }
    }
}