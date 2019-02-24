namespace Logic.Player {
    class Master {
        public Commanders.BattleCommander battleCommander { get; private set; } 
        public Commanders.EquipmentCommander equipmentCommander { get; private set; } 

        public Commanders.BattleCommander CreateBattleCommander() {
            battleCommander = new Commanders.BattleCommander(equipmentCommander.GetAttributes(), equipmentCommander.GetActions());
            return battleCommander;
        }
    }
}