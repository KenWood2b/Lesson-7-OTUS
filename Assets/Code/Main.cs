using UnityEngine;

namespace Code
{
    public sealed class Main : MonoBehaviour
    {
        public ExampleIndexers ExampleIndexers;
        
        private void Start()
        {
            // ExampleIndexers[0] = gameObject;
            new ExampleParameter().Main();
        }
    }
}
