using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace benzinotomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        //program içeririnde kullanılan değişkeleri double türünden tanımladık D=depo, F=fiyat anlamı taşomaktadır.
        //tanımlanan 2 adet dizimiz debug içerisine kayırlı olan .txt lerden veri çekmek için tanımladık.
        double D_benzin95 = 0, D_benzin98 = 0, D_dizel = 0, D_eurodizel = 0, D_lpg = 0;
        double F_benzin95 = 0, F_benzin98 = 0, F_dizel = 0, F_eurodizel = 0, F_lpg = 0;
        double S_benzin95 = 0, S_benzin98 = 0, S_dizel = 0, S_eurodizel = 0, S_lpg = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                F_benzin95 = F_benzin95 + (F_benzin95 * Convert.ToDouble(textBox6.Text) / 100);//benzin fiyatını % ifadesiyle degerlendirdik
                Fiyatbilgileri[0] = Convert.ToString(F_benzin95);//text dosyadınıda bu değerle güncelledik
            }
            catch (Exception)
            {
                textBox6.Text = "Hata!";
                
            }
            try
            {
                F_benzin98 = F_benzin98 + (F_benzin98 * Convert.ToDouble(textBox7.Text) / 100);
                Fiyatbilgileri[1] = Convert.ToString(F_benzin98);
            }
            catch (Exception)
            {

                textBox7.Text = "Hata!";
            }
            try
            {
                F_dizel = F_dizel + (F_dizel * Convert.ToDouble(textBox8.Text) / 100);
                Fiyatbilgileri[2] = Convert.ToString(F_dizel);
            }
            catch (Exception)
            {

                textBox8.Text = "Hata";
            }
            try
            {
                F_eurodizel = F_eurodizel + (F_eurodizel * Convert.ToDouble(textBox9.Text) / 100);
                Fiyatbilgileri[3] = Convert.ToString(F_eurodizel);
            }
            catch (Exception)
            {

                textBox9.Text = "Hata";
            }
            try
            {
                F_lpg = F_lpg + (F_lpg * Convert.ToDouble(textBox10.Text) / 100);
                Fiyatbilgileri[4] = Convert.ToString(F_lpg);

            }
            catch (Exception)
            {

                textBox10.Text = "Hata";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyatbilgi.txt", Fiyatbilgileri);
            txt_fiyat_oku();
            txt_fiyat_yaz();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text== "Benzin (95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
           else if (comboBox1.Text == "Benzin (98)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
           else if (comboBox1.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "EuroDizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            else if(comboBox1.Text=="Lpg")            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label28.Text = "-----------";
        }

        double E_benzin95 = 0, E_benzin98 = 0, E_dizel = 0, E_eurodizel = 0, E_lpg = 0;
        string[] Depobilgileri;
        string[] Fiyatbilgileri;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //try ve caatch hata eyıklama metodu ile texten benzin değerinin e_benzin yani eklenecek benzin değişkenine convert edip aktardık.
                // if sartı ile eklenen değer 1000 lt yi geçmeyecek ve 0 ve altında deger girilemeyecek.
                E_benzin95 = Convert.ToDouble(textBox1.Text);
                if (1000<E_benzin95+D_benzin95||E_benzin95<=0)
                {
                    textBox1.Text = "Hata";
                }
                else  
                {
                    //txt dosyasında ilgili yere yani[0] satırına eklenen bilgiler güncellenip yazılacak
                    Depobilgileri[0] = Convert.ToString(D_benzin95 + E_benzin95);
                }
                
            }
            catch (Exception)
            {
                textBox1.Text = "Hata!";
                
            }
            try
            {
                //yukarıda açıkladığım şekilde diggerleride...
                E_benzin98 = Convert.ToDouble(textBox2.Text);
                if (1000 < E_benzin98 + D_benzin98 || E_benzin98 <= 0)
                {
                    textBox2.Text = "Hata";
                }
                else
                {
                    Depobilgileri[1] = Convert.ToString(D_benzin98 + E_benzin98);
                }

            }
            catch (Exception)
            {
                textBox2.Text = "Hata!";

            }
            try
            {
                E_dizel = Convert.ToDouble(textBox3.Text);
                if (1000 < E_dizel + D_dizel || E_dizel <= 0)
                {
                    textBox3.Text = "Hata";
                }
                else
                {
                    Depobilgileri[2] = Convert.ToString(D_dizel + E_dizel);
                }

            }
            catch (Exception)
            {
                textBox3.Text = "Hata!";

            }
            try
            {
                E_eurodizel = Convert.ToDouble(textBox4.Text);
                if (1000 < E_eurodizel + D_eurodizel || E_eurodizel <= 0)
                {
                    textBox4.Text = "Hata";
                }
                else
                {
                    Depobilgileri[3] = Convert.ToString(D_eurodizel + E_eurodizel);
                }

            }
            catch (Exception)
            {
                textBox4.Text = "Hata!";

            }
            try
            {
                E_lpg = Convert.ToDouble(textBox5.Text);
                if (1000 < E_lpg + D_lpg || E_lpg <= 0)
                {
                    textBox5.Text = "Hata";
                }
                else
                {
                    Depobilgileri[4] = Convert.ToString(D_lpg + E_lpg);
                }

            }
            catch (Exception)
            {
                textBox5.Text = "Hata!";

            }
          
            //.txt dosyasındaki verileri güncelliyor sonra program üzerinde güncelleme sağlıyorum sıralama bu şekilde ,depobilgileri dizisine ekliyoruz.
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depobilgi.txt", Depobilgileri);
            //şimdi neden metot kullandığımızı anladınızmı???
            txt_depo_oku();
            txt_depo_yaz();
            numericupdown_value();
            progresbar_güncelle();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            //dönüşrüeme önce stringe sonra double.
            S_benzin95 = double.Parse(numericUpDown1.Value.ToString());
            S_benzin98 = double.Parse(numericUpDown2.Value.ToString());
            S_dizel = double.Parse(numericUpDown3.Value.ToString());
            S_eurodizel = double.Parse(numericUpDown4.Value.ToString());
            S_lpg= double.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled==true)
            {
                D_benzin95 = D_benzin95 - S_benzin95;
                label28.Text = Convert.ToString(S_benzin95 * F_benzin95);

            }
            else if (numericUpDown2.Enabled == true)
            {
                D_benzin98 = D_benzin98 - S_benzin98;
                label28.Text = Convert.ToString(S_benzin98 * F_benzin98);

            }
            else if (numericUpDown3.Enabled == true)
            {
                D_dizel = D_dizel - S_dizel;
                label28.Text = Convert.ToString(S_dizel * F_dizel);

            }
            else if (numericUpDown4.Enabled == true)
            {
                D_eurodizel = D_eurodizel - S_eurodizel;
                label28.Text = Convert.ToString(S_eurodizel * F_eurodizel);

            }
            else if (numericUpDown5.Enabled == true)
            {
                D_lpg = D_lpg - S_lpg;
                label28.Text = Convert.ToString(S_lpg * F_lpg);

            }
            Depobilgileri[0] = Convert.ToString(D_benzin95);
            Depobilgileri[1] = Convert.ToString(D_benzin98);
            Depobilgileri[2] = Convert.ToString(D_dizel);
            Depobilgileri[3] = Convert.ToString(D_eurodizel);
            Depobilgileri[4] = Convert.ToString(D_lpg);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depobilgi.txt", Depobilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            numericupdown_value();
            progresbar_güncelle();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
        }

       
        private void txt_depo_oku()
        {
            //.txt dosyamızı satır satır okuyarak gerekli yerleri yazılmasını sağladık.
            //system.IO... ifadesinde bu klasördeki .depobilgi.txt dosyadını satır satır okuyup veri çektik.
            Depobilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depobilgi.txt");
            
            D_benzin95 = Convert.ToDouble(Depobilgileri[0]);
            D_benzin98 = Convert.ToDouble(Depobilgileri[1]);
            D_dizel = Convert.ToDouble(Depobilgileri[2]);
            D_eurodizel = Convert.ToDouble(Depobilgileri[3]);
            D_lpg = Convert.ToDouble(Depobilgileri[4]);
        }
        private void txt_depo_yaz()
        {
            // form üzerine tostring degerine çevirere yazdırdık. burada "N" işaretinne değinecek olursak kısaca (100.00) ifadesindeki son 00 iki sıfırı temsil etmektedir.
            label6.Text = D_benzin95.ToString("N");
            label7.Text = D_benzin98.ToString("N");
            label8.Text = D_dizel.ToString("N");
            label9.Text = D_eurodizel.ToString("N");
            label10.Text = D_lpg.ToString("N");

        }
        private void txt_fiyat_oku()
        {
            Fiyatbilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyatbilgi.txt");
            F_benzin95 = Convert.ToDouble(Fiyatbilgileri[0]);
            F_benzin98 = Convert.ToDouble(Fiyatbilgileri[1]);
            F_dizel = Convert.ToDouble(Fiyatbilgileri[2]);
            F_eurodizel = Convert.ToDouble(Fiyatbilgileri[3]);
            F_lpg = Convert.ToDouble(Fiyatbilgileri[4]);

        }
        private void txt_fiyat_yaz()
        {
            label20.Text = F_benzin95.ToString("N");
            label19.Text = F_benzin98.ToString("N");
            label18.Text = F_dizel.ToString("N");
            label17.Text = F_eurodizel.ToString("N");
            label16.Text = F_lpg.ToString("N");
        }
        private void numericupdown_value()
        {
            //numerizupdown nesnemizin maxsimum değerini depoda mevcut olan değerlerle eşleştirdik.
            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(D_benzin98.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_eurodizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(D_lpg.ToString());
        }
        private void progresbar_güncelle()
        {
            //progresbar her depoya giriş ve çıkışta otomatik value, artış değerini belirttik. otomatik güncellenecektir.
            progressBar1.Value = Convert.ToInt16(D_benzin95);
            progressBar2.Value = Convert.ToInt16(D_benzin98);
            progressBar3.Value = Convert.ToInt16(D_dizel);
            progressBar4.Value = Convert.ToInt16(D_eurodizel);
            progressBar5.Value = Convert.ToInt16(D_lpg);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //programımıza isim verip progressbar max değerlerini belirttik. bunu propertes ekranındada yapabilirdil.
            this.Text = "AKARYAKIT OTOMASYONU";
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;
            //metotları çağırdık
            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            progresbar_güncelle();
            numericupdown_value();
            //comcobax1 nesnemize eleman eklemek için dizi tanımlamasını yapım içerisine eleman ekledik.
            string[] yakit_türleri = { "Benzin (95)", "Benzin (98)", "Dizel", "EuroDizel", "Lpg", };
            comboBox1.Items.AddRange(yakit_türleri);
            //numericupdown pasif hale getirdk
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            //küsürat değerlere uygun hale 100.00 örneği ile
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;
            //artış değeri "M" işareti ondalık belirtmek
            numericUpDown1.Increment=0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;
            //dışarıdan değer girilemez sadece yan tarafında bulunan tikleri ile sağlanır;
            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;


        }
    }
}
