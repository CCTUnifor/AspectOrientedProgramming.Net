using System;
using System.Reflection;

namespace AOP.NET
{
    public class DynamicProxy<T> : DispatchProxy
    {
        private T _decorated;
        public event EventHandler<MethodInfo> BeforeExecute;
        public event EventHandler<MethodInfo> AfterExecute;
        public event EventHandler<MethodInfo> ErrorExecuting;

        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            OnBeforeExecute(targetMethod);
            try
            {
                var result = targetMethod.Invoke(_decorated, args);
                OnAfterExecute(targetMethod);
                return result;
            }
            catch (Exception e)
            {
                OnErrorExecuting(targetMethod);
                return e;
            }
        }

        private void OnBeforeExecute(MethodInfo methodCall) => BeforeExecute?.Invoke(this, methodCall);
        private void OnAfterExecute(MethodInfo methodCall) => AfterExecute?.Invoke(this, methodCall);
        private void OnErrorExecuting(MethodInfo methodCall) => ErrorExecuting?.Invoke(this, methodCall);

        public static T Create(T decorated, EventHandler<MethodInfo> before, EventHandler<MethodInfo> after, EventHandler<MethodInfo> error)
        {
            object proxy = Create<T, DynamicProxy<T>>();
            var dynamicProxy = ((DynamicProxy<T>)proxy);
            dynamicProxy.BeforeExecute += before;
            dynamicProxy.AfterExecute += after;
            dynamicProxy.ErrorExecuting += error;
            dynamicProxy.SetParameters(decorated);

            return (T)proxy;
        }

        private void SetParameters(T decorated)
        {
            if (decorated == null)
                throw new ArgumentNullException(nameof(decorated));

            _decorated = decorated;
        }
    }
}