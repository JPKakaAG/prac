using System;
using System.Collections.Generic;
using System.Data;
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
using libmas;


namespace WpfApp3
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

        private void btn_rez_click(object sender, RoutedEventArgs e)
        {
            int rows, cols;
            if (int.TryParse(TBrows.Text, out rows) && int.TryParse(TBcols.Text, out cols))
            {
                int[,] myArray = new int[rows, cols];
                ArrayUtils.Fill2Array(myArray);
                DG.ItemsSource = ArrayUtils.ToDataTable(myArray).DefaultView;
                MessageBox.Show("максимальный среди минимальных элементов:" + v11.FindMaxAmongMin(myArray));
            }
            else
            {
                MessageBox.Show("Введите корректный размер массива.");
            }
        }
        
    }
    
}
