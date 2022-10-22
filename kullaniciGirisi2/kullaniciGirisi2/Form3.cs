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
using System.Security.Policy;

namespace kullaniciGirisi2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OleDbConnection baglantı = new OleDbConnection(@"provider=microsoft.jet.oledb.4.0;data source=veri.mdb");
            //baglantı.Open();

            //OleDbCommand giris = new OleDbCommand("select *from Tablo1 where e-Posta=@e-Posta and parola=@parola", baglantı);

            //giris.Parameters.Add("e-Posta", textBox1.Text);
            //OleDbDataReader oku = giris.ExecuteReader();

            //if (oku.Read())
            //{

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("atedeneme13@gmail.com");
            ePosta.To.Add(textBox1.Text);
            //ePosta.Attachments.Add(new Attachment(""));
            ePosta.Subject = "Şifre";
            ePosta.Body = "Şifreniz : 4159";  //oku["parola"].ToString();
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("atedeneme13@gmail.com", "myrousddlceyedzz");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(ePosta);
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
                MessageBox.Show("e-Posta Gönderildi");
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            //  }











            //MailMessage ePosta = new MailMessage();
            //ePosta.From = new MailAddress("atedeneme13@gmail.com");
            //ePosta.To.Add(textBox1.Text);
            ////ePosta.Attachments.Add(new Attachment(@"D:\142116.jpg"));
            //ePosta.Subject = sifre;
            //ePosta.Body = "";
            //SmtpClient smtp = new SmtpClient();
            //smtp.Credentials = new System.Net.NetworkCredential("atedeneme13@gmail.com", "myrousddlceyedzz");
            //smtp.Port = 587;
            //smtp.Host = "smtp.gmail.com";
            //smtp.EnableSsl = true;
            //smtp.Send(ePosta);
            //object userState = ePosta;
            //bool kontrol = true;
            //try
            //{
            //    smtp.SendAsync(ePosta, (object)ePosta);
            //}
            //catch (SmtpException ex)
            //{
            //    kontrol = false;
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            //}




        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            
        }

        
    }
}
