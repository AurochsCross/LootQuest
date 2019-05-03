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
        public string originalValueCalculation { get; private set; }
        [DataMember]
        public float Delay;
        [DataMember]
        public Aura.AuraRoot Aura;

        public bool didHit = false;

        public float calculatedValue = 0f;

        public ActionEffect(int id, string hitCalculation, string valueCalculation, EffectType type, EffectSubject subject, float delay) {
            this.id = id;
            this.hitCalculation = hitCalculation;
            this.valueCalculation = valueCalculation;
            this.type = type;
            this.subject = subject;
            this.Delay = delay;
            this.originalValueCalculation = valueCalculation;
        }

        public ActionEffect(int id, string hitCalculation, Aura.AuraRoot aura, EffectSubject subject, float delay) {
            this.id = id;
            this.hitCalculation = hitCalculation;
            this.valueCalculation = "0";
            this.type = EffectType.Aura;
            this.subject = subject;
            this.Delay = delay;
            this.Aura = aura;
            this.originalValueCalculation = valueCalculation;
        }

        public void Reset() {
            didHit = false;
            calculatedValue = 0f;
        }
    }
}