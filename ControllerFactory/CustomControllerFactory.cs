using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ControllerFactory
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            ILogger Logger = new DefaultLogger();
            Assembly a = Assembly.GetExecutingAssembly();
            var ns = a.GetTypes().Select(t => t.Namespace).Where(n => n.EndsWith(".Controllers")).FirstOrDefault();
            string TypeName = $"{ns}.{controllerName}Controller";
            Type ControllerType = Type.GetType(TypeName);
            IController Controller = Activator.CreateInstance(ControllerType, new[] { Logger }) as Controller;
            return Controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable Disposable = controller as IDisposable;
            if (Disposable != null)
            {
                Disposable.Dispose();
            }
        }
    }
}