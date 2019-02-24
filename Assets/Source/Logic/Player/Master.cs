namespace Logic.Player {
    public class Master {
        public Commanders.BattleCommander battleCommander { get; private set; } 
        public Commanders.EquipmentCommander equipmentCommander { get; private set; } 

        public Master() {
            equipmentCommander = new Commanders.EquipmentCommander();
        }

        public Commanders.BattleCommander CreateBattleCommander() {
            battleCommander = new Commanders.BattleCommander(equipmentCommander.GetAttributes(), equipmentCommander.GetActions());
            return battleCommander;
        }
    }
}