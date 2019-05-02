using System.Collections.Generic;
using System;

namespace LootQuest.Logic.Entity {
    public class Master: Models.Representable {
        public int InstanceId {
            get {
                if (_instanceId == 0) {
                    _instanceId = Utilities.IdGenerator.GetId();
                }
                return _instanceId;
            }
        }
        public string Name { get; private set; }
        public Commanders.BattleCommander BattleCommander { get; private set; } 
        public Commanders.EquipmentCommander EquipmentCommander { get; private set; } 
        public Pawns.ExplorePawn ExplorePawn { get; private set; }
        public LootQuest.Models.Common.Attributes BaseAttributes { get; private set; }
        public LootQuest.Models.Common.Attributes ItemAttributes { 
            get {
                return EquipmentCommander.GetAttributes();
            }
        }
        public List<LootQuest.Models.Action.ActionRoot> AvailableActions {
            get {
                return EquipmentCommander.GetActions();
            }
        }

        private int _instanceId = 0;

        public Master(string name, LootQuest.Models.Common.Attributes baseAttributes) {
            EquipmentCommander = new Commanders.EquipmentCommander(this);
            Name = name;
            BaseAttributes = baseAttributes;
            ExplorePawn = new Pawns.ExplorePawn(this);
        }

        public Commanders.BattleCommander GenerateBattleCommander(Game.Commanders.BattleCommander battleMaster) {
            BattleCommander = new Commanders.BattleCommander(this, battleMaster, BaseAttributes + ItemAttributes);
            return BattleCommander;
        }

        public void SetBaseAttributes(LootQuest.Models.Common.Attributes baseAttributes) {
            BaseAttributes = baseAttributes;
        }
    }
}