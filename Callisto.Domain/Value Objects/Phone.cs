using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Value_Objects
{
    public class Phone
    {
        protected Phone()
        {
            
        }
        public Phone(string phone)
        {
            CellPhone = phone;
        }

        public string CellPhone { get; private set; }
    }
}
