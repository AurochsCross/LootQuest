using System.Collections.Generic;
using System.Linq;

namespace LootQuest.Models {
    public class Representable {
        private List<object> _representables = new List<object>();

        public void AddRepresentable(object representable)
        {
            _representables.Add(representable);
        }

        public T GetRepresentable<T>()
        {
            return (T)_representables.FirstOrDefault(x => x is T);
            
        }
    }
}