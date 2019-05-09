using XNode;

namespace Tools.Aura.Input {
    public class AuraDamageTaken: Node {
        [Output] public string Amount;

        public override object GetValue(NodePort port) {
            return "[a:damage]";
        }
    }
}