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

        private void ShowCopyableMessage(string text, string title)
        {
            Form form = new Form();
            form.Text = title;
            form.Width = 500;
            form.Height = 400;
            form.StartPosition = FormStartPosition.CenterScreen;

            TextBox textBox = new TextBox();
            textBox.Text = text;
            textBox.Multiline = true;
            textBox.ReadOnly = true;
            textBox.ScrollBars = ScrollBars.Both;
            textBox.Width = 480;
            textBox.Height = 320;
            textBox.Location = new Point(10, 10);

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Width = 80;
            btnOK.Location = new Point(210, 340);
            btnOK.Click += (s, e) => form.Close();

            Button btnCopy = new Button();
            btnCopy.Text = "Копировать";
            btnCopy.Width = 120;
            btnCopy.Location = new Point(80, 340);
            btnCopy.Click += (s, e) =>
            {
                Clipboard.SetText(textBox.Text);
                
            };

            form.Controls.Add(textBox);
            form.Controls.Add(btnOK);
            form.Controls.Add(btnCopy);

           
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
            {'а', "шрмљ"}, {'б', "љпдђ"}, {'в', "динр"}, {'г', "екцш"},
            {'д', "њпђа"}, {'е', "џжрс"}, {'ё', "тзцњ"}, {'ж', "емсз"},
            {'з', "добмџ"}, {'и', "елвљ"}, {'й', "длпњ"}, {'к', "шћао"},
            {'л', "љђжњ"}, {'м', "епмс"}, {'н', "флмђ"}, {'о', "дфој"},
            {'п', "рђџљ"}, {'р', "њпма"}, {'с', "ћпкм"}, {'т', "њђцл"},
            {'у', "имђњ"}, {'ф', "епђс"}, {'х', "мепф"}, {'ц', "ојес"},
            {'ч', "икчп"}, {'ш', "њкдс"}, {'щ', "елмс"}, {'ъ', "екдз"},
            {'ы', "рлмс"}, {'ь', "ађдџ"}, {'э', "Eађд"}, {'ю', "оптп"},
            {'я', "љћђњ"}, {'?', "Лшлђњ"}, {'!', "Сђдоп"}, {'.', "Јнски"},
            {'1', "ирљњ"}, {'2', "њиас"}, {'3', "кеѕџ"}, {'4', "лдрт"},
            {'5', "чптз"}, {'6', "џлуп"}, {'7', "њђју"}, {'8', "доћхг"},
            {'9', "мефм"}, {'0', "шљцб"}


        };


            // Словарь для заглавных букв
            var upperReplacements = new Dictionary<char, string>
        {
            {'А', "шрмљ"}, {'Б', "љпдђ"}, {'В', "динр"}, {'Г', "екцш"},
            {'Д', "њпђа"}, {'Е', "џжрс"}, {'Ё', "тзцњ"}, {'Ж', "емсз"},
            {'З', "добмџ"}, {'И', "елвљ"}, {'Й', "длпњ"}, {'К', "шћао"},
            {'Л', "љђжњ"}, {'М', "епмс"}, {'Н', "флмђ"}, {'О', "дфој"},
            {'П', "рђџљ"}, {'Р', "њпма"}, {'С', "ћпкм"}, {'Т', "њђцл"},
            {'У', "имђњ"}, {'Ф', "епђс"}, {'Х', "мепф"}, {'Ц', "ојес"},
            {'Ч', "икчп"}, {'Ш', "њкдс"}, {'Щ', "елмс"}, {'Ъ', "екдз"},
            {'Ы', "рлмс"}, {'Ь', "ађдџ"}, {'Э', "Eађд"}, {'Ю', "оптп"},
            {'Я', "љћђњ"}, {'?', "Лшлђњ"}, {'!', "Сђдоп"}, {'.', "Јнски"},
            {'1', "ирљњ"}, {'2', "њиас"}, {'3', "кеѕџ"}, {'4', "лдрт"},
            {'5', "чптз"}, {'6', "џлуп"}, {'7', "њђју"}, {'8', "доћхг"},
            {'9', "мефм"}, {'0', "шљцб"}
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
            {"шрмљ",'а'}, { "љпдђ",'б'}, { "динр",'в'}, { "екцш",'г'},
            { "њпђа", 'д'}, { "џжрс",'е'}, { "тзцњ",'ё'}, { "емсз",'ж'},
            { "добмџ",'з'}, { "елвљ",'и'}, { "длпњ",'й'}, { "шћао",'к'},
            { "љђжњ",'л'}, { "епмс",'м'}, { "флмђ",'н'}, { "дфој",'о'},
            { "рђџљ",'п'}, { "њпма",'р'}, { "ћпкм",'с'}, { "њђцл",'т'},
            { "имђњ",'у'}, { "епђс",'ф'}, { "мепф",'х'}, { "ојес",'ц'},
            { "икчп",'ч'}, { "њкдс",'ш'}, { "елмс",'щ'}, { "екдз",'ъ'},
            { "рлмс",'ы'}, { "ађдџ",'ь'}, { "Eађд",'э'}, { "оптп",'ю'},
            { "љћђњ",'я'}, { "Лшлђњ",'?'}, { "Сђдоп",'!'}, { "Јнски",'.'},
            { "ирљњ",'1'}, { "њиас",'2'}, { "кеѕџ",'3'}, { "лдрт",'4'},
            { "чптз",'5'}, { "џлуп",'6'}, { "њђју",'7'}, { "доћхг",'8'},
            { "мефм",'9'}, { "шљцб",'0'}


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