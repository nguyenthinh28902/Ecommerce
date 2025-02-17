using Authentication.User.DataAccess.Entities;
using Authentication.User.DataAccess.Repositories;
using Authentication.User.DataAccess.Service.ApplicationLogService.Interfaces;
using FeatureLibrary.LogLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.ApplicationLogService.Services
{
    public class DalApplicationLogManager : IDalApplicationLogManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ApplicationLog> _applicationLogRepository;
        private readonly ILogger<DalApplicationLogManager> _logger;
        public DalApplicationLogManager(IUnitOfWork unitOfWork, ILogger<DalApplicationLogManager> logger)
        {
            _unitOfWork = unitOfWork;
            _applicationLogRepository = unitOfWork.GetRepository<ApplicationLog>();
            _logger = logger;
        }

        public ApplicationLog NewApplicationLog(Guid UserId, string Action, string TableName, string RecordId, bool IsAction)
        {
            var applicationLog = new ApplicationLog();
            applicationLog.UserId = UserId;
            applicationLog.IsAction = IsAction;
            applicationLog.UserAction = Action;
            applicationLog.TableName = TableName;
            applicationLog.RecordId = RecordId;
            return applicationLog;
        }

        public async Task<ApplicationLog> CreateAsync(ApplicationLog applicationLog)
        {
            try
            {
                await _applicationLogRepository.AddAsync(applicationLog);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                var informationLoger = new InformationLoger(nameof(DalApplicationLogManager) + nameof(CreateAsync), ex, applicationLog);
                _logger.LogError(informationLoger.GetMessage());
            }

            return applicationLog;

        }
    }
}
