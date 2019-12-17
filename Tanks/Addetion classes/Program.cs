using System;
using System.Windows.Forms;

namespace Tanks
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] arg) 
        {
            ControllerMainForm controller;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch (arg.Length)
            {
                case 0: controller = new ControllerMainForm(); break;
                case 1: controller = new ControllerMainForm(Convert.ToInt32(arg[0])); break;
                case 2: controller = new ControllerMainForm(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1])); break;
                case 3: controller = new ControllerMainForm(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]), Convert.ToInt32(arg[2])); break;
                case 4: controller = new ControllerMainForm(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]), Convert.ToInt32(arg[2]), Convert.ToInt32(arg[3])); break;
                default: controller = new ControllerMainForm(); break;
            }

            Application.Run(controller);
        }
    }
}
