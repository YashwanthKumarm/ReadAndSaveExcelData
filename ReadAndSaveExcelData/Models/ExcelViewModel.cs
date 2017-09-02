using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadAndSaveExcelData.Models
{
    public class ExcelViewModel
    {
        public string Category { get; set; }
        public string Functionality { get; set; }
        public string Description { get; set; }
        public string New { get; set; }
        public string HelpTopic { get; set; }
    }
}