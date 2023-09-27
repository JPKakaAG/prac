using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_11
{
    public class v11
    {
        public static int FindMaxAmongMin(int[,] array)
        {
            int rowCount = array.GetLength(0); // Количество строк
            int colCount = array.GetLength(1); // Количество столбцов

            int maxAmongMin = int.MinValue; // Начальное значение максимального элемента

            for (int i = 0; i < rowCount; i++)
            {
                int minInRow = int.MaxValue; // Начальное значение минимального элемента в строке

                for (int j = 0; j < colCount; j++)
                {
                    if (array[i, j] < minInRow)
                    {
                        minInRow = array[i, j]; // Обновление минимального элемента в строке
                    }
                }

                if (minInRow > maxAmongMin)
                {
                    maxAmongMin = minInRow; // Обновление максимального элемента
                }
            }

            return maxAmongMin;
        }
    }
}
