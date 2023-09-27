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
using lib_11;

namespace WpfApp2
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

        private void btn_calculate_clk(object sender, RoutedEventArgs e)
        {
            // Получаем ввод пользователя
            string input = InputTb.Text;

            int[] numbers = input.Split(' ')
                                .Select(int.Parse)
                                .ToArray();

            // Вызываем функцию для вычисления разницы чисел
            int difference = variant11.CalculateDifference(numbers);

            // Выводим результат
            MessageBox.Show($"Разница чисел: {difference}", "Результат");
        }
    }
}
