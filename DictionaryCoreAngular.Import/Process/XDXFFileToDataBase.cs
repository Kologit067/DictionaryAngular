using System.Text.RegularExpressions;
using DictionaryCoreAngular.Import.Context;
using Microsoft.Extensions.Configuration;

namespace DictionaryCoreAngular.Import.Process
{
    public class XDXFFileToDataBase
    {

        private readonly IConfiguration _configuration;
        public XDXFFileToDataBase(IConfiguration configuration) { 
            _configuration = configuration;
        }
        public void Import(string directoryName)
        {

            DirectoryInfo di = new DirectoryInfo(directoryName);
            FileInfo[] files = di.GetFiles("*.xdxf", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                string native = "gainst";
                Regex regex = new Regex(@"^[\sA-Za-zа-яА-ЯЁёїЇіІєЄ\-]+$");
                MatchCollection matches = regex.Matches(native);
                FileInfo fi = files[i];
                XmlRepository.ProcessXDXFFile(fi.FullName);
            }
        }
    }
}
