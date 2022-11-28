using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCDemo2022.Models
{
    internal class CompanyListIM
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = String.Empty;
        public int GameCount { get; set; }
    }
}
