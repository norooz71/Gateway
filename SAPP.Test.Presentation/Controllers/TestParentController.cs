using Microsoft.AspNetCore.Mvc;
using SAPP.Test.Contracts.Dtos;
using SAPP.Test.Presentation.Responses;
using SAPP.Test.Services.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SAPP.Test.Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TestParentController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TestParentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestParents(CancellationToken cancellationToken)
        { 
           var result= await _serviceManager.testParentService.GetAllAsync(cancellationToken);

            return Ok(new BaseResponse<IEnumerable<TestParentDto>>(true,200,result,null));
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTestParentById(int id, CancellationToken cancellationToken)
        {
            var result = await _serviceManager.testParentService.GetByIdAsync(id, cancellationToken);

            return Ok(new BaseResponse<TestParentDto>(true,200,result,null));

        }

        [HttpPost]
        public async Task<IActionResult> PostTestParent(TestParentDto testParentDto, CancellationToken cancellationToken)
        {
            await _serviceManager.testParentService.InsertAsync(testParentDto, cancellationToken);
            return Ok();
        }
    }
}
