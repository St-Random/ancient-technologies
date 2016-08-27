using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AncientTechnology.Core.Entities;

namespace AncientTechnology.Core.Control.Controllers
{
    public abstract class AbstractController<T> : IController
        where T : IUpdateable
    {
        public void Start(IUpdateable updateable)
        {
            var obj = (T)updateable;
            Start(obj);
        }

        protected abstract void Start(T obj);
    }
}
