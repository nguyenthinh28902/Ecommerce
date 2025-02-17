using Authentication.Admin.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Admin.DataAccess.Entities
{
    [Table("ApplicationLogs", Schema = TableCategory.Default)]
    public partial class ApplicationLog
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string UserAction { get; set; } = null!;

        public string TableName { get; set; } = null!;

        public int RecordId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
