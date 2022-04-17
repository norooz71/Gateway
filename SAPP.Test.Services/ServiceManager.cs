using AutoMapper;
using SAPP.Gateway.Contracts.Utilities.Logger;
using SAPP.Gateway.Domain.Repositories;
using SAPP.Gateway.Services.Abstractions;
using SAPP.Gateway.Services.Abstractions.Test;
using SAPP.Gateway.Services.Test;
using System;

namespace SAPP.Gateway.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITestChildService> _lazyTestChildService;

        private readonly Lazy<ITestParentService> _lazyTestParentService;

        public ServiceManager(IUnitOfWork unitOfWork,IMapper mapper,ILoggerManager logger)
        {
            _lazyTestChildService = new Lazy<ITestChildService>(() => new TestChildService(unitOfWork, mapper));

            _lazyTestParentService=new Lazy<ITestParentService>(() =>new TestParentService(unitOfWork,mapper));  

        }

        public ITestParentService testParentService => _lazyTestParentService.Value;

        public ITestChildService testChildService => _lazyTestChildService.Value;
    }
}
