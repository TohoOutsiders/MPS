using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace backend.Core.Entities
{
    public abstract class Entity
    {
        [Column("id")]
        public Guid Id { get; set; }
    }
}
