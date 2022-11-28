using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCDemo2022.Models
{
    internal class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
