using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kullaniciGirisi2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglantı = new OleDbConnection(@"provider=microsoft.jet.oledb.4.0;data source=veri.mdb");
            baglantı.Open();

            OleDbCommand giris = new OleDbCommand("select *from Tablo1 where KullaniciAdi=@KullaniciAdi and Parola=@Parola", baglantı);
            giris.Parameters.Add("KullaniciAdi", textBox1.Text);
            giris.Parameters.Add("Parola", textBox2.Text);
            OleDbDataReader oku = giris.ExecuteReader();

            if (oku.Read())
            {
                Form2 ac = new Form2();
                ac.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SaveData();
        }

        private void InitData()
        {
            if (Properties.Settings.Default.Kuladı != String.Empty)
            {
                if (Properties.Settings.Default.hatırla == true)
                {
                    textBox1.Text = Properties.Settings.Default.Kuladı;
                    //textBox2.Text = Properties.Settings.Default.şifre;
                    checkBox1.Checked = true;

                }
                else
                {
                    textBox1.Text = Properties.Settings.Default.Kuladı;
                }

            }
        }
        private void SaveData()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.Kuladı = textBox1.Text;
                Properties.Settings.Default.hatırla = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.Kuladı = "";
                Properties.Settings.Default.hatırla = false;
                Properties.Settings.Default.Save();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 sifre = new Form3();
            sifre.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
