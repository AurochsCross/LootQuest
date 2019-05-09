using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Frontend.Entity {
    [RequireComponent(typeof(EntityBattleMaster))]
    [RequireComponent(typeof(Animations.AnimationManager))]
    public class EntityMaster: MonoBehaviour {
        public int Hp = 1000;
        public string Name;
        public LootQuest.Logic.Entity.Master Master { get; private set; }
        public EntityBattleMaster BattleMaster { get; private set; }
        public Animations.AnimationManager AnimationManager { get; private set; }
        public bool IsPlayer { get { return gameObject.GetComponent<Frontend.PlayerMaster>() != null; } }

        public Dictionary<LootQuest.Models.Items.ArmorItem, Models.Items.ArmorItem>  ArmorEntities { 
            get { 
                return Master.EquipmentCommander.Armor.Where(x => x.Value != null).Select( x => new KeyValuePair<LootQuest.Models.Items.ArmorItem, Models.Items.ArmorItem>(x.Value, Frontend.Master.Shared.GetComponent<Inventory.ItemRegistry>().GetItem(x.Value.Id))).ToDictionary(x=>x.Key, x=>x.Value); 
            } 
        }
        public Dictionary<LootQuest.Models.Items.Item, Models.Items.ArmorItem> InventoryItemEntities { 
            get { 
                return Master.EquipmentCommander.Inventory.Select( x => new KeyValuePair<LootQuest.Models.Items.Item, Models.Items.ArmorItem>(x, Frontend.Master.Shared.GetComponent<Inventory.ItemRegistry>().GetItem(x.Id))).ToDictionary(x=>x.Key, x=>x.Value); 
            } 
        }
        void Awake() {
            Master = new LootQuest.Logic.Entity.Master(Name, new LootQuest.Models.Common.Attributes(10, 10, 10, Hp));
            Master.AddRepresentable(this);
            BattleMaster = gameObject.GetComponent<EntityBattleMaster>();
            AnimationManager = gameObject.GetComponent<Animations.AnimationManager>();
        }

        void Start() {
            SetInitialPosition();
            Frontend.Master.Shared.EntityRegistry.RegisterEntity(this);
        }

        private void SetInitialPosition() {
            Master.ExplorePawn.CurrentPosition = Exploring.ExploreSettings.Shared.PositionToExplorePosition(transform.position);
        }
    }
}