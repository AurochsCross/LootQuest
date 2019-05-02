using System.Runtime.Serialization;

namespace LootQuest.Models.Action {

    [System.Serializable]
    [DataContract]
    public class ActionEffect {
        [DataMember]
        public int id;
        
        [DataMember]
        public EffectType type;

        [DataMember]
        public EffectSubject subject;

        [DataMember]
        public string hitCalculation;

        [DataMember]
        public string valueCalculation;
        [DataMember]
        public float Delay;

        public bool didHit = false;

        public float calculatedValue = 0f;

        public ActionEffect(int id, string hitCalculation, string valueCalculation, EffectType type, EffectSubject subject, float delay) {
            this.id = id;
            this.hitCalculation = hitCalculation;
            this.valueCalculation = valueCalculation;
            this.type = type;
            this.subject = subject;
            this.Delay = delay;
        }

        public void Reset() {
            didHit = false;
            calculatedValue = 0f;
        }
    }
}