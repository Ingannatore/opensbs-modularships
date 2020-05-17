using System.Collections.Generic;

namespace ModularShips.Models
{
    public abstract class IndexedValues<T1, T2>
    {
        public IDictionary<T1, T2> Values { get; }

        protected IndexedValues()
        {
            Values = new Dictionary<T1, T2>();
        }
    }
}
