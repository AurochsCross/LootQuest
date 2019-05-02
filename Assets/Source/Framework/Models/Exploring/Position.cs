namespace LootQuest.Models.Exploring {
    public class Position {
        public int x, y;

        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Position() {
            x = 0;
            y = 0;
        }

        #region Operators

        public static Position operator +(Position first, Position second) {
            return new Position(first.x + second.x, first.y + second.y);
        }

        public static Position operator -(Position first, Position second) {
            return new Position(first.x - second.x, first.y - second.y);
        }

        public static Position operator *(Position first, Position second) {
            return new Position(first.x * second.x, first.y * second.y);
        }
        
        public static Position operator /(Position first, Position second) {
            return new Position(first.x / second.x, first.y / second.y);
        }

        public static Position operator *(Position first, int second) {
            return new Position(first.x * second, first.y * second);
        }

        public static bool operator ==(Position first, Position second) {
            return first.x == second.x && first.y == second.y;
        }

        public static bool operator !=(Position first, Position second) {
            return first.x != second.x || first.y != second.y;
        }


        #endregion
    }
}