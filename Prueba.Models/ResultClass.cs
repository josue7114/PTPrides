using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Models
{
    public class ResultClass<DataModel>
    {
        public int StatusCode { get; set; }
        public DataModel? Model { get; set; }
        public List<DataModel?> ListModel { get; set; }
        public string Message { get; set; }
    }
}