using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Frontend.Inventory {
    public class ItemRegistry: MonoBehaviour {
        public List<Models.Items.ArmorItem> Items = new List<Models.Items.ArmorItem>();

        public void AddItem(Models.Items.ArmorItem item) {
            Items.Add(item);
        }

        public Tools.ActionBuilder.AbilityGraph GetAction(int id) {
            //Items.ForEach( x => Debug.Log(x.actionGraph.Id) );
            var a = Items.Where(x => x.actionGraph != null && x.actionGraph.GetInstanceID() == id).ToList();
            var b = a.Select(x => x.actionGraph).ToList();
            return b.FirstOrDefault();
        }

        public Models.Items.ArmorItem GetItem(int id) {
            return Items.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}