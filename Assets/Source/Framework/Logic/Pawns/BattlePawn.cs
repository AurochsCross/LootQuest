using System.Collections;
using System.Collections.Generic;

namespace LootQuest.Logic.Pawns {
    public class BattlePawn {
        public LootQuest.Models.Common.Attributes baseAttributes { get; private set; }
        public List<LootQuest.Models.Action.ActionRoot> actions { get; private set; }

        public int maxHitPoints { get; private set; }
        public int currentHitPoints { get; private set; }

        public BattlePawn(LootQuest.Models.Common.Attributes baseAttributes, List<LootQuest.Models.Action.ActionRoot> actions) {
            this.baseAttributes = baseAttributes;
            this.actions = actions;
            this.maxHitPoints = baseAttributes.Hp ?? baseAttributes.strength;
            this.currentHitPoints = baseAttributes.Hp ?? baseAttributes.strength;
        }

        public void TakeDamage(int damage) {
            currentHitPoints -= damage;
            if (currentHitPoints < 0) {
                currentHitPoints = 0;
            }
        }

        public void TakeHealing(int healing) {
            currentHitPoints += healing;
            if (currentHitPoints > maxHitPoints) {
                currentHitPoints = maxHitPoints;
            }
        }
    }
}