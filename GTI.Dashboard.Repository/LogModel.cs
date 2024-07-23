using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public class LogModel
    {
        public int Id { get; set; }
        public int Id_usuario { get; set; }
        public int Status_Code { get; set; }
        public string Classe { get; set; }
        public string Message { get; set; }
        public string Exception { get; set;}

        public DateTime Data_Hora { get; set; }
    }
}
