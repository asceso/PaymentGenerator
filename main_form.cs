using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace PaymentCreator
{
    public partial class Main : Form
    {
        string path = @"C:\Users\" + Environment.UserName + @"\Desktop\pay.docx";
        int countSymInRow = 75;
        int numOfPass = 1;
        int countPayments = 1;
        //настройки формы ПД4        
        string nameIP,INN,payNumber,bank,BIK,adjustNum;
        //настройки платежей
        int paySettingsCount = 0;
        //массив 
        //0-название в листе
        //1-название в платежке
        //2-кол-во платежей
        //3-цена
        //4-цена последнего
        //5-цена индвидуально
        //6-цена последнего индивидуально
        string[,] payments;
        //даты
        string[] days=new string[4];

        DocX document;

        public Main()
        {
            InitializeComponent();         
            readSettings();            
        }
        void readSettings()
        {
            string allSettings = null;
            List<string> settings = new List<string>();
            using (StreamReader reader = new StreamReader(Environment.CurrentDirectory + "\\Config.ini"))
            {
                allSettings = reader.ReadToEnd();
            }
            string paySettingsCountString = allSettings.Remove(allSettings.IndexOf(Environment.NewLine));
            paySettingsCount = Convert.ToInt32(paySettingsCountString.Substring((paySettingsCountString.IndexOf("=")) + 1));
            string pd4Settings, paySettings, FIOSettings;
            //формируем настройки ПД4
            int pd4Start = allSettings.IndexOf("#pd4SettingsStart");
            pd4Settings = allSettings.Remove(0, pd4Start + 22);
            int pd4End = pd4Settings.IndexOf("#pd4SettingsEnd");
            pd4Settings = pd4Settings.Remove(pd4End - 3);
            //переносим настройки в переменные   
            for (int i = 0; i < 6; i++)
            {
                int tmp = pd4Settings.LastIndexOf(Environment.NewLine);
                pd4Settings = pd4Settings.Remove(tmp);
                tmp = pd4Settings.LastIndexOf(Environment.NewLine);
                if (i == 5) settings.Add(pd4Settings.Substring(tmp + 1));
                else settings.Add(pd4Settings.Substring(tmp + 2));
            }
            adjustNum = settings[0]; BIK = settings[1]; bank = settings[2];
            payNumber = settings[3]; INN = settings[4]; nameIP = settings[5];
            settings.Clear();
            payments = new string[paySettingsCount, 7];
            //формируем настройки платежа
            int paySettingsStart = allSettings.IndexOf("#paySettingsStart");
            paySettings = allSettings.Remove(0, paySettingsStart + 22);
            int paySettingsEnd = paySettings.IndexOf("#paySettingsEnd");
            paySettings = paySettings.Remove(paySettingsEnd - 3);
            for (int i = 0; i < paySettingsCount; i++)
            {
                int tmp = paySettings.LastIndexOf(Environment.NewLine);
                paySettings = paySettings.Remove(tmp);
                tmp = paySettings.LastIndexOf(Environment.NewLine);
                if (i == paySettingsCount-1) settings.Add(paySettings.Substring(tmp + 1));
                else settings.Add(paySettings.Substring(tmp + 2));
            }
            for (int i = 0; i < payments.GetLength(0); i++)
            {
                string payTmp = settings[i];
                for (int j = payments.GetLength(1)-1; j > 0; j--)
                {
                    payments[i, j] = payTmp.Substring((payTmp.LastIndexOf(","))+1);
                    payTmp = payTmp.Remove(payTmp.LastIndexOf(","));
                }
                payments[i, 0] = payTmp;
            }
            settings.Clear();
            //формируем список плательщиков
            int FIOSettingsStart = allSettings.IndexOf("#FIOSettingsStart");
            FIOSettings = allSettings.Remove(0, FIOSettingsStart + 22);
            int FIOSettingsEnd = FIOSettings.IndexOf("#FIOSettingsEnd");
            FIOSettings = FIOSettings.Remove(FIOSettingsEnd - 3);
            //ищем последнее вхождение символа
            int indexFIO=FIOSettings.LastIndexOf("\r");
            //проверяем пока символ присутствует
            FIOBox.Items.Clear();
            while (indexFIO != -1)
            {
                FIOSettings = FIOSettings.Remove(indexFIO);//удаляем с последнего вхождения
                indexFIO = FIOSettings.LastIndexOf("\r");//ищем снова
                if(indexFIO!=-1)
                    FIOBox.Items.Add(FIOSettings.Substring(indexFIO));//добавляем с символа
            }
            FIOBox.Items.Add(FIOSettings);//добавляем оставшийся
            FIOBox.Sorted = true;
            
        }
        void fill___(Table table,int tableRow,int row,bool newLine)
        {
            int curCount = table.Rows[tableRow].Cells[1].Paragraphs[row].Text.Length;
            string strEnd = null;
            for (int c = curCount; c < countSymInRow*numOfPass; c++) 
                {
                strEnd += "_";
                }
            table.Rows[tableRow].Cells[1].Paragraphs[row]
            .Append(strEnd);
            if (newLine == true)
            { table.Rows[tableRow].Cells[1].Paragraphs[row].Append(Environment.NewLine); }
            numOfPass++;
        }
        string getNamePayString() {
            string result="Оплата курса ";
            result += payments[courseSelect.SelectedIndex,1];            
            return result+" ";
        }
        string getCountOfPayment()
        {
            return paySelect.Items[paySelect.SelectedIndex].ToString();
        }
        string getFIO()
        {
            //string result = FIOBox.Items[FIOBox.SelectedIndex].ToString();
            //if (result.StartsWith("\r\n")) result = result.Substring(2);
            //if (result.EndsWith("\r\n")) result = result.Remove(result.Length - 2);
            //return result;
            return FIOBox.Text;
        }
        string GetSum()
        {
            if (isPersonal.Checked == true)
            {
                if (paySelect.SelectedIndex == paySelect.Items.Count - 1) 
                { return payments[courseSelect.SelectedIndex, 6]; }
                return payments[courseSelect.SelectedIndex, 5];
            }
            else
            {
                if (paySelect.SelectedIndex == paySelect.Items.Count - 1)
                { return payments[courseSelect.SelectedIndex, 4]; }
                return payments[courseSelect.SelectedIndex, 3];
            }
        }
        string[] check_days()
        {
            days[0] = payYesFrom.SelectionStart.Date.ToString("dd.MM.yy");
            days[1] = payYesTo.SelectionStart.Date.ToString("dd.MM.yy");
            days[2] = payNoFrom.SelectionStart.Date.ToString("dd.MM.yy");
            days[3] = payNoTo.SelectionStart.Date.ToString("dd.MM.yy");
            return days;
        }
        void create_table_payment()
        {
            Table table = document.AddTable(2, 2);
            table.Alignment = Alignment.left;
            table.Design = TableDesign.TableGrid;
            table.SetWidths(new float[] { 136.5f, 695f });
            //заполняем левую часть таблицы
            table.Rows[0].Cells[0].Paragraphs[0]
                .Append("\nИзвещение" +
                "\n\n\n\n\n\n\n\n\n\n" +
                "Кассир\n")
                .FontSize(12).Font("Times New Roman")
                .Bold()
                .Alignment = Alignment.center;
            table.Rows[1].Cells[0].Paragraphs[0]
                .Append("\nКвитанция" +
                "\n\n\n\n\n\n\n\n\n\n" +
                "Кассир\n")
                .FontSize(12).Font("Times New Roman")
                .Bold()
                .Alignment = Alignment.center;
            //правая часть таблицы
            for (int i = 0; i < 2; i++)
            {
                //Форма ПД заголовок
                table.Rows[i].Cells[1].Paragraphs[0]
                .Append("Форма № ПД - 4")
                .FontSize(9).Font("Times New Roman")
                .Alignment = Alignment.right;
                //Получатель платежа
                table.Rows[i].Cells[1].InsertParagraph()
                .Append("Наименование получателя платежа: ")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.both;
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(nameIP).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(11).Font("Times New Roman");
                fill___(table,i, 1,true);
                //ИНН-КПП   
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append("ИНН/ КПП получателя платежа: ")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.both;
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(INN).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(11).Font("Times New Roman");
                fill___(table, i, 1, true);
                //Номер счета
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append("Номер счета получателя платежа: ")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.both;
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(payNumber).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(11).Font("Times New Roman");
                fill___(table, i, 1, true);
                //Банк
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append("Наименование банка: ")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.both;
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(bank).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(11).Font("Times New Roman");
                fill___(table, i, 1, true);
                //БИК и кор.счет
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append("БИК: ")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.both;
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(BIK).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(11).Font("Times New Roman");
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(" Кор.счёт: ")
                .FontSize(11).Font("Times New Roman");
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(adjustNum).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(11).Font("Times New Roman");
                fill___(table, i, 1, true);
                //Наименование платежа
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append("Наименование платежа: ")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.both;
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(getNamePayString()).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(11).Font("Times New Roman");
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(getCountOfPayment()).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(12).Font("Times New Roman").Bold();
                fill___(table, i, 1, true);
                //Плательщик
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append("\rПлательщик (ФИО) ")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.both;
                fill___(table, i, 1, true);
                table.Rows[i].Cells[1].Paragraphs[1].Append("\r");
                //Ребенок
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append("Ребенок (ФИО) ___")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.both;
                table.Rows[i].Cells[1].Paragraphs[1]
                .Append(getFIO()).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(12).Font("Times New Roman");
                fill___(table, i, 1, false);
                //Сумма платежа
                table.Rows[i].Cells[1].InsertParagraph()
                .Append("Сумма платежа _")
                .FontSize(11).Font("Times New Roman")
                .Alignment = Alignment.left;
                table.Rows[i].Cells[1].Paragraphs[2]
                .Append(GetSum()).UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(12).Font("Times New Roman").Bold();
                table.Rows[i].Cells[1].Paragraphs[2]
                .Append("_руб. _").FontSize(11).Font("Times New Roman");
                table.Rows[i].Cells[1].Paragraphs[2]
                .Append("00").UnderlineStyle(UnderlineStyle.singleLine)
                .FontSize(12).Font("Times New Roman").Bold();
                table.Rows[i].Cells[1].Paragraphs[2]
                .Append("_коп. Дата «___» ____________________20___г.").FontSize(11).Font("Times New Roman");
                //примечание
                table.Rows[i].Cells[1].InsertParagraph()
                .Append("*С условиями приема указанной в платежном документе суммы, в т.ч.с суммой " +
                "взимаемой платы за услуги банка, ознакомлен и согласен.\r")
                .FontSize(9).Font("Times New Roman")
                .Alignment = Alignment.left;
                //подпись плательщика
                table.Rows[i].Cells[1].InsertParagraph()
                .Append("Подпись плательщика_________________\r")
                .FontSize(9).Font("Times New Roman").Bold()
                .Alignment = Alignment.right;
                //сбрасываем проходы
                numOfPass = 1;
            }
            document.InsertTable(table);
        }               
        void create_header_graph()
        {
            document.InsertParagraph("\n\nГрафик занятий группы:\n")
            .FontSize(12).Font("Times New Roman").Bold()
            .Alignment = Alignment.center;
        }
        void create_table_graph(bool first)
        {
            if (first == false)
            {
                check_days();
                Table table = document.AddTable(3, 2);
                table.Alignment = Alignment.center;
                table.Design = TableDesign.TableGrid;
                table.AutoFit = AutoFit.Fixed;
                table.SetWidths(new float[] { 125f, 125f });
                //заголовки
                table.Rows[0].Cells[0].Paragraphs[0]
                    .Append("Оплачено")
                    .FontSize(14).Font("Times New Roman")
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;
                table.Rows[0].Cells[1].Paragraphs[0]
                    .Append("Оплата занятий")
                    .FontSize(14).Font("Times New Roman").Bold()
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;
                //даты
                //оплачено
                table.Rows[1].Cells[0].Paragraphs[0]
                    .Append("с " + days[0])
                    .FontSize(14).Font("Times New Roman")
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;
                table.Rows[2].Cells[0].Paragraphs[0]
                    .Append("по " + days[1])
                    .FontSize(14).Font("Times New Roman")
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;
                //оплата за занятия
                table.Rows[1].Cells[1].Paragraphs[0]
                    .Append("с " + days[2])
                    .FontSize(14).Font("Times New Roman")
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;
                table.Rows[2].Cells[1].Paragraphs[0]
                    .Append("по " + days[3])
                    .FontSize(14).Font("Times New Roman")
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;
                //закрашиваем левую часть
                table.Rows[0].Cells[0].FillColor = Color.LightGray;
                table.Rows[1].Cells[0].FillColor = Color.LightGray;
                table.Rows[2].Cells[0].FillColor = Color.LightGray;
                document.InsertTable(table);
            }
            else
            {
                check_days();
                Table table = document.AddTable(3, 1);
                table.Alignment = Alignment.center;
                table.Design = TableDesign.TableGrid;
                table.AutoFit = AutoFit.Fixed;
                table.SetWidths(new float[] { 125f});
                //заголовок
                table.Rows[0].Cells[0].Paragraphs[0]
                    .Append("Оплата занятий")
                    .FontSize(14).Font("Times New Roman").Bold()
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;                
                //даты
                //оплата за занятия
                table.Rows[1].Cells[0].Paragraphs[0]
                    .Append("с " + days[2])
                    .FontSize(14).Font("Times New Roman")
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;
                table.Rows[2].Cells[0].Paragraphs[0]
                    .Append("по " + days[3])
                    .FontSize(14).Font("Times New Roman")
                    .SpacingAfter(2f).SpacingBefore(2f)
                    .Alignment = Alignment.center;
                document.InsertTable(table);
            }
        }

        void create_footer()
        {
            document.InsertParagraph("\n\n\nНапоминаем, что в соответствии" +
                " с договором действует система предварительной оплаты занятий.\n")
            .FontSize(12).Font("Times New Roman")
            .Alignment = Alignment.left;
            document.InsertParagraph("Необходимо оплатить до "+days[2])
            .FontSize(16).Font("Times New Roman").Bold()
            .Alignment = Alignment.left;
            document.InsertParagraph("\rВНИМАНИЕ!")
            .FontSize(11).Font("Times New Roman").Bold().Italic()
            .Alignment = Alignment.left;
            document.Paragraphs[document.Paragraphs.Count-1]
            .Append(" 1.При заполнении квитанции обязательно укажите ФИО плательщика и ребенка.\n")
            .FontSize(11).Font("Times New Roman").Bold().Italic()
            .Alignment = Alignment.left;
            document.Paragraphs[document.Paragraphs.Count - 1]
            .Append("\t\t2.Оплачивая квитанцию через ПАО «Сбербанк России», имейте ввиду, что сумма\n" +
                    "\t\tвзимаемой платы за услуги банка по перечислению средств определяется тарифами\n" +
                    "\t\tбанка, действующими на момент совершения оплаты, и ориентировочно составляет 3%\n" +
                    "\t\tот суммы платежа\n" +
                    "\t\tПри оплате квитанции через онлайн-сервис «Сбербанк Онлайн» сумма взимаемой платы\n" +
                    "\t\tза услуги банка по перечислению средств определяется тарифами банка, действующими\n" +
                    "\t\tна момент совершения оплаты, и ориентировочно составляет 1% от суммы платежа.\n" +
                    "\t\t3.Если вы выбираете другой банк для оплаты квитанции, обязательно уточните у\n" +
                    "\t\tсотрудников банка тарифы на оплату услуги банка по перечислению средств.\n")
            .FontSize(11).Font("Times New Roman").Bold().Italic()
            .Alignment = Alignment.left;

        }

        private void settings_Click(object sender, EventArgs e)
        {
            settings_form stg = new settings_form();
            stg.Show();
        }                

        private void createPayment_Click(object sender, EventArgs e)
        {
            document = DocX.Create(path);
            document.MarginTop = 17.99f;
            document.MarginBottom = 0f;
            document.MarginLeft = 36f;
            document.MarginRight = 42.5f;            
            readSettings();
            create_table_payment();
            create_header_graph();
            if(paySelect.SelectedIndex!=0)
                create_table_graph(false);
            else create_table_graph(true);
            create_footer();
            document.Save();
            Process word = new Process();
            word.StartInfo.FileName = path;
            word.Start();
            Hide();
            word.WaitForExit();
            File.Delete(path);
            Show();
            //Application.Exit();
        }
        private void courseSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            paySelect.Items.Clear();
            countPayments = Convert.ToInt32(payments[courseSelect.SelectedIndex, 2]);
            for (int i = 0; i < countPayments; i++)
            {
                paySelect.Items.Add((i + 1) + "-й платеж");
            }
            paySelect.SelectedIndex = 0;
            payYesGroup.Enabled = false;
        }
        private void paySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paySelect.SelectedItem.ToString() == "1-й платеж")
                payYesGroup.Enabled = false;
            else payYesGroup.Enabled = true;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < payments.GetLength(0); i++)
            {
                courseSelect.Items.Add(payments[i, 0]);
            }
            courseSelect.SelectedIndex = 0;
            countPayments = Convert.ToInt32(payments[courseSelect.SelectedIndex, 2]);
            paySelect.Items.Clear();
            for (int i = 0; i < countPayments; i++)
            {
                paySelect.Items.Add((i + 1) + "-й платеж");
            }
            paySelect.SelectedIndex = 0;
        }
    }
}
