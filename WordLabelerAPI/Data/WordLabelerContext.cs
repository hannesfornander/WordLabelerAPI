using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordLabelerAPI.Models;

namespace WordLabelerAPI.Data
{
    public class WordLabelerContext : DbContext
    {
        public WordLabelerContext(DbContextOptions<WordLabelerContext> opt) : base(opt)
        {
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<Label> Labels { get; set; }
    }
}
