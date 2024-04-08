using System.Collections.Generic;

namespace Code
{
    public sealed class ExampleHashSet
    {
        private readonly HashSet<int> _cached = new ();

        private void Test()
        {
            if (_cached.Add(1))
            {
                //_cached[0]
            }

            foreach (int i in _cached)
            {
                
            }
            
            for (var i = 0; i < _cached.Count; i++)
            {
                
            }
        }
    }
}
