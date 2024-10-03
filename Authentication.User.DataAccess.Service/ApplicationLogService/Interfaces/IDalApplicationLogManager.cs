using Authentication.User.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.ApplicationLogService.Interfaces
{
    public interface IDalApplicationLogManager
    {
        public ApplicationLog NewApplicationLog(Guid UserId, string Action, string TableName, string RecordId, bool IsAction);
        public Task<ApplicationLog> CreateAsync(ApplicationLog applicationLog);
    }
}
