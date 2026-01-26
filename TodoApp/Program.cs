using System;
using System.Windows.Forms;

namespace TodoApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            System.Windows.Forms.Application.Run(new Form1());
        }
    }
}
