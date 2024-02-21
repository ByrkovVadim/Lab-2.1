using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Number num = new Number();

        int k = 13; // k

        //int alf = 33; //Мощность алфавита

        string[] alphabet = new [] { "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", 
                                     "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", 
                                     "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я", " "};
        int[] oint = new int[0]; //Массивы для O (Порядковые номера чисел)
        string[] ostr = new string[0];

        int[] gamint = new int[0]; // Массивы для гаммы
        string[] gamstr = new string[0];

        int[] cint = new int[0]; // C
        string[] cstr = new string[0];

        int[] cgint = new int[0]; // c-j
        string[] cgstring = new string[0];

        string[] discrypt = new string[0];

        private void button1_Click(object sender, EventArgs e)
        {
            String strinput = textBox1.Text;

            char[] W = strinput.ToArray(); // Слово преобразуется в символы

            Array.Resize(ref oint, W.Length);
            Array.Resize(ref ostr, W.Length);

            Array.Resize(ref gamint, W.Length);
            Array.Resize(ref gamstr, W.Length);

            Array.Resize(ref cint, W.Length);
            Array.Resize(ref cstr, W.Length);

            Array.Resize(ref cgint, W.Length);
            Array.Resize(ref cgstring, W.Length);

            Array.Resize(ref discrypt, W.Length);


            for (int i = 0; i < W.Length; i++) //Заполнение массива gamint порядковыми номерами символов
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (alphabet[j] == Convert.ToString(W[i]))
                    {
                        oint[i] = j;
                        break;
                    }
                }
            }
            for(int i = 0; i < oint.Length; i++) //Преобразование int в string
            {
                ostr[i] = Convert.ToString(oint[i]);
            }
            listBox1.Items.AddRange(ostr); // Вывод О


            for (int i = 0; i < W.Length; i++) // Гамма
            {

                //double j = (Math.Pow(k, i+1)) % alphabet.Length;
                long j = num.PonigenieSt(i+1, alphabet.Length-1, k);

                gamint[i] = Convert.ToInt32(j); // Запись значения J в массив
                gamstr[i] = Convert.ToString(gamint[i]); //Преобразование int в string
            }
            listBox2.Items.AddRange(gamstr); //Вывод гаммы

 
            for (int i = 0; i < gamstr.Length; i++) // C
            {
                double c = (oint[i] + gamint[i]) % alphabet.Length;

                cint[i] = Convert.ToInt32(c);
                cstr[i] = Convert.ToString(c);
            }
            listBox3.Items.AddRange(cstr); //Вывод С
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < cgint.Length; i++)
            {
                cgint[i] = cint[i] - gamint[i];
                if (cgint[i] < 0)
                {
                    cgint[i] = cgint[i] + alphabet.Length;
                }
                cgstring[i] = Convert.ToString(cgint[i]);
            }
            listBox4.Items.AddRange(cgstring); //Вывод С-G

            for(int i = 0; i < discrypt.Length; i++)
            {
                discrypt[i] = alphabet[cgint[i]];
                textBox2.Text += discrypt[i];
            }
            
        }

        private void button3_Click(object sender, EventArgs e) //Очистка
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            textBox1.Clear();
            textBox2.Clear();
        }

        /////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////// РАСШИФРОВКА
        /////////////////////////////////////////////////////////////


        string[] c_keystr = new string[1];
        int[] int_keystr = new int[1];
        int I = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                MessageBox.Show(" Недопустимый формат данных !");
            }
            else 
            {
                c_keystr[I] = textBox3.Text;

                int_keystr[I] = Convert.ToInt32(c_keystr[I]);


                listBox5.Items.Clear();
                listBox5.Items.AddRange(c_keystr); // Вывод блоков в listbox
                textBox3.Clear();

                I++;
                Array.Resize(ref c_keystr, I + 1);
                Array.Resize(ref int_keystr, I + 1);
            }
            
        }

        private void button5_Click(object sender, EventArgs e) //Сброс
        {
            I = 0; 
            listBox5.Items.Clear();
            textBox3.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
           
            Array.Clear(c_keystr, 0, c_keystr.Length);
            Array.Resize(ref c_keystr, 1);

            Array.Clear(int_keystr, 0, int_keystr.Length);
            Array.Resize(ref int_keystr, 1);
        }

        


        private void button6_Click(object sender, EventArgs e)
        {
            
            for (int jk = 1; jk < 30; jk++) // k от 1 до 30
            {
                int[] message = new int[int_keystr.Length];
                string[] gamma_str = new string[int_keystr.Length - 1];

                int[] message_int = new int[int_keystr.Length -1];
                string[] messagestr = new string[int_keystr.Length - 1];

                for (int i = 0; i < c_keystr.Length-1; i++) // Расшифровка сообщений
                {
                    //double J = (Math.Pow(jk, i + 1)) % alphabet.Length-1; // Расчёт гаммы
                    long J = num.PonigenieSt(i + 1, alphabet.Length - 1, jk);

                    message[i] = Convert.ToInt32(J); 
                    gamma_str[i] = Convert.ToString(message[i]); // Заполнение массива gamma_str значениями гаммы

                    message_int[i] = int_keystr[i] - message[i]; // c - j
                    
                    if (message_int[i] < 0)
                    {
                        message_int[i] = message_int[i] + alphabet.Length;
                    }

                    messagestr[i] = Convert.ToString(alphabet[message_int[i]]);

                }

                //Расчёт периода гаммы
                int I = 0;
                int return_I = 0; // Период гаммы
                bool flag = true;
                int[] gammaperiod = new int[1]; 
                while(flag == true)
                {
                    double J = (Math.Pow(jk, I + 1)) % alphabet.Length-1;
                    //long J = num.PonigenieSt(I+1, alphabet.Length-1, jk);
                    gammaperiod[I] = Convert.ToInt32(J);
                    if(I != 0)
                    {
                        for (int i = 0; i < gammaperiod.Length-1; i++)
                        {
                            if (gammaperiod[i] == gammaperiod[I])
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    return_I = I; // Вывод гаммы
                    I++;
                    Array.Resize(ref gammaperiod, I+1);
                }

                

                string result = String.Concat(messagestr);

                listBox6.Items.Add("К=" + Convert.ToString(jk));
                listBox6.Items.Add(result);
                listBox6.Items.Add("");

                listBox7.Items.Add("К=" + Convert.ToString(jk));
                listBox7.Items.AddRange(gamma_str);
                listBox7.Items.Add("Период гаммы="+ Convert.ToString(return_I));
                listBox7.Items.Add("");

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(groupBox1.Enabled == false)
            {
                groupBox1.Enabled = true;
                button7.Text = "Деактивировать";
            }
            else 
            {
                groupBox1.Enabled = false;
                button7.Text = "Активировать";
            }
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            if (groupBox2.Enabled == false)
            {
                groupBox2.Enabled = true;
                button8.Text = "Деактивировать";
            }
            else
            {
                groupBox2.Enabled = false;
                button8.Text = "Активировать" +
                    "";
            }
        }
    }
}
