﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordLabelerAPI.Dtos
{
    public class WordLabelCreateDto
    {
        public string Word { get; set; }
        public string Label { get; set; }
    }
}
