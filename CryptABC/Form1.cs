using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptABC
{
    public partial class Form1 : Form
    {



        public string input;
        public string output;
        public string c;

        // Самый простой рабочий вариант
        private void ShowCopyableMessage(string text, string title)
        {
            // Создаем новую форму
            Form form = new Form();
            form.Text = title;
            form.Width = 500;
            form.Height = 400;
            form.StartPosition = FormStartPosition.CenterScreen;

            // Создаем TextBox
            TextBox textBox = new TextBox();
            textBox.Text = text;
            textBox.Multiline = true;
            textBox.ReadOnly = true;
            textBox.ScrollBars = ScrollBars.Both;
            textBox.Width = 480;
            textBox.Height = 320;
            textBox.Location = new Point(10, 10);

            // Создаем кнопку OK
            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Width = 80;
            btnOK.Location = new Point(210, 340);
            btnOK.Click += (s, e) => form.Close();

            // Создаем кнопку Копировать
            Button btnCopy = new Button();
            btnCopy.Text = "Копировать";
            btnCopy.Width = 120;
            btnCopy.Location = new Point(80, 340);
            btnCopy.Click += (s, e) =>
            {
                Clipboard.SetText(textBox.Text);
                
            };

            // Добавляем элементы на форму
            form.Controls.Add(textBox);
            form.Controls.Add(btnOK);
            form.Controls.Add(btnCopy);

            // Показываем форму
           
            form.Show(this);
        }


        public Form1()
        {


            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox(object sender, EventArgs e)            //ввод для зашифровки. поле ввода
        {

            input = textBox1.Text;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Нет данных для обработки");
                return;
            }
            var lowerReplacements = new Dictionary<char, string>
        {
            {'а', "шрм"}, {'б', "љпдђ"}, {'в', "дин"}, {'г', "екцш"},
            {'д', "њпђ"}, {'е', "џжр"}, {'ё', "тзцњ"}, {'ж', "емс"},
            {'з', "добм"}, {'и', "елв"}, {'й', "длпњ"}, {'к', "шћа"},
            {'л', "љђжњ"}, {'м', "епм"}, {'н', "флмђ"}, {'о', "дфо"},
            {'п', "рђџљ"}, {'р', "њпм"}, {'с', "ћпкм"}, {'т', "њђц"},
            {'у', "имђњ"}, {'ф', "епђ"}, {'х', "мепф"}, {'ц', "оје"},
            {'ч', "икчп"}, {'ш', "њкд"}, {'щ', "елмс"}, {'ъ', "екд"},
            {'ы', "рлмс"}, {'ь', "ађд"}, {'э', "Eађд"}, {'ю', "опт"},
            {'я', "љћђњ"}, {'?', "Лшлђњ"}, {'!', "Сђдоп"}, {'.', "Јнски"},
            {'1', "ир"}, {'2', "њи"}, {'3', "ке"}, {'4', "лд"},
            {'5', "чп"}, {'6', "џл"}, {'7', "њђ"}, {'8', "до"},
            {'9', "ме"}, {'0', "шљ"}


        };


            // Словарь для заглавных букв
            var upperReplacements = new Dictionary<char, string>
        {
            {'А', "шрм"}, {'Б', "љпдђ"}, {'В', "дин"}, {'Г', "екцш"},
            {'Д', "њпђ"}, {'Е', "џжр"}, {'Ё', "тзцњ"}, {'Ж', "емс"},
            {'З', "добм"}, {'И', "елв"}, {'Й', "длпњ"}, {'К', "шћа"},
            {'Л', "љђжњ"}, {'М', "епм"}, {'Н', "флмђ"}, {'О', "дфо"},
            {'П', "рђџљ"}, {'Р', "њпм"}, {'С', "ћпкм"}, {'Т', "њђц"},
            {'У', "имђњ"}, {'Ф', "епђ"}, {'Х', "мепф"}, {'Ц', "оје"},
            {'Ч', "икчп"}, {'Ш', "њкд"}, {'Щ', "елмс"}, {'Ъ', "екд"},
            {'Ы', "рлмс"}, {'Ь', "ађд"}, {'Э', "Eађд"}, {'Ю', "опт"},
            {'Я', "љћђњ"}, {'?', "Лшлђњ"}, {'!', "Сђдоп"}, {'.', "Јнски"},
            {'1', "ир"}, {'2', "њи"}, {'3', "ке"}, {'4', "лд"},
            {'5', "чп"}, {'6', "џл"}, {'7', "њђ"}, {'8', "до"},
            {'9', "ме"}, {'0', "шљ"}
        };
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (lowerReplacements.TryGetValue(c, out string lowerReplacement))
                {
                    sb.Append(lowerReplacement);
                }
                else if (upperReplacements.TryGetValue(c, out string upperReplacement))
                {
                    sb.Append(upperReplacement);
                }
                else
                {
                    sb.Append(c);
                }
            }
            string result = sb.ToString();
            ShowCopyableMessage(result, "");



        }



        private void textBox_2(object sender, EventArgs e)          //ввод для расшифровки. поле ввода
        {
            output = textBox2.Text;

        }

        private void button_2(object sender, EventArgs e)
        {
            var lowerReplacements = new Dictionary<string, char>
        {
            {"шрм",'а'}, { "љпдђ",'б'}, { "дин",'в'}, { "екцш",'г'},
            { "њпђ", 'д'}, { "џжр",'е'}, { "тзцњ",'ё'}, { "емс",'ж'},
            { "добм",'з'}, { "елв",'и'}, { "длпњ",'й'}, { "шћа",'к'},
            { "љђжњ",'л'}, { "епм",'м'}, { "флмђ",'н'}, { "дфо",'о'},
            { "рђџљ",'п'}, { "њпм",'р'}, { "ћпкм",'с'}, { "њђц",'т'},
            { "имђњ",'у'}, { "епђ",'ф'}, { "мепф",'х'}, { "оје",'ц'},
            { "икчп",'ч'}, { "њкд",'ш'}, { "елмс",'щ'}, { "екд",'ъ'},
            { "рлмс",'ы'}, { "ађд",'ь'}, { "Eађд",'э'}, { "опт",'ю'},
            { "љћђњ",'я'}, { "Лшлђњ",'?'}, { "Сђдоп",'!'}, { "Јнски",'.'},
            { "ир",'1'}, { "њи",'2'}, { "ке",'3'}, { "лд",'4'},
            { "чп",'5'}, { "џл",'6'}, { "њђ",'7'}, { "до",'8'},
            { "ме",'9'}, { "шљ",'0'}


        };
            if (string.IsNullOrEmpty(output))
            {
                MessageBox.Show("Нет данных для обработки");
                return;
            }
            string result = output;
            foreach (var replacement in lowerReplacements)
            {
                result = result.Replace(replacement.Key, replacement.Value.ToString());
            }
            ShowCopyableMessage(result, "");

        }

    }

}