using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalPatterns_Criacional
{
    internal sealed class UploadFile
    {
        private static UploadFile Instance = new UploadFile();

        private UploadFile()
        { }

        public static UploadFile GetInstance()
        {
            return Instance;
        }

        public bool PathUploadFile(string sourceFile, string pathDestFile)
        {
            if (!File.Exists(pathDestFile))
            {
                //Processos de upload
                return true;
            }
            else
                return false;
        }
    }

    public class Singleton2
    {
        public void ExecutarUpload()
        {
            var instanceUpload1 = UploadFile.GetInstance();
            var instanceUpload2 = UploadFile.GetInstance();
            var instanceUpload3 = UploadFile.GetInstance();

            //Verificação se todos os objetos contém as mesma instância
            if (instanceUpload1 == instanceUpload2 && instanceUpload1 == instanceUpload3)
            {
                //Mesmas instâncias
            }

            instanceUpload1.PathUploadFile("caminhoFonte", "caminhoDestino");
        }
    }
}
