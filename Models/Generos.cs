using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2_2019EJ650_2019PA603.Models
{
    public class Generos
    {
        [Key]
        public int generoId { get; set; }
        public string genero { get; set; }
    }
}
