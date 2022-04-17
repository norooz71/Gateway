using SAPP.Test.Domain.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Domain.Repositories.Test
{
    public interface ITestParentRepository
    {
        Task<IEnumerable<TestParent>> GetAllAsync(CancellationToken cancelationToken);
        Task<TestParent> GetById(int id,CancellationToken cancelationToken);
        Task InsertAsync(TestParent test,CancellationToken cancelationToken);
        void Remove(TestParent testParent);
    }
}
