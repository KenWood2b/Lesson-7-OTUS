using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public enum Team
    {
        None = -1,
        Red = 0,
        Blue = 1,
        Green = 2
    }
    
    
    public sealed class ExampleDictionary
    {
        private readonly Dictionary<Team, List<GameObject>> _teams = new();

        private void Start()
        {
            if (_teams.ContainsKey(Team.Red))
            {
                List<GameObject> gameObjects = _teams[Team.Red];
                gameObjects.Add(GetPrimitive(Team.Red));
            }
            else
            {
                List<GameObject> gameObjects = new List<GameObject>();
                gameObjects.Add(GetPrimitive(Team.Red));
                _teams.Add(Team.Red, gameObjects);
            }

            _teams[Team.Green] = new List<GameObject>();
            
            foreach (KeyValuePair<Team, List<GameObject>> keyValuePair in _teams)
            {
                Debug.LogError(keyValuePair.Key);
            }

            Dictionary<List<bool>, Dictionary<bool, HashSet<List<GameObject>>>> t =
                new Dictionary<List<bool>, Dictionary<bool, HashSet<List<GameObject>>>>
                {{
                        new List<bool>(), new Dictionary<bool, HashSet<List<GameObject>>>
                        {
                            {
                                true, new HashSet<List<GameObject>>
                                {
                                    new List<GameObject>()
                                }
                            }
                        }
                    }
                };
            
            if (_teams.TryGetValue(Team.Blue, out List<GameObject> _))
            {
               // players.Add();
            }
        }

        private static GameObject GetPrimitive(Team red)
        {
            GameObject result = null;
            switch (red)
            {
                case Team.Red:
                    result = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    result.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case Team.Blue:
                    result = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    result.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case Team.Green:
                    result = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    result.GetComponent<Renderer>().material.color = Color.green;
                    break;
            }

            return result;
        }
    }
}
