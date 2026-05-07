namespace LibraryCS
{
    public class ClassDll
    {
        // Объект второй формы ClassDllForm1
        public ClassDllForm1 CDF1 = new ClassDllForm1(); // Объект класса ClassDllForm1

        public void DllCallCS(int dNN, int dTH, double dMinX, double dMaxX, double dMinY, double dMaxY)
        {
            // Вызов функции CDForm1 класса ClassDllForm1
            CDF1.CDForm1(dNN, dTH, dMinX, dMaxX, dMinY, dMaxY); // Вызов функции CDForm1 класса ClassDllForm1
        }
    }
}