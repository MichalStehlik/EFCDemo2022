using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCDemo2022.Models
{
    internal class Game
    {
        public int GameId { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        public Company? Developer { get; set; }
        [Required]
        public int DeveloperId { get; set; }
    }
}
