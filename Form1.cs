using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_1_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void number_btn_click(Button btn)
        {
            textBox1.Text += btn.Text;
        }

        public char GetLastCharacter()
        {
            char last_char;
            if(textBox1.Text != "")
            {
                last_char = textBox1.Text[textBox1.Text.Length - 1];
                return last_char;
            }
            else
            {
                last_char = ' ';
                return last_char;
            }
        }

        public string Rebuild_Wyrazenie_wyjscia(string w)
        {
            var builder = new StringBuilder();
            int count = 0;
            foreach (var c in w)
            {
                builder.Append(c);
                if ((++count % 1) == 0)
                {
                    builder.Append(' ');
                }
            }

            /*
            string rebuild_w = "";

            foreach(char c in w)
            {
                if(c >= '0' && c <= '9')
                {
                    rebuild_w += c;
                }
                else
                {
                    rebuild_w += ' ';
                    rebuild_w += c;
                    rebuild_w += ' ';
                }
            }

            return rebuild_w;
            */
            return builder.ToString();
        }
         
        public bool czy_cyfra(char znak)
        {
            return znak >= '0' && znak <= '9';
        }

        public int str_to_int(string a, int poz)
        {
            int liczba = 0;
            while (poz < a.Length && czy_cyfra(a[poz]))
            {
                //schemat Hornera
                liczba = liczba * 10 + a[poz] - '0';
                poz++;
            }
            poz--;
            return liczba;
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_8);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_7);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_9);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_4);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_5);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_6);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_1);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_2);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_3);
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            number_btn_click(btn_0);
        }

        private void C_btn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void brackets_btn_Click(object sender, EventArgs e)
        {
            if(GetLastCharacter() == '(' || GetLastCharacter() == ' ' || GetLastCharacter() == '+' || GetLastCharacter() == '-' || GetLastCharacter() == '/' || GetLastCharacter() == 'x')
            {
                textBox1.Text += "(";
            }
            else
            {
                textBox1.Text += ")";
            }
        }

        private void divide_btn_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            if(GetLastCharacter() == '/' || GetLastCharacter() == 'x' || GetLastCharacter() == '+' || GetLastCharacter() == '-')
            {
                txt = txt.Remove(textBox1.Text.Length - 1, 1) + "/";
                textBox1.Text = txt;
            }
            else if(GetLastCharacter() == ' ')
            {
                return;
            }
            else
            {
                number_btn_click(divide_btn);
            }
        }

        private void multiply_btn_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text; ;
            if (GetLastCharacter() == '/' || GetLastCharacter() == 'x' || GetLastCharacter() == '+' || GetLastCharacter() == '-')
            {
                txt = txt.Remove(textBox1.Text.Length - 1, 1) + "x";
                textBox1.Text = txt;
            }
            else if (GetLastCharacter() == ' ')
            {
                return;
            }
            else
            {
                number_btn_click(multiply_btn);
            }
        }

        private void substract_btn_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            if (GetLastCharacter() == '/' || GetLastCharacter() == 'x' || GetLastCharacter() == '+' || GetLastCharacter() == '-')
            {
                txt = txt.Remove(textBox1.Text.Length - 1, 1) + "-";
                textBox1.Text = txt;
            }
            else if (GetLastCharacter() == ' ')
            {
                return;
            }
            else
            {
                number_btn_click(substract_btn);
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            if (GetLastCharacter() == '/' || GetLastCharacter() == 'x' || GetLastCharacter() == '+' || GetLastCharacter() == '-')
            {
                txt = txt.Remove(textBox1.Text.Length - 1, 1) + "+";
                textBox1.Text = txt;
            }
            else if (GetLastCharacter() == ' ')
            {
                return;
            }
            else
            {
                number_btn_click(add_btn);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {  
            /*
            string tempwyr = textBox1.Text;
            if (tempwyr[tempwyr.Length - 1] >= 48 && tempwyr[tempwyr.Length - 1] <= 57)
            {
                textBox2.Text = "";
                Stack<char> stos_znakow = new Stack<char>();
                Stack<int> stos_wynikowy = new Stack<int>();
                Stack<int> reverse_stos_wynikowy = new Stack<int>();

                while (stos_wynikowy.Count() != 0)
                {
                    stos_wynikowy.Pop();
                }

                int a, b;

                string wyrazenie = textBox1.Text;
                string wyrazenie_wyjscia = "";
                string wynik = "";
                char znak;


                for (int i = 0; i < wyrazenie.Length; i++)
                {
                    if ((int)wyrazenie[i] >= 48 && (int)wyrazenie[i] <= 57)
                    {
                        if (i != 0)
                        {
                            if (((int)wyrazenie[i - 1] >= 48 && (int)wyrazenie[i - 1] <= 57))
                            {
                                wyrazenie_wyjscia += wyrazenie[i];
                            }
                            else
                            {
                                wyrazenie_wyjscia += ' ';
                                wyrazenie_wyjscia += wyrazenie[i];
                            }
                        }
                        else
                        {
                            wyrazenie_wyjscia += wyrazenie[i];
                        }
                    }
                    else if (wyrazenie[i] == '(')
                    {
                        stos_znakow.Push(wyrazenie[i]);
                    }
                    else if (wyrazenie[i] == '+' || wyrazenie[i] == '-')
                    {
                        if (stos_znakow.Count() != 0)
                        {
                            while (stos_znakow.Peek() == 'x' || stos_znakow.Peek() == '^' || stos_znakow.Peek() == '/' || stos_znakow.Peek() == '+' || stos_znakow.Peek() == '-')
                            {
                                wyrazenie_wyjscia += ' ';
                                wyrazenie_wyjscia += stos_znakow.Peek();
                                stos_znakow.Pop();
                                if (stos_znakow.Count() == 0) break;
                            }
                        }
                        stos_znakow.Push(wyrazenie[i]);
                    }
                    else if (wyrazenie[i] == 'x' || wyrazenie[i] == '/')
                    {
                        if (stos_znakow.Count() != 0)
                        {
                            while (stos_znakow.Peek() == '^' || stos_znakow.Peek() == 'x' || stos_znakow.Peek() == '/')
                            {
                                wyrazenie_wyjscia += ' ';
                                wyrazenie_wyjscia += stos_znakow.Peek();
                                stos_znakow.Pop();
                                if (stos_znakow.Count() == 0) break;
                            }
                        }
                        stos_znakow.Push(wyrazenie[i]);
                    }
                    else if (wyrazenie[i] == '^')
                    {
                        if (stos_znakow.Count() != 0)
                        {
                            while (stos_znakow.Peek() == '^')
                            {
                                wyrazenie_wyjscia += ' ';
                                wyrazenie_wyjscia += stos_znakow.Peek();
                                stos_znakow.Pop();
                                if (stos_znakow.Count() == 0) break;
                            }
                        }
                        stos_znakow.Push(wyrazenie[i]);
                    }
                    else if (wyrazenie[i] == ')')
                    {
                        if (stos_znakow.Count() != 0)
                        {
                            while (stos_znakow.Peek() != '(')
                            {
                                wyrazenie_wyjscia += ' ';
                                wyrazenie_wyjscia += stos_znakow.Peek();
                                stos_znakow.Pop();
                            }
                            stos_znakow.Pop();
                        }
                    }
                }

                while (stos_znakow.Count() != 0)
                {
                    if (stos_znakow.Peek() == '(')
                    {
                        stos_znakow.Pop();
                    }
                    else
                    {
                        wyrazenie_wyjscia += ' ';
                        wyrazenie_wyjscia += stos_znakow.Peek();
                        stos_znakow.Pop();
                    }
                }

                result_txtbox.Text = wyrazenie_wyjscia;

                for (int i = 0; i < wyrazenie_wyjscia.Length; i++)
                {
                    if ((int)wyrazenie_wyjscia[i] >= 48 && (int)wyrazenie_wyjscia[i] <= 57)
                    {
                        int liczba = 0;
                        int j = i;
                        //ZAMIANA PODLANCUCHA NA LICZBE!!! - STACK<INT>
                        while (j < wyrazenie.Length && (int)wyrazenie_wyjscia[j] >= 48 && (int)wyrazenie_wyjscia[j] <= 57)
                        {
                            liczba = liczba * 10 + wyrazenie_wyjscia[j] - '0';
                            j++;
                        }
                        i = j;

                        stos_wynikowy.Push(liczba);
                        label1.Text += stos_wynikowy.Peek().ToString();
                    }
                    else if (wyrazenie_wyjscia[i] == ' ')
                    {
                        continue;
                    }
                    else if (wyrazenie_wyjscia[i] != ' ')
                    {
                        if (stos_wynikowy.Count() < 2)
                        {
                            return;
                        }
                        else
                        {
                            label1.Text += stos_wynikowy.Peek().ToString();
                            a = stos_wynikowy.Peek();
                            stos_wynikowy.Pop();
                            label1.Text += stos_wynikowy.Peek().ToString();
                            b = stos_wynikowy.Peek();
                            stos_wynikowy.Pop();

                            switch (wyrazenie_wyjscia[i])
                            {
                                case '+': stos_wynikowy.Push(b + a); break;
                                case '-': stos_wynikowy.Push(b - a); break;
                                case '/': stos_wynikowy.Push(b / a); break;
                                case 'x': stos_wynikowy.Push(b * a); break;
                            }
                            label1.Text += stos_wynikowy.Peek().ToString();
                        }
                    }
                }

                //while (stos_wynikowy.Count() != 0)
                //{
                //    wynik = stos_wynikowy.Pop().ToString();
                //}

                if (stos_wynikowy.Count() != 1)
                {
                    textBox2.Text = "Syntax error";
                    return;
                }

                wynik = stos_wynikowy.Peek().ToString();

                while (stos_wynikowy.Count() != 0)
                {
                    stos_wynikowy.Pop();
                }

                textBox2.Text = "";
                textBox2.Text = wynik;

            }    
            */
        }

        private void result_btn_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Stack<char> stos_znakow = new Stack<char>();
            Stack<int> stos_wynikowy = new Stack<int>();
            Stack<int> reverse_stos_wynikowy = new Stack<int>();

            while (stos_wynikowy.Count() != 0)
            {
                stos_wynikowy.Pop();
            }

            int a, b;

            string wyrazenie = textBox1.Text;
            string wyrazenie_wyjscia = "";
            string wynik = "";
            char znak;


            for (int i = 0; i < wyrazenie.Length; i++)
            {
                if ((int)wyrazenie[i] >= 48 && (int)wyrazenie[i] <= 57)
                {
                    if (i != 0)
                    {
                        if (((int)wyrazenie[i - 1] >= 48 && (int)wyrazenie[i - 1] <= 57))
                        {
                            wyrazenie_wyjscia += wyrazenie[i];
                        }
                        else
                        {
                            wyrazenie_wyjscia += ' ';
                            wyrazenie_wyjscia += wyrazenie[i];
                        }
                    }
                    else
                    {
                        wyrazenie_wyjscia += wyrazenie[i];
                    }
                }
                else if (wyrazenie[i] == '(')
                {
                    stos_znakow.Push(wyrazenie[i]);
                }
                else if (wyrazenie[i] == '+' || wyrazenie[i] == '-')
                {
                    if (stos_znakow.Count() != 0)
                    {
                        while (stos_znakow.Peek() == 'x' || stos_znakow.Peek() == '^' || stos_znakow.Peek() == '/' || stos_znakow.Peek() == '+' || stos_znakow.Peek() == '-')
                        {
                            wyrazenie_wyjscia += ' ';
                            wyrazenie_wyjscia += stos_znakow.Peek();
                            stos_znakow.Pop();
                            if (stos_znakow.Count() == 0) break;
                        }
                    }
                    stos_znakow.Push(wyrazenie[i]);
                }
                else if (wyrazenie[i] == 'x' || wyrazenie[i] == '/')
                {
                    if (stos_znakow.Count() != 0)
                    {
                        while (stos_znakow.Peek() == '^' || stos_znakow.Peek() == 'x' || stos_znakow.Peek() == '/')
                        {
                            wyrazenie_wyjscia += ' ';
                            wyrazenie_wyjscia += stos_znakow.Peek();
                            stos_znakow.Pop();
                            if (stos_znakow.Count() == 0) break;
                        }
                    }
                    stos_znakow.Push(wyrazenie[i]);
                }
                else if (wyrazenie[i] == '^')
                {
                    if (stos_znakow.Count() != 0)
                    {
                        while (stos_znakow.Peek() == '^')
                        {
                            wyrazenie_wyjscia += ' ';
                            wyrazenie_wyjscia += stos_znakow.Peek();
                            stos_znakow.Pop();
                            if (stos_znakow.Count() == 0) break;
                        }
                    }
                    stos_znakow.Push(wyrazenie[i]);
                }
                else if (wyrazenie[i] == ')')
                {
                    if (stos_znakow.Count() != 0)
                    {
                        while (stos_znakow.Peek() != '(')
                        {
                            wyrazenie_wyjscia += ' ';
                            wyrazenie_wyjscia += stos_znakow.Peek();
                            stos_znakow.Pop();
                        }
                        stos_znakow.Pop();
                    }
                }
            }

            while (stos_znakow.Count() != 0)
            {
                if (stos_znakow.Peek() == '(')
                {
                    stos_znakow.Pop();
                }
                else
                {
                    wyrazenie_wyjscia += ' ';
                    wyrazenie_wyjscia += stos_znakow.Peek();
                    stos_znakow.Pop();
                }
            }

            result_txtbox.Text = wyrazenie_wyjscia;

            for (int i = 0; i < wyrazenie_wyjscia.Length; i++)
            {
                if ((int)wyrazenie_wyjscia[i] >= 48 && (int)wyrazenie_wyjscia[i] <= 57)
                {
                    int liczba = 0;
                    int j = i;
                    //ZAMIANA PODLANCUCHA NA LICZBE!!! - STACK<INT>
                    while((int)wyrazenie_wyjscia[j] >= 48 && (int)wyrazenie_wyjscia[j] <= 57)
                    {
                        liczba = liczba * 10 + wyrazenie_wyjscia[j] - '0';
                        j++;
                    }
                    i = j;

                    stos_wynikowy.Push(liczba);
                    label1.Text += stos_wynikowy.Peek().ToString();
                }   
                else if (wyrazenie_wyjscia[i] == ' ')
                {
                    continue;
                }
                else if (wyrazenie_wyjscia[i] != ' ')
                {
                    if (stos_wynikowy.Count() < 2)
                    {
                        return;
                    }
                    else
                    {
                        label1.Text += stos_wynikowy.Peek().ToString();
                        a = stos_wynikowy.Peek();
                        stos_wynikowy.Pop();
                        label1.Text += stos_wynikowy.Peek().ToString();
                        b = stos_wynikowy.Peek();
                        stos_wynikowy.Pop();

                        switch (wyrazenie_wyjscia[i])
                        {
                            case '+': stos_wynikowy.Push(b + a); break;
                            case '-': stos_wynikowy.Push(b - a); break;
                            case '/': stos_wynikowy.Push(b / a); break;
                            case 'x': stos_wynikowy.Push(b * a); break;
                        }
                        label1.Text += stos_wynikowy.Peek().ToString();
                    }
                }
            }

            //while (stos_wynikowy.Count() != 0)
            //{
            //    wynik = stos_wynikowy.Pop().ToString();
            //}

            if (stos_wynikowy.Count() != 1)
            { 
                textBox2.Text = "Syntax error";
                return;
            }

            wynik = stos_wynikowy.Peek().ToString();

            while (stos_wynikowy.Count() != 0)
            {
                stos_wynikowy.Pop();
            }

            textBox2.Text = "";
            textBox2.Text = wynik;
        }
    }
}
