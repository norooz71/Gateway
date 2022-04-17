using SAPP.Gateway.Services.Abstractions.Test;

namespace SAPP.Gateway.Services.Abstractions
{
    public interface IServiceManager
    {
        ITestParentService testParentService { get; }   

        ITestChildService testChildService { get; } 
    }
}
