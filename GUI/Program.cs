using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEstoque.GUI
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
            Application.Run(new frmSplashScreen());

            frmSplashScreen frmSplash = new frmSplashScreen();
            frmSplash.ShowDialog();

            frmLogin frmLogin = new frmLogin();            

            if (frmLogin.logado == true)
            {
                int tipfun = frmLogin.v;
                //MessageBox.Show(Convert.ToString(tipfun));
                frmPrincipal frmPrin = new frmPrincipal();
                frmPrin.v = tipfun;
                Application.Run(frmPrin);
            }
            else { Application.Exit(); }
        }
    }
}
