using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LibraryCS
{
    public partial class ClassDllForm1 : Form
    {
        // Конструктор
        public ClassDllForm1()
        {
            InitializeComponent();

            // Подписка на событие закрытия формы
            FormClosing += ClassDllForm1_FormClosing;

            // Явное включение таймера и подписка на событие 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;

            // Подписка на кнопку "Закрыть"
            button1.Click += button1_Click;
        }

        // Атрибуты для работы с потоками
        public int I, J;
        public ThreadWithState[] tstat;
        public Thread[] thred;
        public StreamWriter StWrit;

        // Статические поля для передачи данных от потоков к таймеру
        public static string TimeB = "";   // Время начала
        public static string TimeE = "";   // Время окончания
        public static string TimeF = "";   // Продолжительность
        public static string NumT = "";    // Номер потока

        private static DateTime BTm;       // Время начала
        private static DateTime FTm;       // Время окончания
        private static TimeSpan STm;       // Продолжительность

        // Функция обратного вызова
        public static void tcallRes(int cNN, int cTH, double[] cXT, double[] cYT, double[,] cZT)
        {
            try
            {
                // Запись в файл
                string fileName = $"D://A_cb_{cTH}.txt";
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    DateTime now = DateTime.Now;
                    sw.WriteLine($"{now.Year}.{now.Month}.{now.Day}, {now.Hour}:{now.Minute}:{now.Second}:{now.Millisecond}");
                    sw.WriteLine($"Поток: {cTH}");

                    sw.Write("PXT: ");
                    for (int i = 0; i < cNN; i++) sw.Write(cXT[i] + "; ");
                    sw.Write("\nPYT: ");
                    for (int i = 0; i < cNN; i++) sw.Write(cYT[i] + "; ");
                    sw.Write("\nPZT:\n");
                    for (int i = 0; i < cNN; i++)
                    {
                        for (int j = 0; j < cNN; j++)
                            sw.Write(cZT[i, j] + "; ");
                        sw.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Время начала
            TimeB = BTm.Hour.ToString("00") + ":" + BTm.Minute.ToString("00") + ":" +
                    BTm.Second.ToString("00") + ":" + BTm.Millisecond.ToString("000");

            // Время окончания текущего потока
            FTm = DateTime.Now;
            TimeE = FTm.Hour.ToString("00") + ":" + FTm.Minute.ToString("00") + ":" +
                    FTm.Second.ToString("00") + ":" + FTm.Millisecond.ToString("000");

            // Продолжительность работы текущего потока
            STm = FTm - BTm;
            TimeF = STm.Hours.ToString("00") + ":" + STm.Minutes.ToString("00") + ":" +
                    STm.Seconds.ToString("00") + ":" + STm.Milliseconds.ToString("000");

            // Номер потока
            NumT = cTH.ToString();
        }

        // Метод создания и запуска потоков
        public void CDForm1(int tNN, int tTH, double tMinX, double tMaxX, double tMinY, double tMaxY)
        {
            // Показать форму и зафиксировать время начала
            Show();
            BTm = DateTime.Now;

            // Создание массивов для потоков
            tstat = new ThreadWithState[tTH];
            thred = new Thread[tTH];

            // Цикл создания объектов ThreadWithState и потоков
            for (I = 0; I < tTH; I++)
            {
                tstat[I] = new ThreadWithState(tNN, tMinX, tMaxX, tMinY, tMaxY, I + 1, new ThreadCallBack(tcallRes));
                thred[I] = new Thread(new ThreadStart(tstat[I].ThreadDoWork));
            }

            // Запуск всех потоков (параллельно) в фоновом потоке,
            // чтобы не блокировать UI-поток вызывающего приложения
            Thread launcherThread = new Thread(() =>
            {
                // Запуск потоков
                for (I = 0; I < tTH; I++)
                {
                    thred[I].Start();
                }

                // Ожидание завершения всех потоков
                for (I = 0; I < tTH; I++)
                {
                    thred[I].Join();
                }
            });
            launcherThread.IsBackground = true;
            launcherThread.Start();
        }

        // Обработчик таймера – обновление элементов формы
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTimeBegin.Text = TimeB; // Вывод начала времени
            labelTimeEnd.Text = TimeE;   // Вывод конца времени
            labelTimeSpan.Text = TimeF;  // Вывод промежутка времени
            labelTimeThread.Text = NumT; // Вывод в label номера потока

            // Проверка: все потоки завершились?
            bool allFinished = true;
            if (thred != null)
            {
                foreach (Thread t in thred)
                {
                    if (t != null && t.IsAlive)
                    {
                        allFinished = false;
                        break;
                    }
                }
            }
            else
            {
                allFinished = false;
            }

            // Если все потоки завершились — ставим 100, иначе 50
            if (allFinished)
            {
                progressBar1.Value = 100;
            }
            else
            {
                progressBar1.Value = 50;
            }
        }

        // Обработчик кнопки "Закрыть"
        private void button1_Click(object sender, EventArgs e)
        {
            // Прерывание потоков
            if (thred != null)
            {
                foreach (Thread t in thred)
                {
                    if (t != null && t.IsAlive)
                        t.Abort();
                }
            }
            Close(); // Закрытие формы
        }

        // Обработчик закрытия формы – прерывание потоков, чтобы кнопка "Закрыть" работала
        private void ClassDllForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thred != null)
            {
                foreach (Thread t in thred)
                {
                    if (t != null && t.IsAlive)
                        t.Abort();
                }
            }
        }
    }
}