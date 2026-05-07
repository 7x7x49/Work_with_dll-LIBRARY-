using System;
using System.IO;
using System.Threading;

// Делегат для обратного вызова – передача результатов в функцию tcallRes
public delegate void ThreadCallBack(int cNN, int cTH, double[] cXT, double[] cYT, double[,] cZT);

// Класс, содержащий рабочую функцию потока
public class ThreadWithState
{
    // Приватные поля для хранения параметров и массивов
    private double
        sMaxX, sMinX, sMaxY, sMinY, // Максимальные и минимальные значения аргументов
        sShagX, sShagY;             // Шаги изменения аргументов X и Y

    private double[] sXT, sYT;      // Массивы аргументов X и Y
    private double[,] sZT;          // Массив значений функции Z
    private int sNN, I, J, sTH;     // Размерность, счётчики, номер потока
    private ThreadCallBack tcall;   // Объект делегата

    // Общий мьютекс для синхронизации доступа к общему файлу A_T.txt
    private static Mutex mutex = new Mutex();

    // Конструктор класса
    public ThreadWithState(int zNN, double zMinX, double zMaxX, double zMinY, double zMaxY, int zTH, ThreadCallBack tcallD)
    {
        sNN = zNN;          // Размерность массивов
        sMinX = zMinX;      // Минимальное значение X
        sMaxX = zMaxX;      // Максимальное значение X
        sMinY = zMinY;      // Минимальное значение Y
        sMaxY = zMaxY;      // Максимальное значение Y
        sTH = zTH;          // Номер потока
        tcall = tcallD;     // Сохраняем ссылку на делегат
    }

    // Рабочая функция потока
    public void ThreadDoWork()
    {
        // Выделение памяти для массивов
        sXT = new double[sNN];
        sYT = new double[sNN];
        sZT = new double[sNN, sNN];

        // Модифицируем диапазон X: прибавляем номер потока к максимальному значению
        double currentMaxX = sMaxX + sTH; // Увеличиваем maxX на номер потока
        double currentMinX = sMinX;       // Минимум не меняем

        // Вычисление шагов
        sShagX = (currentMaxX - currentMinX) / (sNN - 1);
        sShagY = (sMaxY - sMinY) / (sNN - 1);

        // Первые элементы массивов
        sXT[0] = currentMinX;
        sYT[0] = sMinY;

        // Формирование массивов аргументов
        I = 1;
        while (I <= sNN - 1)
        {
            sXT[I] = sXT[I - 1] + sShagX;
            sYT[I] = sYT[I - 1] + sShagY;
            I++;
        }

        // Вычисление значений функции z = e^x * sqrt(1 - e^(2x)) + arcsin(y)
        I = 0;
        while (I <= sNN - 1)
        {
            J = 0;
            while (J <= sNN - 1)
            {
                sZT[I, J] = Math.Exp(sXT[I]) * Math.Sqrt(1 - Math.Exp(2 * sXT[I])) + Math.Asin(sYT[J]);
                J++;
            }
            I++;
        }

        // Вызов делегата – создание файла A_cb_номер.txt
        tcall(sNN, sTH, sXT, sYT, sZT);

        mutex.WaitOne(); // Захват мьютекса (доступ к разделяемому ресурсу)
        try
        {
            // Открытие файла A_T.txt в режиме дозаписи (true) с кодировкой по умолчанию
            using (StreamWriter sw = new StreamWriter("D://A_T.txt", true, System.Text.Encoding.Default))
            {
                // Запись заголовка с номером потока
                sw.WriteLine($"Поток {sTH}:");

                // Вывод массива X
                sw.Write("PXT: ");
                for (int i = 0; i < sNN; i++) sw.Write(sXT[i] + "; ");

                // Вывод массива Y
                sw.Write("\nPYT: ");
                for (int i = 0; i < sNN; i++) sw.Write(sYT[i] + "; ");

                // Вывод матрицы Z
                sw.Write("\nPZT:\n");
                for (int i = 0; i < sNN; i++)
                {
                    for (int j = 0; j < sNN; j++)
                        sw.Write(sZT[i, j] + "; ");
                    sw.WriteLine();
                }
                sw.WriteLine("--------------------------------------"); // Разделитель между потоками
            }
        }
        finally
        {
            mutex.ReleaseMutex(); // Освобождение мьютекса
        }
    }
}