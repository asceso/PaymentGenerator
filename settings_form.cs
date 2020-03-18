using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaymentCreator
{
    public partial class settings_form : Form
    {
        bool beginWrite = false, deleting = false, save = false;
        List<string> pd4Settings = new List<string>();
        List<string> paySettings = new List<string>();
        List<string> fioSettings = new List<string>();
        int paymentCount;
        public settings_form()
        {
            InitializeComponent();
            save = false;
            addFioBox.Text = "Введите ФИО";
            read_settings();
            get_pd4_from_settings();
            get_pay_settings_from_file();
            get_fio_list_to_program();
        }        
        //заполняем настройки из файла
        void read_settings()
        {
            using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + "\\Config.ini"))
            {
                bool pd4Flag = false, payFlag = false, fioFlag = false;
                while (!reader.EndOfStream)
                {
                    string tmp = reader.ReadLine();
                    if (tmp.Contains("#paymentCount="))//считаем кол-во платежей
                    {
                        paymentCount = Convert.ToInt32(tmp.Substring(tmp.IndexOf("=")+1));
                    }
                    if (tmp.Contains("#pd4SettingsStart"))//ищем начало ПД4
                    {
                        reader.ReadLine();
                        do
                        {
                            tmp = reader.ReadLine();
                            if(tmp != "}")
                                pd4Settings.Add(tmp);
                        }
                        while (tmp != "}");
                        reader.ReadLine();
                    }
                    if (tmp.Contains("#paySettingsStart"))//ищем начало платежей
                    {
                        reader.ReadLine();
                        do
                        {
                            tmp = reader.ReadLine();
                            if (tmp != "}")
                                paySettings.Add(tmp);
                        }
                        while (tmp != "}");
                        reader.ReadLine();
                    }
                    if (tmp.Contains("#FIOSettingsStart"))//ищем начало ФИО
                    {
                        reader.ReadLine();
                        do
                        {
                            tmp = reader.ReadLine();
                            if (tmp != "}")
                                fioSettings.Add(tmp);
                        }
                        while (tmp != "}");
                    }
                }
            }
        }
        //настройки пд4
        void get_pd4_from_settings()
        {
            pd4stgTB1.Text = pd4Settings[0];
            pd4stgTB2.Text = pd4Settings[1];
            pd4stgTB3.Text = pd4Settings[2];
            pd4stgTB4.Text = pd4Settings[3];
            pd4stgTB5.Text = pd4Settings[4];
            pd4stgTB6.Text = pd4Settings[5];
        }
        void pd4_to_settings()
        {
            pd4Settings[0]= pd4stgTB1.Text;
            pd4Settings[1]= pd4stgTB2.Text;
            pd4Settings[2]= pd4stgTB3.Text;
            pd4Settings[3]= pd4stgTB4.Text;
            pd4Settings[4]= pd4stgTB5.Text;
            pd4Settings[5]= pd4stgTB6.Text;
        }
        //настройки платежей
        void get_pay_settings_from_file()
        {
            paymentsList.Items.Clear();
            for (int i = 0; i < paySettings.Count; i++)
            {
                paymentsList.Items.Add(paySettings[i]);
            }
            paymentCount = paymentsList.Items.Count;
        }
        void get_pay_settings_to_file()
        {
            paySettings.Clear();
            for (int i = 0; i < paymentsList.Items.Count; i++)
            {
                paySettings.Add(paymentsList.Items[i].ToString());
            }
            paymentCount = paySettings.Count;
        }
        //настройки плательщиков
        void get_fio_list_to_program()
        {
            allPayPeople.Items.Clear();
            for (int i = 0; i < fioSettings.Count; i++)
            {
                allPayPeople.Items.Add(fioSettings[i]);
            }            
        }
        void get_fio_to_settings()
        {
            fioSettings.Clear();
            for (int i = 0; i < allPayPeople.Items.Count; i++)
            {
                fioSettings.Add(allPayPeople.Items[i].ToString());
            }
        }
        //сохранить изменения
        void save_changes()
        {
            using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + "\\Config.ini"))
            {
                writer.WriteLine("#paymentCount=" + paymentCount.ToString());
                //записываем настройки ПД-4
                writer.WriteLine("#pd4SettingsStart");
                writer.WriteLine("{");
                for (int i = 0; i < pd4Settings.Count; i++)
                {
                    writer.WriteLine(pd4Settings[i]);
                }
                writer.WriteLine("}");
                writer.WriteLine("#pd4SettingsEnd");
                //записываем настройки платежей
                writer.WriteLine("#paySettingsStart");
                writer.WriteLine("{");
                for (int i = 0; i < paySettings.Count; i++)
                {
                    writer.WriteLine(paySettings[i]);
                }
                writer.WriteLine("}");
                writer.WriteLine("#paySettingsEnd");
                //записываем плательщиков
                writer.WriteLine("##FIOSettingsStart");
                writer.WriteLine("{");
                for (int i = 0; i < fioSettings.Count; i++)
                {
                    writer.WriteLine(fioSettings[i]);
                }
                writer.WriteLine("}");
                writer.WriteLine("#FIOSettingsEnd");
            }
        }
        private void applyChanges_Click(object sender, EventArgs e)
        {
            pd4_to_settings();
            get_pay_settings_to_file();
            get_fio_to_settings();
            save_changes();
            save = true;
        }

        private void addFioBox_TextChanged(object sender, EventArgs e)
        {
            if ((addFioBox.Text.Length == 0)&&(beginWrite==false))
                addFioBox.Text = "Введите ФИО";
            addFioBox.Text = addFioBox.Text;
            beginWrite = false;
        }

        private void addFioBox_Click(object sender, EventArgs e)
        {
            beginWrite = true;
            addFioBox.Clear();
        }

        private void delPeople_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = allPayPeople.SelectedIndex;
                allPayPeople.Items.RemoveAt(allPayPeople.SelectedIndex);
                if(allPayPeople.Items.Count>0) allPayPeople.SelectedIndex = ind;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Не выбран элемент","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void addPeople_Click(object sender, EventArgs e)
        {
            allPayPeople.Items.Add(addFioBox.Text);
        }

        private void delPayment_Click(object sender, EventArgs e)
        {
            deleting = true;
            paymentsList.Items.RemoveAt(paymentsList.SelectedIndex);
            deleting = false;
        }

        private void settings_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(save==true)
                MessageBox.Show("Настройки были изменены\rперезапустите приложение.","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void addPayment_Click(object sender, EventArgs e)
        {
            string adding=null;
            adding += payStgBox1.Text + ",";
            adding += payStgBox2.Text + ",";
            adding += payStgBox3.Text + ",";
            adding += payStgBox4.Text + ",";
            adding += payStgBox5.Text + ",";
            adding += payStgBox6.Text + ",";
            adding += payStgBox7.Text;
            paymentsList.Items.Add(adding);
        }

        private void paymentsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deleting == false)
            {
                string set = paySettings[paymentsList.SelectedIndex];
                payStgBox1.Text = set.Remove(set.IndexOf(","));
                set = set.Substring(set.IndexOf(",") + 1);
                payStgBox2.Text = set.Remove(set.IndexOf(","));
                set = set.Substring(set.IndexOf(",") + 1);
                payStgBox3.Text = set.Remove(set.IndexOf(","));
                set = set.Substring(set.IndexOf(",") + 1);
                payStgBox4.Text = set.Remove(set.IndexOf(","));
                set = set.Substring(set.IndexOf(",") + 1);
                payStgBox5.Text = set.Remove(set.IndexOf(","));
                set = set.Substring(set.IndexOf(",") + 1);
                payStgBox6.Text = set.Remove(set.IndexOf(","));
                set = set.Substring(set.IndexOf(",") + 1);
                payStgBox7.Text = set;
            }
        }
    }
}
