using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Task_12_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Regular
        {
            public Regular(string pattern, string txt)
            {
                r = new Regex(pattern);
                text = txt;
            }
            private Regex r;
            private string text;

            public string Match_patter()
            {
                string s = "";
                MatchCollection m = r.Matches(text);
                foreach (Match x in m)
                {
                    s = "Содержит";
                    return s;
                }
                s = "Не содержит";
                return s;
            }

            public string Output_on_display()
            {
                string s = "";
                MatchCollection m = r.Matches(text);
                foreach (Match x in m)
                    s += x.Value;
                return s;
            }

            public string Delete()
            {
                MatchCollection m = r.Matches(text);
                string s = text;
                foreach (Match x in m)
                {
                    int i = s.IndexOf(x.Value);
                    int l = x.Value.Length;
                    s = s.Remove(i, l);
                }
                return s;
            }

            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            public Regex R
            {
                get { return r; }
                set { r = value; }
            }

            public string this[int k]
            {
                get
                {
                    if (k == 0)
                    {
                        return R.ToString();
                    }
                    else if (k == 1)
                    {
                        return text;
                    }
                    else
                        return "Некорректный индекс";
                }
            }
            public static Regular operator -(Regular re)
            {
                MatchCollection m = re.R.Matches(re.text);
                string s = re.text;
                foreach (Match x in m)
                {
                    int i = s.IndexOf(x.Value);
                    int l = x.Value.Length;
                    s = s.Remove(i, l);
                }
                re.text = s;
                return re;
            }
            public static bool operator false(Regular re)
            {
                return re.text.Length == 0;
            }
            public static bool operator true(Regular re)
            {
                return re.text.Length != 0;
            }
            public static Regular operator +(Regular re, string s)
            {
                re.text = re.text + s;
                return re;
            }
            public override string ToString()
            {
                return "Регулярное выражение: " + R + " текст: " + text;
            }
            public static Regular StringToRegular(string s)
            {
                try
                {
                    int a, b;
                    a = s.IndexOf("[");
                    b = s.IndexOf("]");
                    if (a == -1 || b == -1)
                    {
                        throw new Exception("Ошибка преобразования");
                    }

                    string s1 = s.Substring(a + 1, b - a - 1);
                    string s2 = s.Remove(a, b - a + 1);

                    Regular c = new Regular(s1, s2);
                    return c;
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                    return null;
                }
            }
        }
            
        private void button1_Click_1(object sender, EventArgs e)
        {
            string text = "Мальчик проснулся в 11:50, а должен был проснуться в 09:00.";
            textBox1.Text += text;
            string pattern = ("[0-2][0-9]:[0-6][0-9]");
            textBox2.Text += pattern;
            Regular myReg = new Regular(pattern, text);
            if (myReg)
            {
                textBox3.Text += "Строка не пуста";
            }
            else
            {
                textBox3.Text += "Строка пуста";
            }
            textBox4.Text += myReg.ToString();
            Regular myReg2 = Regular.StringToRegular("[19:56] играю на аккордеоне");
            textBox5.Text += myReg2.ToString();
            textBox6.Text += myReg[0];
            textBox7.Text += myReg[1] + "\n\r";
            textBox7.Text += "\n\r"+"Другое значение индекса:" +"\n\r";
            textBox7.Text += myReg[6];
            textBox8.Text += myReg = myReg + "12345";
            textBox9.Text += myReg = -myReg;
        }
    }
}
