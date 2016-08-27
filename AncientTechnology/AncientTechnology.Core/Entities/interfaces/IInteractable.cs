﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Entities {
    public interface IInteractable {
        void InteractWith(IInteractor interactor);
    }
}
