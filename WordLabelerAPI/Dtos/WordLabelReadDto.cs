using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordLabelerAPI.Dtos
{
    public class WordLabelReadDto
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Label { get; set; }
    }
}
