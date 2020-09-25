namespace File.Business.Business
{
    using System.Xml.Linq;
    using System.Xml.Schema;
    using File.Business.IBusiness;
    using File.Utility;

    public class ValidationXsd : IValidationXsd
    {
        public string ValidationShemaXml(string nameFileXsdExtension, string nameFileXmlExtension)
        {
            string result = string.Empty;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", $"{Utility.PathAplication}\\xsd\\{nameFileXsdExtension}");
            XDocument document = XDocument.Load($"{Utility.PathFolderGenerated}\\{nameFileXmlExtension}");

            document.Validate(schema, (s, e) =>
                {
                    result = $"EL ARCHIVO [XML] CONTIENE LOS SIGUIENTES ERRORES : {e.Message}";
                });


            return result;
        }
    }
}