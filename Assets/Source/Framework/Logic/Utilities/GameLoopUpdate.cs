using System;
using System.Collections.Generic;

namespace LootQuest.Logic.Utilities {
    public class GameLoopUpdate: Interfaces.IUpdateable {

        private List<Interfaces.IUpdateable> _updateables = new List<Interfaces.IUpdateable>();

        public static GameLoopUpdate Shared {
            get {
                if (_shared == null) {
                    _shared = new GameLoopUpdate();
                }

                return _shared;
            }
        }

        private static GameLoopUpdate _shared;

        public void Update() {
            foreach (var updateable in _updateables.ToArray()) {
                updateable.Update();
            }
        }

        public void Register(Interfaces.IUpdateable updateable) {
            _updateables.Add(updateable);
        }

        public void Unregister(Interfaces.IUpdateable updateable) {
            _updateables.Remove(updateable);
        }
    }

    
}