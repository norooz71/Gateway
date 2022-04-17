using SAPP.Test.Domain.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Domain.Repositories.Test
{
    public interface ITestChildRepository
    {
        Task<IEnumerable<TestChild>> GetAllByTestIdAsync(int testId, CancellationToken cancellationToken = default);
        Task<TestChild> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task Insert(TestChild account);
        void Remove(TestChild testChild);
    }
}
