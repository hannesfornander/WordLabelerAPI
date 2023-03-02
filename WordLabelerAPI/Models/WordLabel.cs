using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordLabelerAPI.Models
{
    public class WordLabel
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Label { get; set; }
    }
}
