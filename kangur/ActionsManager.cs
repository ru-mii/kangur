using System;
using System.Collections.Generic;

namespace kangur
{
    public class ActionsManager
    {
        private Dictionary<int, Action> _registeredActions; // KeyCode, Action

        public ActionsManager()
        {
            _registeredActions = new Dictionary<int, Action>();
        }

        public void RegisterAction(int keyCode, Action action)
        {
            if (_registeredActions.ContainsKey(keyCode)) return;
            if (action == null) return;

            _registeredActions.Add(keyCode, action);
        }

        public void CallAction(int keyCode)
        {
            if (!_registeredActions.ContainsKey(keyCode)) return;

            _registeredActions[keyCode]?.Invoke();
        }
    }
}
