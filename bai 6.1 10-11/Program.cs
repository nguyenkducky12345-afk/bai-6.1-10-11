using System;
using System.Windows.Forms;

namespace RetailSalesSystem
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

            // Chạy Form1 - Màn hình Bán hàng
            Application.Run(new Form1());
        }
    }
}