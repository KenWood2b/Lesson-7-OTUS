using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class ExampleList : MonoBehaviour
    {
        public int[] Numbers;
        public List<int> NumbersList;

        private void Start()
        {
            NumbersList = new List<int>();
            Debug.LogError(NumbersList.Count);
            for (int i = 0; i < 10; i++)
            {
                NumbersList.Add(Random.Range(1, 10));
            }

            List<GameObject> enemies = new List<GameObject>();
            enemies.Sort(Comparison);
            //enemies.Add(gameObject);
            
            if (enemies.Contains(gameObject))
            {
                enemies.Remove(gameObject);
            }
            
            foreach (int i in NumbersList)
            {
                Debug.LogError(i);
            }
            
            for (var i = 0; i < NumbersList.Count; i++)
            {
                Debug.LogError(NumbersList[i]);
            }
            
            for (var i = NumbersList.Count - 1; i >= 0; i--)
            {
                if (NumbersList[i] % 2 == 0)
                {
                    NumbersList.RemoveAt(i);
                }
            }
            
            
            NumbersList.Sort(Comparison);
        }

        private readonly List<GameObject> _cachedList = new(128);
        private void Example()
        {
            _cachedList.Clear();
            _cachedList.AddRange(FindObjectsOfType<GameObject>());
            _cachedList.Sort(Comparison);
        }

        private static int Comparison(GameObject x, GameObject y)
        {
            int sort = -x.transform.position.sqrMagnitude.CompareTo(y.transform.position.sqrMagnitude);
            if (sort != 0)
            {
                return sort;
            }

            return x.name.CompareTo(y.name);
        }

        private static int Comparison(int x, int y)
        {
            return x.CompareTo(y);
        }
        
        private void Shuffle<T>(List<T> list)
        {  
            int n = list.Count;
            var random = new System.Random();
            for (int i = n - 1; i > 0; i--)
            {
                int r = random.Next(i + 1);
                (list[r], list[i]) = (list[i], list[r]);
            }
        }

        private void NameMethod(int a, int b)
        {
            
        }
    }
}
