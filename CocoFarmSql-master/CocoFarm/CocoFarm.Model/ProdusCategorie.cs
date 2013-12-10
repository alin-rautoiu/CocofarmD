using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoFarm.Model
{
    [Table("ProdusCategorie", Schema = "Productie")]
    public class ProdusCategorie : EntityWithId
    {
        [Required]
        public string Cod { get; set; }
        [StringLength(10)]
        public string Denumire { get; set; }
        public string Descriere { get; set; }
    }
}
