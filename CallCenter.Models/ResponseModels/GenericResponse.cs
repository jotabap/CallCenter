using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Models.ResponseModels
{
    public class GenericResponse
    {
      public bool OperationSucces { get; set; }
      public string ErrorMessage { get; set; }
       public object ObjectResponse { get; set; }
        public long TotalRecords { get; set; } = 0;
        public long CountRecords { get; set; } = 0;


    }
}
