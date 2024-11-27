using ConsoleApp1.Controller;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Paths
            string FolderLocation = @"C:\Users\Cahid\Desktop\Ev tapsiriqi";
            string FilePath = @"C:\Users\Cahid\Desktop\Ev tapsiriqi\Numbers.txt";
            string FilePathOld = @"C:\Users\Cahid\Desktop\Ev tapsiriqi\OldNumber.txt";
            string FilePathEven = @"C:\Users\Cahid\Desktop\Ev tapsiriqi\EvenNumber.txt";
            #endregion
            if (!Controllers.FolderController(FolderLocation))
            {
                Controllers.FolderCreate(FolderLocation);
            }
            if (!Controllers.FileController(FilePath) && !Controllers.FileController(FilePathOld) &&
                Controllers.FileController(FilePathEven))
            {
                Controllers.FileCreate(FilePath);
                Controllers.FileCreate(FilePathEven);
                Controllers.FileCreate(FilePathOld);
            }
            // 10 setirin heresinde 10 element olaq serti ile melumatlari txt fayla yazmaq
            Random random = new Random();
            using (StreamWriter wr = new StreamWriter(FilePath))
            {
                for (int i = 0; i < 10; i++)
                {
                    string line = "";
                    for (int j = 0; j < 10; j++)
                    {
                        int number = random.Next(1, 999);
                        line += number + " ";
                    }
                    wr.WriteLine(line.Trim());
                }
            }

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;
                int lineRow = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] numbers = line.Split(new char[] { ' ', '(', ')' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                    foreach (var numStr in numbers)
                    {
                        if (int.TryParse(numStr, out int number)) 
                        {
                            int num = int.Parse(numStr);
                            if (num % 2 == 0)
                            {
                                File.AppendAllText(FilePathEven, number + ",");
                            }
                            else
                            {
                                File.AppendAllText(FilePathOld, number + ",");
                            }
                        }
                    }
                }
                lineRow++;
            }
            Console.WriteLine("Emeliyyatlar tamamlandi");
            Console.ReadLine();
        }
    }
}
