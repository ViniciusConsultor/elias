using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Alfa.Pet.Win.paginas;

namespace Alfa.Pet.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MarcaManter());
        }
    }
}
