using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Abstract;
using BushachFirstSchool.Domain.Concrate;
using BushachFirstSchool.Infrastructure.Abstract;


namespace BushachFirstSchool.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public NinjectControllerFactory()
        {
            this._ninjectKernal = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)_ninjectKernal.Get(controllerType);
        }
        private void AddBindings()
        {          
           _ninjectKernal.Bind<ISchoolRepositorycs>().To<EFSchoolRepositorycs>();
           _ninjectKernal.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
        private IKernel _ninjectKernal;
    }
}