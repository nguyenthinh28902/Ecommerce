using Authentication.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.EntityModels
{
    public partial class UserToken
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string LoginProvider { get; set; } = null!;
        public string AppName { get; set; } = null!;
        public string Token { get; set; } = null!;
        public TokenType TokenType { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public string IpClient { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
