using UnityEngine;

namespace Code
{
    public sealed class ExampleParameter
    {
        public void Main()
        {
            int i = 5;
            TestNotLink(i);
            Debug.LogError(i);

            int j = 6;
            TestRef(ref j);
            Debug.LogError(j);

            int k;
            TestOut(out k);
            TestOut(out _);
            Debug.LogError(k);

            int n = 7;
            TestIn(in n);
            Debug.LogError(n);
            
            // async not work
        }

        private void TestIn(in int i)
        {
           // i = 8;
        }

        private void TestOut(out int i)
        {
            i = 8;
        }

        private void TestRef(ref int i)
        {
           // i++;
        }

        private void TestNotLink(int i)
        {
            i++;
        }
    }
}
