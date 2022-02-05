namespace ClassLibrary1
{
   public class ClassForWordFile
    {
        private readonly Calculator _fileCalc;
       
        public ClassForWordFile()
        {
            _fileCalc = new Calculator();
        }

        public void ReadLineInFile(string pathFileWithExpression, string pathFileWithResult)
        {
            if (!System.IO.File.Exists(pathFileWithExpression))
            {
                Errors.ErrorExistFile();
                return;
            }

            var lines = System.IO.File.ReadAllLines(pathFileWithExpression);
            pathFileWithResult = ControlPathResult(pathFileWithResult);
            System.IO.StreamWriter openFile;

            try
            {
                openFile = new System.IO.StreamWriter(pathFileWithResult);
            }
            catch
            {
                Errors.ErrorExistFile();

                return;
            }

            if (lines.Length == 0)
            {
                Errors.EmptyFile();

                return;
            }

            foreach (var line in lines)
            {
                try
                {
                    openFile.WriteLine(line + " = " + _fileCalc.Calc(line));
                }
                catch
                {
                    openFile.WriteLine(line + " = Ошибка в выражении");
                }
              
            }

            openFile.Close();
        }

        private string ControlPathResult(string inputPath)
        {
            if (!string.IsNullOrEmpty(inputPath))
            {
                return inputPath + @"\result.txt";
            }

            Errors.EmptyPath(System.IO.Directory.GetCurrentDirectory() + @"\result.txt");

            return System.IO.Directory.GetCurrentDirectory() + @"\result.txt";
        }
    }
}
