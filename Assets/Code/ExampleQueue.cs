using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class ExampleQueue : MonoBehaviour
    {
        private readonly Queue<GameObject> _cached = new();
        private int _xPosition = -4;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                primitive.transform.position = new Vector3(_xPosition, 0, 0);
                _cached.Enqueue(primitive);
                _xPosition++;
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                if (_cached.Count != 0)
                {
                    GameObject dequeue = _cached.Dequeue();
                    Destroy(dequeue);
                    _xPosition--;
                }
            }
            
            if (Input.GetMouseButtonDown(2))
            {
                if (_cached.Count != 0)
                {
                    GameObject peek = _cached.Peek();
                    peek.GetComponent<Renderer>().material.color = Random.ColorHSV();
                }
            }
        }
    }
}
