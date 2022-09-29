using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Text;

namespace excelpopitkanumberfive
{
    public class Excelchik
    {
       public async void excelchik(string path = @"C:\Users\юля\Desktop\эксельфайл.csv")
       {
            string newpath = @"C:\Users\юля\Desktop\тхтфайл.txt";
            string call;

                using (StreamReader reader = new StreamReader(path))
                {
                    string line;

                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        Regex regex = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
                        MatchCollection matches = regex.Matches(line);
                        if (matches.Count > 0)
                        {
                            foreach (Match match in matches)

                                using (FileStream file = new FileStream(newpath, FileMode.Append))
                                {
                                    using (StreamWriter stream = new StreamWriter(file))
                                    
                                    stream.WriteLine(line);
                                }
                        }
                    }
                }
            Console.WriteLine("проверь тхт файл");
       }
    }
}
