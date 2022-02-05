using System;

namespace ClassLibrary1
{
    internal class Errors
    {
        public static void ErrorZero()
        {
            Console.WriteLine("Ошибка. Нельзя делить на ноль");
        }

        public static void ErrorInExpression()
        {
            Console.WriteLine("Ошибка. Проверьте формат выражения");
        }

        public static void ErrorExistFile()
        {
            Console.WriteLine("Ошибка. Проверьте указанный путь к файлу");

        }

        public static void EmptyFile()
        {
            Console.WriteLine("Указанный файл пустой");
        }

        public static void EmptyPath(string path)
        {
            Console.WriteLine("Файл сохранился в {0}", path);
        }
    }
}
