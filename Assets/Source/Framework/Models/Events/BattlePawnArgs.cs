using System;

namespace LootQuest.Models.Events {
    public class BattlePawnArgs: EventArgs {
        public int Amount { get; private set; }

        public BattlePawnArgs(int amount) {
            Amount = amount;
        }
    }
}