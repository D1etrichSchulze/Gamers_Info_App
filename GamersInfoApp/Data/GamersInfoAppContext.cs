using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamersInfoApp.Models;

namespace GamersInfoApp.Data
{
    public class GamersInfoAppContext : DbContext
    {
        public GamersInfoAppContext (DbContextOptions<GamersInfoAppContext> options)
            : base(options)
        {
        }

        public DbSet<GamersInfoApp.Models.Gamer> Gamer { get; set; } = default!;
        public DbSet<GamersInfoApp.Models.Game> Game { get; set; } = default!;
        public DbSet<GamersInfoApp.Models.Gamer_Game> Gamer_Game { get; set; } = default!;
    }
}
