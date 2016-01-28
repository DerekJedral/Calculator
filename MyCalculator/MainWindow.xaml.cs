using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool shift = false;
        string eq;
        string num;
        bool flag = false;
        bool flag2 = false;
        public MainWindow()
        {
            InitializeComponent();
            eq = "";
            num = "";
            flag = false;
        }

        public double calculate(string s)
        {
            double val=0;
            char presymbol = ' ';
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    int bracketcount=1;
                    for (int j=i; j<s.Length; j++)
                    {
                        if (s[j] == '(')
                            bracketcount++;

                        if (s[j] == ')')
                            bracketcount--;

                        if (bracketcount==0)
                        {
                            if (presymbol==' ')
                                val = calculate(s.Substring(i + 1, j - i));
                            if (presymbol == '+')
                                val = val + calculate(s.Substring(i + 1, j - i));
                            if (presymbol == '*')
                                val = val * calculate(s.Substring(i + 1, j - i));
                            if (presymbol == '-')
                                val = val - calculate(s.Substring(i + 1, j - i));
                            if (presymbol == '/')
                                val = val / calculate(s.Substring(i + 1, j - i));
                            
                            i = j;
                            break;
                        }
                    }
                }

                if (s[i] >= '0' && s[i] <= '9')
                    val = val * 10 + Convert.ToInt32(s[i] - '0');


                if (s[i] == '.')
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {

                        if (s[j] >= '0' && s[j] <= '9')
                            val = val + Convert.ToInt32(s[j] - '0') * Math.Pow(10, (i - j));

                        else
                        {
                            i = j;
                            break;
                        }
                        if (j == s.Length - 1)
                        {
                            i = j;
                            break;
                        }
                    }
                }

                if (s[i] == '+')
                {
                    val = val + calculate(s.Substring(i + 1));
                    presymbol = s[i];
                    break;
                }

                if (s[i] == '-')
                {
                    val = val - calculate(s.Substring(i + 1));
                    presymbol = s[i];
                    break;
                }

                if (s[i] == '^')
                {
                    presymbol = s[i];
                    double next = 0;
                    bool breakflag = false;

                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (j == i + 1)
                        {
                            while (s[j] == ' ')
                                j++;
                        }
                        Console.WriteLine("s[j] is " + s[j] +" and s[i] is " + s[i]);
                        if (s[j] == '(')
                        {
                            Console.WriteLine("Entering bracket");
                            int bracketcount = 1;
                            for (int k = j + 1; k < s.Length; k++)
                            {
                                if (s[k] == '(')
                                    bracketcount++;

                                if (s[k] == ')')
                                    bracketcount--;

                                if (bracketcount == 0)
                                {
                                    next = calculate(s.Substring(j + 1, k - j));
                                    j = k;
                                    breakflag = true;
                                    break;
                                }
                            }

                            i = j;
                            if (breakflag == true) break;
                        }

                        if (s[j] >= '0' && s[j] <= '9')
                            next = next * 10 + Convert.ToInt32(s[j] - '0');


                        else if (s[j] == '.')
                        {
                            for (int k = j + 1; k < s.Length; k++)
                            {

                                if (s[k] >= '0' && s[k] <= '9')
                                    val = val + Convert.ToInt32(s[k] - '0') * Math.Pow(10, (j - k));

                                else
                                {
                                    j = k;
                                    break;
                                }

                                if (k == s.Length - 1)
                                {
                                    j = k;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            i = j;
                            break;
                        }

                        if (j == s.Length - 1)
                        {
                            i = j;
                            break;
                        }
                    }

                    val = Math.Pow(val , next);
                }

                if (s[i] == '*')
                {
                    presymbol = s[i];
                    double next = 0;
                    bool breakflag=false;

                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (j == i + 1)
                        {
                            while (s[j] == ' ')
                                j++;
                        }

                        if (s[j] == '(')
                        {
                            int bracketcount = 1;
                            for (int k = j+1; k < s.Length; k++)
                            {
                                if (s[k] == '(')
                                    bracketcount++;

                                if (s[k] == ')')
                                    bracketcount--;

                                if (bracketcount == 0)
                                {
                                    next = calculate(s.Substring(j+1, k-j));
                                    j = k;
                                    breakflag=true;
                                    break;
                                }                                
                            }
                            
                            i = j;
                            if (breakflag==true) break;
                        }

                        if (s[j] >= '0' && s[j] <= '9')
                            next = next * 10 + Convert.ToInt32(s[j] - '0');
                        

                        else if (s[j] == '.')
                        {
                            for (int k = j + 1; k < s.Length; k++)
                            {

                                if (s[k] >= '0' && s[k] <= '9')
                                    val = val + Convert.ToInt32(s[k] - '0') * Math.Pow(10, (j - k));

                                else
                                {
                                    j = k;
                                    break;
                                }

                                if (k == s.Length - 1)
                                {
                                    j = k;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            i = j;
                            break;
                        }

                        if (j == s.Length - 1)
                        {
                            i = j;
                            break;
                        }
                    }

                    val = val * next;
                }

                if (s[i] == '/')
                {
                    presymbol = s[i];
                    double next = 0;
                    bool breakflag = false;

                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (j == i + 1)
                        {
                            while (s[j] == ' ')
                                j++;
                        }

                        if (s[j] == '(')
                        {
                            int bracketcount = 1;
                            for (int k = j + 1; k < s.Length; k++)
                            {
                                if (s[k] == '(')
                                    bracketcount++;

                                if (s[k] == ')')
                                    bracketcount--;

                                if (bracketcount == 0)
                                {
                                    next = calculate(s.Substring(j + 1, k - j));
                                    j = k;
                                    breakflag = true;
                                    break;
                                }
                            }

                            i = j;

                            if (breakflag == true) break;
                        }

                        if (s[j] >= '0' && s[j] <= '9')
                            next = next * 10 + Convert.ToInt32(s[j] - '0');


                        else if (s[j] == '.')
                        {
                            for (int k = j + 1; k < s.Length; k++)
                            {

                                if (s[k] >= '0' && s[k] <= '9')
                                    val = val + Convert.ToInt32(s[k] - '0') * Math.Pow(10, (j - k));

                                else
                                {
                                    j = k;
                                    break;
                                }

                                if (k == s.Length - 1)
                                {
                                    j = k;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            i = j;
                            break;
                        }

                        if (j == s.Length - 1)
                        {
                            i = j;
                            break;
                        }
                    }

                    val = val / next;
                }
            }

            return val;
        }

        public void addSymbol(char c)
        {
            if (c == '=')
            {
                double final = calculate(eq);
                flag = false;
                flag2 = true;
                num = Convert.ToString(final);
            }

            else
            {
                if (eq == "")
                    num = "";
                if ((c < '0' || c > '9') && c != '.')
                {
                    eq = eq + " " + c + " ";
                    num = "";
                    flag = true;
                }

                else
                {
                    flag = false;
                    eq = eq + c;
                    num = num + c;
                }
            }
            if (flag2 == false)
                this.DisplayLine.Text = eq;
            else
            {
                flag2 = false;
                eq = "";
            }
            if (flag == false)
                this.MainDisplay.Text = num;
        }
        public void buttonClick(object sender, RoutedEventArgs e)
        { 
            var bt = (sender as Button);
            addSymbol(Convert.ToString(bt.Content)[0]);
            
        }

        public void checkShift(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                shift = false;
        }
        public void keyInput(object sender, KeyEventArgs e)
        {
            Key key = e.Key;
            switch (key)
            {
                case Key.LeftShift: shift = true; break;
                case Key.RightShift: shift = true; break;

                case Key.D1: addSymbol('1'); break;
                case Key.NumPad1: addSymbol('1'); break;
                case Key.D2: addSymbol('2'); break;
                case Key.NumPad2: addSymbol('2'); break;
                case Key.D3: addSymbol('3'); break;
                case Key.NumPad3: addSymbol('3'); break;
                case Key.D4: addSymbol('4'); break;
                case Key.NumPad4: addSymbol('4'); break;
                case Key.D5: addSymbol('5'); break;
                case Key.NumPad5: addSymbol('5'); break;
                case Key.D6:
                    if (shift)
                        addSymbol('^');
                    else
                        addSymbol('6');
                    break;
                case Key.NumPad6: addSymbol('6'); break;
                case Key.D7: addSymbol('7'); break;
                case Key.NumPad7: addSymbol('7'); break;
                case Key.D8:
                    if (shift)
                        addSymbol('*');
                    else
                        addSymbol('8');
                    break;
                case Key.NumPad8: addSymbol('8'); break;
                case Key.D9: addSymbol('9'); break;
                case Key.NumPad9: addSymbol('9'); break;
                case Key.D0: addSymbol('0'); break;
                case Key.NumPad0: addSymbol('0'); break;

                case Key.Add: addSymbol('+'); break;
                case Key.OemPlus: 
                    if (shift)
                        addSymbol('+');
                    else
                        addSymbol('=');
                    break;
                case Key.Subtract: addSymbol('-'); break;
                case Key.OemMinus: addSymbol('-'); break;
                case Key.Multiply: addSymbol('*'); break;
                case Key.Divide: addSymbol('/'); break;
                case Key.OemQuestion: addSymbol('/'); break;
                case Key.Decimal: addSymbol('.'); break;
                case Key.OemPeriod: addSymbol('.'); break;
                case Key.OemOpenBrackets: addSymbol('('); break;
                case Key.OemCloseBrackets: addSymbol(')'); break;
                
            }
        }
    }
}
