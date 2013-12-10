//using CocoFarm.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CocoFarm.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocoFarm.Model
{
    [Table("Produs", Schema = "Productie")]
    public class Produs : EntityWithId
    {
        public string Denumire { get; set; }
        public string Cod { get; set; }
        public string Descriere { get; set; }

        [ForeignKey("Categorie")]
        public Guid CategorieId { get; set; }

        public virtual ProdusCategorie Categorie { get; set; }

    }
}