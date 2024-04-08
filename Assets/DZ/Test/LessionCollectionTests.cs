using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static Sample.LessonCollections;

namespace Tests
{
    [TestFixture]
    public sealed class LessonCollectionTests
    {
        [Test]
        public void InvertPositivesTest()
        {
            int[] array1 = {1, 2, 3};
            InvertPositives(array1);
            Assert.AreEqual(new[] {-1, -2, -3}, array1);

            int[] array2 = {-1, 2, 4, -5};
            InvertPositives(array2);
            Assert.AreEqual(new[] {-1, -2, -4, -5}, array2);
        }

        [Test]
        public void NegativeListTest()
        {
            Assert.AreEqual(new List<int>(), NegativeList(new[] {1, 2, 3}));
            Assert.AreEqual(new List<int> {-1, -5}, NegativeList(new[] {-1, 2, 4, -5}));
        }

        [Test]
        public void ShoppingListCostTest()
        {
            Dictionary<string, int> itemCosts = new Dictionary<string, int>
            {
                {"Хлеб", 50},
                {"Молоко", 100}
            };

            Assert.AreEqual(
                150,
                ShoppingListCost(new List<string> {"Хлеб", "Молоко"}, itemCosts)
            );
            Assert.AreEqual(
                150,
                ShoppingListCost(new List<string> {"Хлеб", "Молоко", "Кефир"}, itemCosts)
            );
            Assert.AreEqual(
                0.0,
                ShoppingListCost(new List<string> {"Хлеб", "Молоко", "Кефир"}, new Dictionary<string, int>())
            );
        }

        [Test]
        public void FilterByCountryCodeTest()
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                {"Quagmire", "+1-800-555-0143"},
                {"Adam's Ribs", "+82-000-555-2960"},
                {"Pharmakon Industries", "+1-800-555-6321"}
            };

            FilterByCountryCode(phoneBook, "+1");
            Assert.AreEqual(2, phoneBook.Count);

            FilterByCountryCode(phoneBook, "+1");
            Assert.AreEqual(2, phoneBook.Count);

