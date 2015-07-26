using System;

namespace GenerateJsonReports
{
    class Test
    {
        //virtual machine path to documents folder
        public static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Visual Studio 2013\\Projects\\SupermarketChain";

        public static void Main()
        {


            var export = new JsonReportExport();

            export.Report(new DateTime(2010, 01,01),DateTime.Now);
            
        }
    }
}
