using System;
using System.Diagnostics;

namespace LootQuest.Logic.Utilities {
    public class Timer: Interfaces.IUpdateable {

        public delegate void TimerEventHandler(object sender);
        public TimerEventHandler OnTimer;
        private float _timespan;
        private bool _isRepeating;
        private float _targetTime;

        private bool _isActive = false;

        public Timer(float timespan, bool isRepeating) {
            _timespan = timespan;
            _isRepeating = isRepeating;
            Utilities.GameLoopUpdate.Shared.Register(this);
            Start();
        }
        public void Update() {
            if (!_isActive)
                return;
            var currentTime = Utilities.Time.CurrentTime;
            if (Utilities.Time.CurrentTime >= _targetTime) {
                if (OnTimer != null) {
                    OnTimer(this);
                }

                Stop();

                if (_isRepeating) {
                    Start();
                }
            }
        }

        public void Start() {
            _isActive = true;
            _targetTime = Utilities.Time.CurrentTime + _timespan;
            Utilities.GameLoopUpdate.Shared.Register(this);
        }

        public void Stop() {
            _isActive = false;
            Utilities.GameLoopUpdate.Shared.Unregister(this);
        }

        public void Dispose() {
            Stop();
            OnTimer = null;
        }
       
    }
}