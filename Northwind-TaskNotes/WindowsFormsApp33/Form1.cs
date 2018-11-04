using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp33
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NewFolder1.Resimleme resimleme = new NewFolder1.Resimleme();
        List<TaskItem> TIL = new List<TaskItem>();
        List<PersonalInfo> PIL = new List<PersonalInfo>();
        CODIADataDataContext dc = new CODIADataDataContext();
        NorthwindDataDataContext dk = new NorthwindDataDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            Baslangic();
            
        }
        public void Baslangic()
        {
            foreach (var deg in dc.TaskPersonal)
            {
                NotGetir(resimleme.ResimGetirme(deg.Personel_Picture.ToArray()), deg.Task_Note, Convert.ToString(deg.Task_Date));
            }
            foreach (var deg in dk.Order_Subtotals)
            {
                chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(deg.OrderID, deg.Subtotal));
            }
            foreach (var deg in dc.Personal)
            {
                PersonelGetir(deg.Personal_Name + " " + deg.Personal_Surname, resimleme.ResimGetirme(deg.Personel_Picture.ToArray()));
            }
        }
        public void NotGetir(Image resim,string baslik,string tarih)
        {
            TaskItem ıtem = new TaskItem();
            ıtem.bunifuPictureBox1.Image = resim;
            ıtem.label1.Text = tarih;
            ıtem.label2.Text = baslik;
            ıtem.Dock = DockStyle.Top;
            TIL.Add(ıtem);
            bunifuGradientPanel2.Controls.Add(ıtem);
        }
        public void PersonelGetir(string isimsoyisim,Image Photo)
        {
            PersonalInfo ınfo = new PersonalInfo();
            ınfo.label1.Text = isimsoyisim;
            ınfo.bunifuPictureBox1.Image = Photo;
            ınfo.Dock = DockStyle.Left;
            PIL.Add(ınfo);
            bunifuShadowPanel4.Controls.Add(ınfo);
        }
    }
}
