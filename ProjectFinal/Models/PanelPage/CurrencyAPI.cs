using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.PanelPage
{
    public class Rootobject
    {
        public Xml xml { get; set; }
        public Valcurs ValCurs { get; set; }
    }

    public class Xml
    {
        public string version { get; set; }
        public string encoding { get; set; }
    }

    public class Valcurs
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Valtype[] ValType { get; set; }
    }

    public class Valtype
    {
        public string Type { get; set; }
        public Valute[] Valute { get; set; }
    }

    public class Valute
    {
        public string Code { get; set; }
        public string Nominal { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

}



