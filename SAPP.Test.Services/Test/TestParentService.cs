using AutoMapper;
using SAPP.Test.Contracts.Dtos;
using SAPP.Test.Domain.Entities.Test;
using SAPP.Test.Domain.Exeptions;
using SAPP.Test.Domain.Repositories;
using SAPP.Test.Services.Abstractions.Test;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Services.Test
{
    public sealed class TestParentService : ITestParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public TestParentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork; 
            this._mapper = mapper;
        }
        public async Task Delete(int id,CancellationToken cancellationToken)
        {
            var testParent = await _unitOfWork.GetRepository<TestParent>().GetByCondition(t => t.Id == id, cancellationToken);

            _unitOfWork.GetRepository<TestParent>().Delete(testParent.FirstOrDefault());

        }

        public async Task<IEnumerable<TestParentDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var testParents = await _unitOfWork.GetRepository<TestParent>().GetAll(cancellationToken);
           
            var result=_mapper.Map<IEnumerable<TestParentDto>>(testParents);

            return result;
        }

        public async Task<TestParentDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var testParent=await _unitOfWork.GetRepository<TestParent>().GetByCondition(t=>t.Id == id, cancellationToken);

            if (testParent.FirstOrDefault()==null)
            {
                throw new GlobalException(ExceptionLevel.Service,ExceptionType.NotFound, ExceptionMessages.NotFound);
            }

            var result=_mapper.Map<TestParentDto>(testParent.FirstOrDefault());

            return result;
        }

        public async Task InsertAsync(TestParentDto testDto, CancellationToken cancellationToken)
        {
            var entity=_mapper.Map<TestParent>(testDto);

            await _unitOfWork.GetRepository<TestParent>().Post(entity,cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
