using AncientTechnology.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Control.Controllers
{
    public interface IController
    {
        void Start(IUpdateable updateable);
    }
}
