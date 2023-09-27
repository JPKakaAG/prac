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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;
            if (int.TryParse(tb_N.Text, out n) && n > 0)
            {
                int product = GenerateAndMultiplyNumbers(n);
                tb_rez.Text = product.ToString();
            }
            else
            {
                MessageBox.Show("Введите целое положительное число N.");
            }
            int GenerateAndMultiplyNumbers(int x)
            {
                Random random = new Random();
                int[] numbers = new int[x];
                int product = 1;

                for (int i = 0; i < x; i++)
                {
                    numbers[i] = random.Next(0, x);
                    product *= numbers[i];
                }

                tb_Numbers.Text = string.Join(" ", numbers);

                return product;
            }
        }
    }
}
