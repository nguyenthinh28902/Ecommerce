using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Entities
{
    public class Entity
    {
        public Entity() { 
        
        }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
