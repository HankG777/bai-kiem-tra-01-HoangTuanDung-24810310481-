using System;
using System.Windows.Forms;
using TechMart_Product_Manager;

namespace TechMartProductManager
{
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
