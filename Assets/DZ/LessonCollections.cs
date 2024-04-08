using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable ParameterTypeCanBeEnumerable.Global
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator

namespace Sample
{
    public static class LessonCollections
    {
        // Основное количество баллов = 10
        // Дополнительное количество баллов = 10

        ///Пример: Изменить знак для всех положительных элементов массива
        public static void InvertPositives(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];
                if (element > 0)
                {
                    array[i] = -element;
                }
            }
        }

        ///Пример: Выделить в список отрицательные элементы из заданного массива
        public static List<int> NegativeList(int[] array)
        {
            List<int> result = new List<int>();
            foreach (int element in array)
            {
                if (element < 0)
                {
                    result.Add(element);
                }
            }

            return result;
        }

        /**
         * Пример
         *
         * Для заданного списка покупок `shoppingList` посчитать его общую стоимость
         * на основе цен из `costs`. В случае неизвестной цены считать, что товар
         * игнорируется.
         */
        public static float ShoppingListCost(List<string> shoppingList, Dictionary<string, int> costs)
        {
            int totalCost = 0;

            foreach (string item in shoppingList)
            {
                if (costs.TryGetValue(item, out int itemCost))
                {
                    totalCost += itemCost;
                }
            }

            return totalCost;
        }

        /**
         * Пример
         *
         * Для набора "имя"-"номер телефона" `phoneBook` оставить только такие пары,
         * для которых телефон начинается с заданного кода страны `countryCode`
         */
        public static void FilterByCountryCode(Dictionary<string, string> phoneBook, string countryCode)
        {
            List<string> namesToRemove = new List<string>();

            foreach (var kv in phoneBook)
            {
                string name = kv.Key;
                string phone = kv.Value;

                if (!phone.StartsWith(countryCode))
                {
                    namesToRemove.Add(name);
                }
            }

            foreach (string name in namesToRemove)
            {
                phoneBook.Remove(name);
            }
        }

        /**
         * Простая (1 балл)
         *
         * Рассчитать среднее арифметическое элементов массива. Вернуть 0, если массив пуст.
         */
        public static float Mean(float[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            float sum = 0;
            foreach (float num in array)
            {
                sum += num;
            }

            return sum / array.Length;
        }

        /**
         * Простая (1 балл)
         *
         * Центрировать массив, уменьшив каждый элемент на среднее арифметическое всех элементов.
         * Если массив пуст, не делать ничего. Вернуть изменённый массив.
         */
        public static float[] Center(float[] array)
        {
            float sum = 0;
            foreach (float num in array)
            {
                sum += num;
            }

            float average = sum / array.Length;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] -= average;
            }

            return array;
        }

        /**
         * Простая (1 балл)
         *
         * Для двух списков людей найти людей, встречающихся в обоих списках.
         * В выходном списке не должно быть повторяющихся элементов,
         * т. е. WhoAreInBoth(new List {"Иван", "Семён, "Марат"}, new List{"Петр", "Марат"}) == new List {"Марат"}
         */
        public static List<string> WhoAreInBoth(List<string> list1, List<string> list2)
        {
            List<string> result = new List<string>();

            foreach (string person1 in list1)
            {
                if (list2.Contains(person1) && !result.Contains(person1))
                {
                    result.Add(person1);
                }
            }

            return result;
        }

        /**
         * Средняя (2 балл)
         *
         * По заданному ассоциативному массиву "студент"-"оценка за экзамен" построить
         * обратно сортированный словарь "оценка за экзамен"-"список студентов с этой оценкой".
         * (т.е вначале должна идти группа студентов с большим балом)
         * 
         * Например:
         *   BuildGrades(new Dictionary { {"Семён", 5}, {"Марат", 3}, {"Михаил", 5}})
         *     => new SortedDictionary { {5, new List {"Семён", "Михаил"}}, {3, new List{"Марат"}}} 
         */
        public static SortedDictionary<int, List<string>> BuildGrades(Dictionary<string, int> grades)
        {
            SortedDictionary<int, List<string>> sortedGrades = new SortedDictionary<int, List<string>>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            foreach (var pair in grades)
            {
                if (!sortedGrades.ContainsKey(pair.Value))
                {
                    sortedGrades[pair.Value] = new List<string>();
                }
                sortedGrades[pair.Value].Add(pair.Key);
            }

            return sortedGrades;
        }

        /**
         * Средняя (2 балла)
         *
         * Объединить два ассоциативных массива `mapA` и `mapB` с парами
         * "имя"-"номер телефона" в итоговый ассоциативный массив, склеивая
         * значения для повторяющихся ключей через запятую.
         * В случае повторяющихся *ключей* значение из mapA должно быть
         * перед значением из mapB.
         *
         * Повторяющиеся *значения* следует добавлять только один раз.
         *
         * Например:
         *   MergePhoneBooks(
         *     new Dictionary {{"Emergency", "112"}, {"Police", "02"}},
         *     new Dictionary {{"Emergency", "911"}, {"Police", "02"}}
         *   ) => new Dictionary {{"Emergency", "112, 911"}, {"Police", "02"}}
         */
        public static Dictionary<string, string> MergePhoneBooks(
            Dictionary<string, string> mapA,
            Dictionary<string, string> mapB
        )
        {
            Dictionary<string, string> mergedMap = new Dictionary<string, string>();

            foreach (var entry in mapA)
            {
                if (!mergedMap.ContainsKey(entry.Key))
                {
                    mergedMap.Add(entry.Key, entry.Value);
                }
                else
                {
                    mergedMap[entry.Key] += ", " + entry.Value;
                }
            }

            foreach (var entry in mapB)
            {
                if (!mergedMap.ContainsKey(entry.Key))
                {
                    mergedMap.Add(entry.Key, entry.Value);
                }
                else
                {
                    if (!mergedMap[entry.Key].Contains(entry.Value))
                    {
                        mergedMap[entry.Key] += ", " + entry.Value;
                    }
                }
            }

            return mergedMap;

        }

        /**
         * Средняя (2 балла)
         *
         * Найти в заданном списке повторяющиеся элементы и вернуть
         * ассоциативный массив с информацией о числе повторений
         * для каждого повторяющегося элемента.
         * Если элемент встречается только один раз, включать его в результат
         * не следует.
         *
         * Например:
         *   ExtractRepeats(new List {"a", "b", "a"}) => new Dictionary{ {"a", 2}}
         */
        public static Dictionary<string, int> ExtractRepeats(List<string> list)
        {
            Dictionary<string, int> repeats = new Dictionary<string, int>();

            foreach (string item in list)
            {
                if (repeats.ContainsKey(item))
                {
                    repeats[item]++;
                }
                else
                {
                    repeats.Add(item, 1);
                }
            }

            return repeats.Where(x => x.Value > 1).ToDictionary(x => x.Key, x => x.Value);
        }

        /**
         * Сложная (4 балла)
         *
         * Перевести натуральное число 5000 > n > 0 в римскую систему.
         * Римские цифры: 1 = I, 4 = IV, 5 = V, 9 = IX, 10 = X, 40 = XL, 50 = L,
         * 90 = XC, 100 = C, 400 = CD, 500 = D, 900 = CM, 1000 = M.
         * Например: 23 = XXIII, 44 = XLIV, 100 = C
         */
        public static string Roman(int n)
        {
            string[] romanSymbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            string result = "";

            for (int i = 0; i < romanSymbols.Length; i++)
            {
                while (n >= arabicValues[i])
                {
                    result += romanSymbols[i];
                    n -= arabicValues[i];
                }
            }

            return result;
        }

        /**
         * Очень сложная (максимум  6 балла):
         * - рещение методом перебора (2 балла):
         * - рещение методами "Динамического программирования" (6 балла):
         *
         * Входными данными является ассоциативный массив
         * "название сокровища"-"пара (вес сокровища, цена сокровища)"
         * и вместимость вашего рюкзака.
         * Необходимо вернуть множество сокровищ с максимальной суммарной стоимостью,
         * которые вы можете унести в рюкзаке.
         * Примечание.
         * В этом примере Рюкзак 0-1 (англ. 0-1 Knapsack Problem) не более одного экземпляра каждого предмета.
         * Вес сокровища >0; Цена сокровища > 0
         * 
         * Перед решением этой задачи лучше прочитать статью Википедии "Динамическое программирование".
         * 
         * Например:
         *   BagPacking(
         *     new Dictionary { {"Кубок", (500, 2000)}, {"Слиток", (1000, 5000)} },
         *     850
         *   ) => new HashSet{"Кубок"}
         *   BagPacking(
         *     new Dictionary { {"Кубок" to (500, 2000)}, {"Слиток", (1000, 5000)} },
         *     450
         *   ) => new HashSet()
         */
        public static HashSet<string> BagPacking(Dictionary<string, (int weight, int price)> treasures, int capacity)
        {
            int n = treasures.Count;
            int[,] dp = new int[n + 1, capacity + 1];

            string[] names = new string[n];
            int[] weights = new int[n];
            int[] prices = new int[n];

            int j = n - 1;
            foreach (var treasure in treasures)
            {
                names[j] = treasure.Key;
                weights[j] = treasure.Value.weight;
                prices[j] = treasure.Value.price;
                j--;
            }

            for (int k = 1; k <= n; k++)
            {
                for (int l = 1; l <= capacity; l++)
                {
                    if (weights[k - 1] <= l)
                    {
                        dp[k, l] = Math.Max(dp[k - 1, l], dp[k - 1, l - weights[k - 1]] + prices[k - 1]);
                    }
                    else
                    {
                        dp[k, l] = dp[k - 1, l];
                    }
                }
            }

            HashSet<string> selectedTreasures = new HashSet<string>();
            int res = dp[n, capacity];
            int w = capacity;

            for (int m = n; m > 0 && res > 0; m--)
            {
                if (res != dp[m - 1, w])
                {
                    if (!selectedTreasures.Contains(names[m - 1]))
                    {
                        selectedTreasures.Add(names[m - 1]);
                        res -= prices[m - 1];
                        w -= weights[m - 1];
                    }
                }
            }

            return selectedTreasures;

        }
    }
}

