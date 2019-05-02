using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Frontend.Exploring {
    public class EntityRegistry: MonoBehaviour {
        public List<Entity.EntityMaster> Entities { get; private set; } = new List<Entity.EntityMaster>();
        public List<Entity.EntityMaster> Hostiles { get; private set; } = new List<Entity.EntityMaster>();

        public void RegisterEntity(Entity.EntityMaster entity) {
            bool isHostile = entity.GetComponent<NPC.HostileNPC>() != null;
            gameObject.GetComponent<Master>().GameMaster.ExploreCommander.RegisterEntity(entity.Master, isHostile);
            Entities.Add(entity);

            if (isHostile) {
                Hostiles.Add(entity);
            }
        }


        public Frontend.Entity.EntityMaster FindByInstanceId(int id) {
            Debug.Log("Instance id: " + id);
            foreach (var e in Entities) {
                if (e.Master.InstanceId == id) {
                    Debug.Log("Same id: " + e.Name);
                    return e;
                }
            }

            return null;
            // var entity = Entities.Where(x => x.Master.InstanceId == id).FirstOrDefault();
            // return entity;
        }
    }
}