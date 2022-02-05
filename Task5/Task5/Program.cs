using System;
using ClassLibrary1;

namespace Task5
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Выберите режим работ программы. Для того что бы посчитать выражение из консоли введите: '1'. Для того чтобы посчитать выражение из файла введите: '2'");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите выражение");
                    ConsoleCalculator  consoleCalc = new();
                    Console.WriteLine(consoleCalc.ConsCalc(Console.ReadLine()));
                    break;

                case "2":
                    ClassForWordFile fileCalc = new();
                    Console.WriteLine("Укажите путь до файла с выражениями");
                    string pathFileWithExseption = Console.ReadLine();
                    Console.WriteLine("Укажите каталог куда сохранится файл с результатом или он сохранится по умолчанию");
                    string inputPath = Console.ReadLine();
                    fileCalc.ReadLineInFile(pathFileWithExseption,inputPath);
                    break;

                default: return;
            }

            Console.Read();
        }
    }
}
