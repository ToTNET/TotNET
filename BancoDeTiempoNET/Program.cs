using BancoDeTiempoNET.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeTiempoNET
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación Banco de tiempo de TOT.NET.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }



    }
}
