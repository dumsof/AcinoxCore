using System;
using System.Collections.Generic;
using System.Text;

namespace File.Business.IBusiness
{
    public interface IValidationXsd
    {
        public string ValidationShemaXml(string nameFileXsdExtension, string nameFileXmlExtension);
    }
}
