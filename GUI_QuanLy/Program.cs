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
            Application.Run(new frmManageAcc());
            Application.Run(new frmMenu());
            Application.Run(new frmArea());
            Application.Run(new frmRoom());
            Application.Run(new FormQuanLyOGhep());
            Application.Run(new FormQuanLyHoaDon());
            Application.Run(new FormQuanLyBaoCao());

        }
    }
}