using ImpromptuInterface;
using System;
using System.Dynamic;

namespace Logger
{
    public class LoggingProxy<T> : DynamicObject where T : class
    {
        private readonly T _obj;
        private readonly ILogger _logger;

        public LoggingProxy(ILogger logger)
        {
            _logger = logger;
        }

        private LoggingProxy(T obj, ILogger logger) : this(logger)
        {
            _obj = obj;
        }

        public T CreateInstance(T obj)
        {
            if (!typeof(T).IsInterface)
            {
                throw new ArgumentException("T must be an interface.");
            }

            return new LoggingProxy<T>(obj, _logger).ActLike<T>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                string logMessage = $"Invoking {_obj.GetType().Name}.{binder.Name} with args [{string.Join(",", args)}]";
                _logger.Info(logMessage);

                result = _obj.GetType().GetMethod(binder.Name).Invoke(_obj, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
