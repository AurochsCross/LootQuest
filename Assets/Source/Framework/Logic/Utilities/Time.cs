using System;
using System.Diagnostics;

namespace LootQuest.Logic.Utilities {
    public class Time {

        public static Time Instance {
            get {
                if (_instance == null) {
                    _instance = new Time();
                }
                return _instance;
            }
        }

        public static float CurrentTime {
            get {
                return (float)Time.Instance._stopwatch.Elapsed.Milliseconds / 1000f;
            }
        }
        
        private static Time _instance;

        private Stopwatch _stopwatch;
        public Time() {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }
    }
}