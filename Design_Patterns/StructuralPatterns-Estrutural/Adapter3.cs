using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.StructuralPatterns_Estrutural
{
    //Exemplo teste de driver de impressão 
    //Meu driver imprime somente em preto e branco, versão do driver 1.0

    //-- Classe Adaptee 
    // Classe que já faz uso de recursos de impressões, conversão de arquivo
    //para entrada serial... vários processos
    public class DriverConvertDocument
    {
        public string GetDocumentForSerialPrintBlacWhite(string content)
        {
            return "string com dados de documento convertido";
        }
    }

    //-- Interface Target
    // Interface que ser usado como acesso da classe cliente 
    //pois a mesma não é compativel com os recursos da classe Adaptee DriverConvertDocument
    public interface IDriverConvertAllDocument
    {
        string GetDocumentForAllTypeColor(string content);
    }

    //-- Classe Adapter
    // Como as proximas classes que tiverem que usar recurso de conversão de documento para impressão não puderem acessar 
    //as conversões do preto e branco então fazemos um mediador ou adaptador 
    //para acessar através do mesmo para acesso das novas classes
    public class DriverAdapterDocumentColors : DriverConvertDocument, IDriverConvertAllDocument
    {
        public string GetDocumentForAllTypeColor(string content)
        {
            return GetDocumentForSerialPrintBlacWhite(content);
        }
    }

    //Classe cliente
    public class DriverGetDocumentColors
    {
        private readonly IDriverConvertAllDocument _driverConvertAllDocument;

        public DriverGetDocumentColors(IDriverConvertAllDocument driverConvertAllDocument)
        {
            _driverConvertAllDocument = driverConvertAllDocument;
        }

        public string GetDocumentAllColors(string content)
        {
            string document = _driverConvertAllDocument.GetDocumentForAllTypeColor(content);
            //Processos de conversão para cores colorias
            return document;
        }
    }

    //
    public class Adapter3
    {
        public void Executar()
        {
            IDriverConvertAllDocument _driverConvertAllDocument = new DriverAdapterDocumentColors();
            DriverGetDocumentColors driverGetDocumentColors = new DriverGetDocumentColors(_driverConvertAllDocument);
            string content = "conteudo para impressão";
            var document = driverGetDocumentColors.GetDocumentAllColors(content);
            //Processos para impressão colorido
            // ...
            // ...
        }



    }
}
