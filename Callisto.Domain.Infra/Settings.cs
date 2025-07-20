using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Infra
{
    public class Settings
    {
        public static string ConnectionString { get; set; } = "Server=localhost,1433\\SQLEXPRESS;Database=attlas_finance;User ID=sa;Encrypt=False;Password=1q2w3e4r@#$";
    }
}
