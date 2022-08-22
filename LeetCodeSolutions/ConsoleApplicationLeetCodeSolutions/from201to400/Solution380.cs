using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 380. O(1) 时间插入、删除和获取随机元素 | 难度：中等 | 标签：设计、数组、哈希表、数学、随机化
    /// 实现RandomizedSet 类：
    /// 
    /// RandomizedSet() 初始化 RandomizedSet 对象
    /// bool insert(int val) 当元素 val 不存在时，向集合中插入该项，并返回 true ；否则，返回 false 。
    /// bool remove(int val) 当元素 val 存在时，从集合中移除该项，并返回 true ；否则，返回 false 。
    /// int getRandom() 随机返回现有集合中的一项（测试用例保证调用此方法时集合中至少存在一个元素）。每个元素应该有 相同的概率 被返回。
    /// 你必须实现类的所有函数，并满足每个函数的 平均 时间复杂度为 O(1) 。
    /// 
    /// 示例：
    /// 输入
    /// ["RandomizedSet", "insert", "remove", "insert", "getRandom", "remove", "insert", "getRandom"]
    /// [[], [1], [2], [2], [], [1], [2], []]
    /// 输出
    /// [null, true, false, true, 2, true, false, 2]
    /// 
    /// 解释
    /// RandomizedSet randomizedSet = new RandomizedSet();
    /// randomizedSet.insert(1); // 向集合中插入 1 。返回 true 表示 1 被成功地插入。
    /// randomizedSet.remove(2); // 返回 false ，表示集合中不存在 2 。
    /// randomizedSet.insert(2); // 向集合中插入 2 。返回 true 。集合现在包含 [1,2] 。
    /// randomizedSet.getRandom(); // getRandom 应随机返回 1 或 2 。
    /// randomizedSet.remove(1); // 从集合中移除 1 ，返回 true 。集合现在包含 [2] 。
    /// randomizedSet.insert(2); // 2 已在集合中，所以返回 false 。
    /// randomizedSet.getRandom(); // 由于 2 是集合中唯一的数字，getRandom 总是返回 2 。
    /// 
    /// 提示：
    /// -231 <= val <= 231 - 1
    /// 最多调用 insert、remove 和 getRandom 函数 2 * 105 次
    /// 在调用 getRandom 方法时，数据结构中 至少存在一个 元素。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/insert-delete-getrandom-o1
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution380
    {
        /// <summary>
        /// 执行用时：320 ms, 在所有 C# 提交中击败了 51.72% 的用户
        /// 内存消耗：85.8 MB, 在所有 C# 提交中击败了 55.17% 的用户
        /// 通过测试用例：19 / 19
        /// </summary>
        public class RandomizedSet
        {
            private int id = 0;
            private Dictionary<int, int> dict;
            private List<int> snapshot;
            private Random rand;
            private bool needRegenerateSnapshot;

            public RandomizedSet()
            {
                dict = new Dictionary<int, int>();
                snapshot = new List<int>();
                rand = new Random();
            }

            public bool Insert(int val)
            {
                if (dict.ContainsKey(val)) return false;
                dict[val] = id++;
                if (!needRegenerateSnapshot) snapshot.Add(val);
                return true;
            }

            public bool Remove(int val)
            {
                if (!dict.ContainsKey(val)) return false;
                if (!needRegenerateSnapshot)
                {
                    if (val != snapshot[snapshot.Count - 1]) needRegenerateSnapshot = true;
                    else snapshot.RemoveAt(snapshot.Count - 1);
                }

                dict.Remove(val);
                return true;
            }

            public int GetRandom()
            {
                if (needRegenerateSnapshot)
                {
                    snapshot = dict.Keys.ToList();
                    needRegenerateSnapshot = false;
                }

                return snapshot[rand.Next(snapshot.Count)];
            }
        }

        /**
         * Your RandomizedSet object will be instantiated and called as such:
         * RandomizedSet obj = new RandomizedSet();
         * bool param_1 = obj.Insert(val);
         * bool param_2 = obj.Remove(val);
         * int param_3 = obj.GetRandom();
         */
    }
}