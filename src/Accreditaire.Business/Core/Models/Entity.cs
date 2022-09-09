using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accreditaire.Business.Core.Models
{
    public abstract class Entity
    {
        protected Entity() // classe só pode ser herdada, membros acessíveis só para quem herdar
        {
            Id = Guid.NewGuid();

        }
        public Guid Id { get; set; } // guid instead of int

    }
}
