using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CocoFarm.Model
{
    public class EntityWithId : IEntityWithId
    {
        [Key]
        public Guid Id { get; set; }

        public EntityWithId()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
