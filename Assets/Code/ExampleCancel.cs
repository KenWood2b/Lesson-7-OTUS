using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class ExampleCancel : MonoBehaviour
    {
        private readonly Stack<Vector3> _cached = new();

        private void Start()
        {
            _cached.Push(transform.position);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up);
                _cached.Push(transform.position);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down);
                _cached.Push(transform.position);

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left);
                _cached.Push(transform.position);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right);
                _cached.Push(transform.position);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_cached.Count != 0)
                {
                    transform.position = _cached.Pop();
                }
                else
                {
                    _cached.Push(transform.position);
                }
            }
        }
    }
}
