using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fat_DeliaGabriela_Lab2.Models;

namespace Fat_DeliaGabriela_Lab2.Data
{
    public class Fat_DeliaGabriela_Lab2Context : DbContext
    {
        public Fat_DeliaGabriela_Lab2Context (DbContextOptions<Fat_DeliaGabriela_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Fat_DeliaGabriela_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Fat_DeliaGabriela_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Fat_DeliaGabriela_Lab2.Models.Author> Author { get; set; }

        public DbSet<Fat_DeliaGabriela_Lab2.Models.BookCategory> BookCategory { get; set; }
        public DbSet<Fat_DeliaGabriela_Lab2.Models.Category> Category { get; set; }
        public DbSet<Fat_DeliaGabriela_Lab2.Models.Member> Member { get; set; }
        public DbSet<Fat_DeliaGabriela_Lab2.Models.Borrowing> Borrowing { get; set; }
    }
}
