using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Convertor.Presenters;


namespace Convertor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 view = new Form1();
            Presenter presenter = new Presenter(view);
            Application.Run(view);
        }
    }
}
