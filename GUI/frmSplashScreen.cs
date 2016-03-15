using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ControleDeEstoque.GUI
{
    public partial class frmSplashScreen : Form
    {
        //-------------------------------------------------------------------------------------------------------------------
        Timer t = new Timer();
        //-------------------------------------------------------------------------------------------------------------------
        //pb = ProgressBar
        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbComplete;
        //-------------------------------------------------------------------------------------------------------------------
        Bitmap bmp;
        Graphics g;
        //-------------------------------------------------------------------------------------------------------------------
        public frmSplashScreen()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            pbCarrega.Value = pbCarrega.Value + 1;
            if (this.pbCarrega.Value == 10)
            {
                label4.Text = "Lendo Módulos..";
            }
            else if (this.pbCarrega.Value == 20)
            {
                label4.Text = "Ativando Módulos.";
            }
            else if (this.pbCarrega.Value == 40)
            {
                label4.Text = "Iniciando Módulos..";
            }
            else if (this.pbCarrega.Value == 60)
            {
                label4.Text = "Carregando Módulos..";
            }
            else if (this.pbCarrega.Value == 80)
            {
                label4.Text = "Carga de Módulos concluída.";
            }
            else if (this.pbCarrega.Value == 100)
            {
                //frm.Show();
                timer1.Enabled = false;
                //this.Hide();
            }
            //if (pbCarrega.Value < 100)
            //{
            //    pbCarrega.Value = pbCarrega.Value + 2;
            //}
            //else
            //{
            //    timer1.Enabled = false;
            //    this.Visible = false;

            //    frmLogin login = new frmLogin();
            //    login.ShowDialog();
            //}
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            //get picboxPB dimension
            pbWIDTH = picboxPB.Width;
            pbHEIGHT = picboxPB.Height;
            pbUnit = pbWIDTH / 100.0;
            //pbComplete - This is equal to work completed in % [min = 0 max = 100]
            pbComplete = 0;
            //create bitmap
            bmp = new Bitmap(pbWIDTH, pbHEIGHT);
            //timer
            t.Interval = 60;    //in millisecond
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void t_Tick(object sender, EventArgs e)
        {
            //graphics
            g = Graphics.FromImage(bmp);
            //clear graphics
            g.Clear(Color.Transparent);
            //draw progressbar
            g.FillRectangle(Brushes.DodgerBlue, new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT));
            //draw % complete
            g.DrawString(pbComplete + "%", new Font("Segeo UI", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));
            //load bitmap in picturebox picboxPB
            picboxPB.Image = bmp;
            //update pbComplete
            //Note!
            //To keep things simple I am adding +1 to pbComplete every 50ms
            //You can change this as per your requirement :)
            pbComplete++;
            if (pbComplete > 100)
            {
                //dispose
                g.Dispose();
                t.Stop();
                this.Visible = false;

                frmLogin login = new frmLogin();
                login.ShowDialog();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}
