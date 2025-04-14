// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using DictionaryCoreAngular.Import.Process;
using Microsoft.Extensions.Configuration;
internal class Program
{
    private static void Main(string[] args)
    {
        string native = "gainst";
//        Regex regex = new Regex(@"^[\sA-Za-zа-яА-ЯЁёїЇіІєЄ\-]+$");
        Regex regex = new Regex(@"^[\sA-Za-zа-яА-ЯЁёїЇіІєЄ\-]+$");
        MatchCollection matches = regex.Matches(native);

        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        XDXFFileToDataBase fileToDataBase = new XDXFFileToDataBase(configuration);
        fileToDataBase.Import(@"D:\Data\Dictionaries\");
    }
}