            FilterByCountryCode(phoneBook, "+999");
            Assert.AreEqual(0, phoneBook.Count);
        }

        [Test]
        public void MeanTest()
        {
            Assert.AreEqual(0.0, Mean(Array.Empty<float>()), 1e-5);
            Assert.AreEqual(1.0, Mean(new[] {1.0f}), 1e-5);
            Assert.AreEqual(2.0, Mean(new[] {3.0f, 1.0f, 2.0f}), 1e-5);
            Assert.AreEqual(3.0, Mean(new[] {0.0f, 2.0f, 7.0f, 8.0f, -2.0f}), 1e-5);
        }

        [Test]
        public void CenterTest()
        {
            AssertArrayEquals(Array.Empty<float>(), Array.Empty<float>(), 1e-5);
            AssertArrayEquals(new[] {0.0f}, Center(new[] {3.14f}), 1e-5);
            AssertArrayEquals(new[] {1.0f, -1.0f, 0.0f}, Center(new[] {3.0f, 1.0f, 2.0f}), 1e-5);
            AssertArrayEquals(new[] {-3.0f, -1.0f, 4.0f, 5.0f, -5.0f}, Center(new[] {0.0f, 2.0f, 7.0f, 8.0f, -2.0f}),
                1e-5);
        }


        [Test]
        public void WhoAreInBothTest()
        {
            Assert.AreEqual(
                new List<string>(),
                WhoAreInBoth(new List<string>(), new List<string>())
            );
            Assert.AreEqual(
                new List<string> {"Marat"},
                WhoAreInBoth(new List<string> {"Marat", "Mikhail"}, new List<string> {"Marat", "Kirill"})
            );
            Assert.AreEqual(
                new List<string>(),
                WhoAreInBoth(new List<string> {"Marat", "Mikhail"}, new List<string> {"Sveta", "Kirill"})
            );
        }

        [Test]
        public void BuildGradesTest()
        {
            Assert.AreEqual(
                new SortedDictionary<int, List<string>>(),
                BuildGrades(new Dictionary<string, int>())
            );
            
            SortedDictionary<int, List<string>> sortedReversDict1 = BuildGrades(new Dictionary<string, int>
            {
                { "Семён", 4 },
                { "Марат", 2 },
                { "Михаил", 4 }
            });
            
            Assert.AreEqual(
                new SortedDictionary<int, List<string>>
                {
                    { 4, new List<string> { "Семён", "Михаил" } },
                    { 2, new List<string> { "Марат" } },
                },
                sortedReversDict1
            );
            
            SortedDictionary<int, List<string>> sortedReversDict2 = BuildGrades(new Dictionary<string, int>
            {
                { "Тимур", 3 },
                { "Артур", 5 },
                { "Семён", 5 },
                { "Марат", 3 },
                { "Михаил", 5 }
            });
            
            Assert.AreEqual(
                new SortedDictionary<int, List<string>>
                {
                    { 5, new List<string> { "Артур", "Семён", "Михаил" } },
                    { 3, new List<string> { "Тимур", "Марат" } },
                },
                sortedReversDict2
            );
            
            foreach ((int gradeDict1, List<string> namesDict1) in sortedReversDict1)
            {
                if (sortedReversDict2.TryGetValue(gradeDict1, out List<string> namesDict2))
                {
                    namesDict2.AddRange(namesDict1);
                }
                else
                {
                    sortedReversDict2.Add(gradeDict1, namesDict1);
                }
            }
            
            Assert.AreEqual(
                new List<int>() {5, 4, 3, 2},
                sortedReversDict2.Keys.ToList());
        }

        [Test]
        public void MergePhoneBooksTest()
        {
            Assert.AreEqual(
                new Dictionary<string, string> {{"Emergency", "112"}},
                MergePhoneBooks(
                    new Dictionary<string, string> {{"Emergency", "112"}},
                    new Dictionary<string, string> {{"Emergency", "112"}})
            );

            Assert.AreEqual(
                new Dictionary<string, string> {{"Emergency", "112"}, {"Police", "02"}},
                MergePhoneBooks(
                    new Dictionary<string, string> {{"Emergency", "112"}},
                    new Dictionary<string, string> {{"Emergency", "112"}, {"Police", "02"}})
            );

            Assert.AreEqual(
                new Dictionary<string, string> {{"Emergency", "112, 911"}, {"Police", "02"}},
                MergePhoneBooks(
                    new Dictionary<string, string> {{"Emergency", "112"}},
                    new Dictionary<string, string> {{"Emergency", "911"}, {"Police", "02"}})
            );

            Assert.AreEqual(
                new Dictionary<string, string> {{"Emergency", "112, 911"}, {"Fire department", "01"}, {"Police", "02"}},
                MergePhoneBooks(
                    new Dictionary<string, string> {{"Emergency", "112"}, {"Fire department", "01"}},
                    new Dictionary<string, string> {{"Emergency", "911"}, {"Police", "02"}})
            );
        }

        [Test]
        public void ExtractRepeatsTest()
        {
            Assert.AreEqual(
                new Dictionary<string, int>(),
                ExtractRepeats(new List<string>())
            );
            Assert.AreEqual(
                new Dictionary<string, int> {{"a", 2}},
                ExtractRepeats(new List<string> {"a", "b", "a"})
            );
            Assert.AreEqual(
                new Dictionary<string, int>(),
                ExtractRepeats(new List<string> {"a", "b", "c"})
            );
        }

        [Test]
        public void RomanTest()
        {
            Assert.AreEqual("I", Roman(1));
            Assert.AreEqual("MMM", Roman(3000));
            Assert.AreEqual("MCMLXXVIII", Roman(1978));
            Assert.AreEqual("DCXCIV", Roman(694));
            Assert.AreEqual("XLIX", Roman(49));
        }

        [Test]
        public void BackPackingTest()
        {
            Assert.AreEqual(
                new HashSet<string> {"Кубок"},
                BagPacking(
                    new Dictionary<string, (int weight, int price)>
                    { 
                        {"Кубок", (500, 2000)},
                        {"Слиток",(1000, 5000)}
                    }, 
                    850
                )
            );
            Assert.AreEqual(
                new HashSet<string>(),
                BagPacking(
                    new Dictionary<string, (int weight, int price)>
                    {
                        {"Кубок", (500, 2000)},
                        {"Слиток", (1000, 5000)}
                    },
                    450
                )
            );
            Assert.AreEqual(
                new HashSet<string>(){"Кубок", "Тарелка"},
                BagPacking(
                    new Dictionary<string, (int weight, int price)>
                    {
                        {"Кольчуга", (80, 1000)},
                        {"Кубок", (50, 900)},
                        {"Тарелка", (50, 900)},
                        {"Перстень", (10, 400)}
                    },
                    100
                )
            );
            Assert.AreEqual(
                new HashSet<string>(){"Кубок", "Тарелка", "Перстень"},
                BagPacking(
                    new Dictionary<string, (int weight, int price)>
                    {
                        {"Кольчуга", (80, 1000)},
                        {"Кубок", (44, 900)},
                        {"Тарелка", (43, 900)},
                        {"Перстень", (10, 400)}
                    },
                    100
                )
            );
            Assert.AreEqual(
                new HashSet<string>(){"Перстень", "Кубок", "Тарелка", },
                BagPacking(
                    new Dictionary<string, (int weight, int price)>
                    {
                        {"Перстень", (10, 400)},
                        {"Кольчуга", (80, 1000)},
                        {"Кубок", (44, 900)},
                        {"Тарелка", (43, 900)},
                    },
                    100
                )
            );
            Assert.AreEqual(
                new HashSet<string>(){"Кубок", "Тарелка"},
                BagPacking(
                    new Dictionary<string, (int weight, int price)>
                    {
                        {"Кольчуга", (80, 1000)},
                        {"Кубок", (44, 900)},
                        {"Тарелка", (43, 900)},
                        {"Перстень", (10, 400)}
                    },
                    96
                )
            );
        }

        private static void AssertArrayEquals(float[] expected, float[] actual, double delta)
        {
            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], delta);
            }
        }
    }
}