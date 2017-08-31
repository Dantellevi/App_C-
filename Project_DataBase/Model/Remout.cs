using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_DB_Remont.Model
{
    public    class Remout
    {
        public int Id { get; set; }
        public string description { get; set; }
        public string OriginRemont { get; set; }
        public string EndRemont { get; set; }

        public string Neispravnost { get; set; }
        public string FotoNeispr { get; set; }
        public string directAuthors { get; set; }

        public string MarkaDevices { get; set; }

    }
}
