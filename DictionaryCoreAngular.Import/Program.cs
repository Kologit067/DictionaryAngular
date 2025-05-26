// See https://aka.ms/new-console-template for more information
using DictionaryCoreAngular.Import.CustomDictionary;
using DictionaryCoreAngular.Import.Process;
using Microsoft.Extensions.Configuration;
internal class Program
{
    private static IConfiguration configuration;
    private static async Task Main(string[] args)
    {
        if (args.Length > 0)
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            switch (args[0])
            {
                case "XDXF":
                    XDXFFileProcess();
                    break;
                case "CustomDictionary":
                    await CustomDictionaryProcess();
                    break;
                case "UserHistory":
                    await UserHistoryProcess();
                    break;
            }
        }
    }

    private static async Task UserHistoryProcess()
    {
        DirectoryInfo rootDirectory = new DirectoryInfo(@"..\..\..\..\UserHistory\");
        foreach (var dir in rootDirectory.GetDirectories())
        {
            UserHistoryMaker historyMaker = new UserHistoryMaker(dir, configuration);
            await historyMaker.Process();
        }
    }

    private static async Task CustomDictionaryProcess()
    {
        DirectoryInfo rootDirectory = new DirectoryInfo(@"..\..\..\..\CustomDictionary\");
        foreach (var dir in rootDirectory.GetDirectories())
        {
            WordListGroupMaker groupMaker = new WordListGroupMaker(dir, configuration);
            await groupMaker.Process();
        }
    }

    private static void XDXFFileProcess()
    {
        //string native = "gainst";
        ////        Regex regex = new Regex(@"^[\sA-Za-zа-яА-ЯЁёїЇіІєЄ\-]+$");
        //Regex regex = new Regex(@"^[\sA-Za-zа-яА-ЯЁёїЇіІєЄ\-]+$");
        //MatchCollection matches = regex.Matches(native);

        XDXFFileToDataBase fileToDataBase = new XDXFFileToDataBase(configuration);
        fileToDataBase.Import(@"D:\Data\Dictionaries\");
    }
}