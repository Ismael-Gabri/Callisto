using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Callisto.Domain.Value_Objects
{
    public class Phone
    {
        protected Phone()
        {
            
        }
        [JsonConstructor]
        public Phone(string cellPhone)
        {
            CellPhone = cellPhone;
        }

        public string CellPhone { get; set; }
    }
}
