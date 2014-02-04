using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)                                 //Ініціалізація основної форми                      
        {
            foreach (string item in System.IO.Ports.SerialPort.GetPortNames())              //Взнаємо які ком-порти є в системі
            {
                portBox.Items.Add(item);                                                    //Додаєм їх в ліст-бокс
                portBox.SelectedIndex = 0;
            }

            try
            {                                                                               //Перевіряєм наявність портів
                label1.Text = "OPEN";
                portBox.Text = Properties.Settings.Default.PortName;                        //Пізтаємо збережені параметри із сейву
                label1.Text = "READ PORT";
                serialPort1.Open();
                label1.Text = "OPEN PORT";
                serialPort1.DtrEnable = true;
                label1.Text = "SEND DTR";
                serialPort1.Close();
                label1.Text = "DONE!";

            }
            catch (Exception)
            {                                                                               //Якщо нема ніодного 
                label1.Text = "OPEN FAIL";                                                  //То вишемо це в лейблі
            }

                timer1.Start();                                                             //Запускаємо маймер для закриття проги

        }

        private void portBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = portBox.Text;                                             //Вибираєм ВАШ КОМ-порт
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.Exit();                                                               //По тіку таймера закриваємо прогу
        }

        private void btnSavePort_Click(object sender, EventArgs e)
        {
            timer1.Stop();                                                                    //Зупиняєм таймер якщо нажата кнопка параметрів
            Properties.Settings.Default.PortName = portBox.Text;                              
            Properties.Settings.Default.Save();                                               //Зберігаємо параметри
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                Process.Start("http://digiua.com/");                                           //Лінк на сайт
            }
        }

        private void btnPuls_Click(object sender, EventArgs e)                                  //Кнопка "Р"
        {
            timer1.Stop();
            try
            {
                serialPort1.Open();
                label1.Text = "OPEN PORT";
                serialPort1.DtrEnable = true;
                label1.Text = "SEND DTR";
            }
            catch (Exception)
            {

                label1.Text = "OPEN FAIL";
            }
            
        }
        
      

    }
}
