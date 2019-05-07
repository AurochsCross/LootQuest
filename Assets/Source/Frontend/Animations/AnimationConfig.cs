namespace Frontend.Animations {
    public static class AnimationConfig {
        public enum SimpleAnimationType {
            SimpleAttack,
            Death,
            ReadyForBattle
        };
        public static string[] SimpleAnimationTriggers = new string[] { "DoSimpleAttack", "DoDeath", "DoReadyForBattle" };

        public static string ToName(this SimpleAnimationType type) {
            return SimpleAnimationTriggers[(int)type];
        }
    }
}