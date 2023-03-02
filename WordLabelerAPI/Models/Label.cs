using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordLabelerAPI.Models
{
    public class Label
    {
        public int LabelId { get; set; }

        [Required]
        public string LabelName { get; set; }
        public virtual ICollection<Word> Words { get; set; }
    }
}
