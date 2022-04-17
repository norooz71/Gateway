using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Test.Contracts.Utilities.Logger
{
    public interface ILoggerManager
    {
        void Error(string message);

        void Info(string message);

        void Warn(string message);

        void Debug(string message);
    }
}