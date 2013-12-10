using CocoFarm.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoFarm.DataAccess
{
    public class CocoFarmContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }
        public DbSet<ProdusCategorie> ProduseCategorii { get; set; }
    }
}
