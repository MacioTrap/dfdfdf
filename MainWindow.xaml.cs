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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ITank forcesleft, forcesright;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlockResult1.Text = "";
            if (!Validate())
            {
                MessageBox.Show("Некорректные данные. Введите число ", "Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
             


                int damageLeft = Convert.ToInt32(textBoxDamageTankLeft.Text);
                int hpLeft = Convert.ToInt32(textBoxHealthTankLeft.Text);
                int damageRight = Convert.ToInt32(textBoxDamageTankRight.Text);
                int hpRight = Convert.ToInt32(textBoxHealthTankRight.Text);
                forcesleft.UpdateStats(damageLeft, hpLeft);
                 int newHpLeft, newHpRight;

                forcesright.UpdateStats(damageRight, hpRight);

                
               




                do
                {
                    if (forcesleft.IsLife())
                    {

                        TextBlockResult1.Text += "Результат:"+forcesleft.ToString()+ " атакует " + forcesright.ToString() + "\n\r";
                        newHpRight = forcesright.GetHp() - forcesleft.GetDamage();
                        forcesright.SetHp(newHpRight);

                        if (forcesright.IsLife())
                        {
                            TextBlockResult1.Text += "Результат:"+forcesright.ToString()+ " атакует " + forcesleft.ToString() + "\n\r";
                            //t34.hp = t34.hp - pz4h.damage;
                            newHpLeft = forcesleft.GetHp() - forcesright.GetDamage();
                            //forcesleft.SetHp(newHpLeft);
                        }
                        else
                        {
                            TextBlockResult1.Text += " Выиграл " + forcesleft.ToString() + "\n\r";
                            break;
                        }
                    }
                    else
                    {
                        TextBlockResult1.Text += "Выиграл " + forcesright.ToString() + "\n\r";
                        break;

                    }


                }
                while (true);
            }
        }
        private bool Validate()
        {
            int temp;
            if (int.TryParse(textBoxDamageTankLeft.Text, out temp) &&
                int.TryParse(textBoxDamageTankRight.Text, out temp) &&
                int.TryParse(textBoxHealthTankLeft.Text, out temp) &&
                int.TryParse(textBoxHealthTankRight.Text, out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }













        private void cBoxSelectleft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((System.Windows.Controls.ContentControl)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem).Content.ToString();
            switch (name) {
                case "T34":
                    {
                        forcesleft = new T34();
                        break;
                    }
                case "Pz4H":
                    {
                        forcesleft = new Pz4H();
                        break;
                    }
                case "Is2":
                    {
                        forcesleft = new Is2();
                        break;
                    }
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void cBoxSelectright_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((System.Windows.Controls.ContentControl)((System.Windows.Controls.Primitives.Selector)sender).SelectedItem).Content.ToString();
            switch (name) {

                case "T34":
                    {
                        forcesright = new T34();
                        break;
                    }
                case "Pz4H":
                    {
                        forcesright = new Pz4H();
                        break;
                    }
                case "Is2":
                    {
                        forcesright = new Is2();
                        break;
                    }
            } } }}
