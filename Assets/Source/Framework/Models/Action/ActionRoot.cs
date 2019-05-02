using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace LootQuest.Models.Action {
    [DataContract]
    public class ActionRoot: Representable
    {
        [DataMember]
        public int id;
        [DataMember]
        public string name;
        [DataMember]
        public string description;
        [DataMember]
        public ActionEffect[] effects;

        public void Reset() {
            effects.ToList().ForEach( x => x.Reset() );
        }
    }
}