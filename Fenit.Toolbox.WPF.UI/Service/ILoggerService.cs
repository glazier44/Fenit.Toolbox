using System;

namespace Fenit.Toolbox.WPF.UI.Service
{
    public interface ILoggerService
    {
        void Error(string message);
        void Error(string name, Exception e);
        void Warn(string message);
        void Info(string message);
        void Trace(string message);
    }
}