using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordLabelerAPI.Models
{
    public class Word
    {
        public int WordId { get; set; }

        [Required]
        public string WordText { get; set; }
        public int LabelId { get; set; }
        public virtual Label Label { get; set; }
    }
}
