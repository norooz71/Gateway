using SAPP.Gateway.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Test
{
    public interface ITestParentService
    {
        Task<IEnumerable<TestParentDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TestParentDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task Delete(int id, CancellationToken cancellationToken = default);

        Task InsertAsync(TestParentDto testDto, CancellationToken cancellationToken);
    }
}
