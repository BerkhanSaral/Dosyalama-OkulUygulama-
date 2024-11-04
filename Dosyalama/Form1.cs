using System;
using System.IO;
using System.Windows.Forms;

namespace Dosyalama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string yol = Application.StartupPath + "\\notlar.txt";
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            StreamWriter dosya = File.AppendText(yol);
          
            dosya.Write(txtOkulNo.Text + " - ");
            dosya.Write(txtAdSoyad.Text + " - ");
            dosya.Write(cmbDersAdi.Text + " - ");
            dosya.Write(txtVize.Text + " - ");
            dosya.Write(txtFinal.Text + " - ");

           
            double ort = Convert.ToDouble(txtVize.Text) * 0.4 + Convert.ToDouble(txtFinal.Text) * 0.6;


            if (ort < 50)
            {
                dosya.WriteLine(ort.ToString() + " FF/Kaldi");
            }
            else if (ort > 49 && ort < 70)
            {
                dosya.WriteLine(ort.ToString() + " CC/Gecti");
            }
            else if (ort > 69 && ort < 84)
            {
                dosya.WriteLine(ort.ToString() + " BB/Gecti");
            }
            else if (ort > 83)
            {
                dosya.WriteLine(ort.ToString() + " AA/Gecti");
            }

          

            dosya.Close();
            MessageBox.Show("Kayit Tamamlandi");


            foreach (Control nesne in this.Controls)
            {
                if (nesne is TextBox)
                {
                    ((TextBox)nesne).Clear();
                }
            }
            cmbDersAdi.Text = "";
            txtOkulNo.Focus();
            listele();

        }
        public void listele()
        {
            lstOkulNo.Items.Clear();
            lstDersAdi.Items.Clear();
            lstOrt.Items.Clear();
            if (File.Exists(yol))
            {
               StreamReader dosya=File.OpenText(yol);
                string oku = dosya.ReadLine();
                while (oku!=null)
                {
                    string[] parca = oku.Split('-');
                    lstOkulNo.Items.Add(parca[0]);
                    lstDersAdi.Items.Add(parca[2]);
                    lstOrt.Items.Add(parca[5]);
                    oku = dosya.ReadLine();
                }
                dosya.Close();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
