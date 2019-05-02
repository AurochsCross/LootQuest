using System.Collections.Generic;
using LootQuest.Models.Exploring;
using System.Linq;

namespace LootQuest.Logic.Game.Commanders {
    public class ExploreCommander {
        public List<Entity.Master> Entities { get; private set; } = new List<Entity.Master>();
        public List<Entity.Master> Hostiles { get; private set; } = new List<Entity.Master>();
        private Master _master;

        public ExploreCommander(Master master) {
            _master = master;
        }

        public void RegisterEntity(Entity.Master entity, bool isHostile = false) {
            Entities.Add(entity);
            if(isHostile) {
                Hostiles.Add(entity);
            }
        }

        public void RemoveEntity(Entity.Master entity) {
            Entities.Remove(entity);
            Hostiles.Remove(entity);
        }

        public void MoveEntity(Entity.Master entity, Position position) {
            entity.ExplorePawn.CurrentPosition = position;

            var hostile = HostileAtPosition(entity.ExplorePawn.CurrentPosition);
            if (entity == _master.PlayerMaster && hostile != null) {
                _master.StartEncounter(hostile);
            }
        }

        private Entity.Master HostileAtPosition(Position position) {
            return Hostiles.Where( x => x.ExplorePawn.CurrentPosition == position).FirstOrDefault();
        }

    }
}