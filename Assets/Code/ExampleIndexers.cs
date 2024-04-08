using UnityEngine;

namespace Code
{
    public sealed class ExampleIndexers : MonoBehaviour
    {
        public GameObject[] Cached = new GameObject[10];
        
        public GameObject this[int index]
        {
            get => Cached[index];
            set => Cached[index] = value;
        }
    }
}
