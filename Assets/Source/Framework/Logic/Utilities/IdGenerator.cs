using System;

namespace LootQuest.Logic.Utilities {
    public class IdGenerator {
        private static Random _random = new Random();

        public static int GetId() {
            return _random.Next();
        }
    }
}