using AncientTechnology.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Control.Managers
{
    public class StateManager
    {
        protected IList<State> _states = new List<State>();

        public State CurrentState
        {
            get
            {
                if (_states.Count == 0)
                {
                    return State.General;
                }
                else
                {
                    return _states.Max();
                }
            }
        }

        public void Add(State state)
        {
            if (_states.Contains(state) == false)
            {
                _states.Add(state);
            }
        }

        public void Remove(State state)
        {
            if (_states.Contains(state) == true)
            {
                _states.Remove(state);
            }
        }
    }
}
