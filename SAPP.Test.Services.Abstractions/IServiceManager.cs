using SAPP.Test.Services.Abstractions.Test;

namespace SAPP.Test.Services.Abstractions
{
    public interface IServiceManager
    {
        ITestParentService testParentService { get; }   

        ITestChildService testChildService { get; } 
    }
}
