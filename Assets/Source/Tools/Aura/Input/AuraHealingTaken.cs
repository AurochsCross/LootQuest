using XNode;

namespace Tools.Aura.Input {
    public class AuraHealingTaken: Node {
        [Output] public string Amount;

        public override object GetValue(NodePort port) {
            return "[a:healing]";
        }
    }
}