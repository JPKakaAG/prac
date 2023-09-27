using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libmas
{
    public class ArrayUtils
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
    }
}
