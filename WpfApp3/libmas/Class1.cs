using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace libmas
{
    public static class ArrayUtils
    {
        // Сохранить массив в файл
        public static void SaveArray(string filename, int[] array)
        {
            /*
            Функция сохраняет массив в файл.

            Аргументы:
            - filename (string): имя файла для сохранения
            - array (int[]): массив для сохранения

            Возвращает:
            - void
            */

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (int element in array)
                {
                    writer.Write(element + ",");
                }
            }
        }

        // Открыть массив из файла
        public static int[] OpenArray(string filename)
        {
            /*
            Функция открывает массив из файла.

            Аргументы:
            - filename (string): имя файла для открытия

            Возвращает:
            - int[]: открытый массив
            */

            string[] values = File.ReadAllText(filename).Split(',');
            int[] array = new int[values.Length - 1]; // вычитаем 1, чтобы убрать последнюю пустую строку

            for (int i = 0; i < values.Length - 1; i++)
            {
                array[i] = int.Parse(values[i]);
            }

            return array;
        }

        // Заполнить массив случайными числами
        public static void FillArrayRandom(int[] array, int size, int minVal, int maxVal)
        {
            /*
            Функция заполняет массив случайными числами.

            Аргументы:
            - array (int[]): массив для заполнения
            - size (int): размер массива
            - minVal (int): минимальное значение случайного числа
            - maxVal (int): максимальное значение случайного числа

            Возвращает:
            - void
            */

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minVal, maxVal + 1);
            }
        }

        // Очистить массив
        public static void ClearArray(int[] array)
        {
            /*
            Функция очищает массив.

            Аргументы:
            - array (int[]): массив для очистки

            Возвращает:
            - void
            */

            Array.Clear(array, 0, array.Length);

        }

        public static void Save2ArrayToFile(int[,] array, string filePath)
        {
            // Создаем новый экземпляр класса StreamWriter для записи в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Получаем размеры массива
                int rows = array.GetLength(0);
                int cols = array.GetLength(1);

                // Записываем размеры массива в первую строку файла
                writer.WriteLine($"{rows},{cols}");

                // Записываем значения элементов массива в оставшиеся строки файла
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.Write($"{array[i, j]} ");
                    }
                    writer.WriteLine();
                }
            }
        }
        public static int[,] Load2ArrayFromFile(string filePath)
        {
            // Создаем новый экземпляр класса StreamReader для чтения из файла
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Читаем первую строку файла, содержащую размеры массива
                string[] size = reader.ReadLine().Split(',');
                int rows = int.Parse(size[0]);
                int cols = int.Parse(size[1]);

                // Создаем новый двумерный массив с заданными размерами
                int[,] array = new int[rows, cols];

                // Читаем оставшиеся строки файла, содержащие значения элементов массива
                for (int i = 0; i < rows; i++)
                {
                    string[] values = reader.ReadLine().Split(' ');
                    for (int j = 0; j < cols; j++)
                    {
                        array[i, j] = int.Parse(values[j]);
                    }
                }

                // Возвращаем загруженный массив
                return array;
            }
            
        }
        public static void Fill2Array(int[,] array)
        {
            // Получаем размеры массива
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            Random rnd = new Random();

            // Заполняем массив заданным значением
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = rnd.Next(0,10);
                }
            }
        }
        public static void Clear2Array(int[,] array)
        {
            // Получаем размеры массива
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            // Очищаем массив, устанавливая все его элементы в ноль
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = 0;
                }
            }
        }
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}
