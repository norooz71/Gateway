using SAPP.Gateway.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Test
{
    public interface ITestChildService
    {
        Task<IEnumerable<TestChildDto>> GetAllAsync(CancellationToken cancellationToken=default);

        Task<TestChildDto> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task InsertAsync(TestChildDto testChildDto,CancellationToken cancellationToken=default);

        Task Delete(int id,CancellationToken cancellationToken);

    }
}
