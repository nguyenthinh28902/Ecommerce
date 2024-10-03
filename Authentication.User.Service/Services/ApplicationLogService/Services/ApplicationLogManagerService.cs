using Authentication.User.DataAccess.Service.ApplicationLogService.Interfaces;
using Authentication.User.Service.Services.ApplicationLogService.Interfaces;
using Authentication.User.Service.Services.UserServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.Services.ApplicationLogService.Services
{
    public class ApplicationLogManagerService : IApplicationLogManagerService
    {
        private readonly IDalApplicationLogManager _dalApplicationLogManager;
        public readonly IUserInformationService _userInformationService;
        public ApplicationLogManagerService(IDalApplicationLogManager dalApplicationLogManager, IUserInformationService userInformationService) { 
            _dalApplicationLogManager = dalApplicationLogManager;
            _userInformationService = userInformationService;
        }

        public async Task<bool> CreateAsync(string Action, string TableName, string RecordId, bool IsAction)
        {
            var userIdstr = _userInformationService.GetUserId();
            var userId = Guid.NewGuid();
            Guid.TryParse(userIdstr, out userId);
            var application = _dalApplicationLogManager.NewApplicationLog(userId, Action,TableName,RecordId,IsAction);
            application = await _dalApplicationLogManager.CreateAsync(application);
            return application != null && application.Id != Guid.Empty ? true : false;
        }
    }
}
