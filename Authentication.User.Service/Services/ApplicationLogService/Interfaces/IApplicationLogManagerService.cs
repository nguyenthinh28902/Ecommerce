using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.ApplicationLogService.Interfaces
{
    public interface IApplicationLogManagerService
    {
        public Task<bool> CreateAsync(string Action, string TableName, string RecordId, bool IsAction);
    }
}
