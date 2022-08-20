using System;
using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 433. 最小基因变化 | 难度：中等 | 标签：广度优先搜索、哈希表、字符串
    /// 基因序列可以表示为一条由 8 个字符组成的字符串，其中每个字符都是 'A'、'C'、'G' 和 'T' 之一。
    /// 
    /// 假设我们需要调查从基因序列 start 变为 end 所发生的基因变化。一次基因变化就意味着这个基因序列中的一个字符发生了变化。
    /// 
    /// 例如，"AACCGGTT" --> "AACCGGTA" 就是一次基因变化。
    /// 另有一个基因库 bank 记录了所有有效的基因变化，只有基因库中的基因才是有效的基因序列。（变化后的基因必须位于基因库 bank 中）
    /// 
    /// 给你两个基因序列 start 和 end ，以及一个基因库 bank ，请你找出并返回能够使 start 变化为 end 所需的最少变化次数。如果无法完成此基因变化，返回 -1 。
    /// 
    /// 注意：起始基因序列 start 默认是有效的，但是它并不一定会出现在基因库中。
    /// 
    /// 示例 1：
    /// 输入：start = "AACCGGTT", end = "AACCGGTA", bank = ["AACCGGTA"]
    /// 输出：1
    /// 
    /// 示例 2：
    /// 输入：start = "AACCGGTT", end = "AAACGGTA", bank = ["AACCGGTA","AACCGCTA","AAACGGTA"]
    /// 输出：2
    /// 
    /// 示例 3：
    /// 输入：start = "AAAAACCC", end = "AACCCCCC", bank = ["AAAACCCC","AAACCCCC","AACCCCCC"]
    /// 输出：3
    /// 
    /// 提示：
    /// start.length == 8
    /// end.length == 8
    /// 0 <= bank.length <= 10
    /// bank[i].length == 8
    /// start、end 和 bank[i] 仅由字符 ['A', 'C', 'G', 'T'] 组成
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/minimum-genetic-mutation
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution433
    {
        public void Test()
        {
            Console.WriteLine(MinMutation("AACCGGTT", "AACCGGTA", new[] {"AACCGGTA"})); // 1
            Console.WriteLine(MinMutation("AAAAAAAA", "CCCCCCCC",
                new[]
                {
                    "AAAAAAAA", "AAAAAAAC", "AAAAAACC", "AAAAACCC", "AAAACCCC", "AACACCCC", "ACCACCCC", "ACCCCCCC",
                    "CCCCCCCA", "CCCCCCCC"
                })); // 8
            Console.WriteLine(MinMutation("AAAACCCC", "CCCCCCCC",
                new[]
                {
                    "AAAACCCA", "AAACCCCA", "AACCCCCA", "AACCCCCC", "ACCCCCCC", "CCCCCCCC", "AAACCCCC", "AACCCCCC"
                })); // 8
        }

        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 33.33% 的用户
        /// 内存消耗：37.7 MB, 在所有 C# 提交中击败了 33.33% 的用户
        /// 通过测试用例：15 / 15
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public int MinMutation(string start, string end, string[] bank)
        {
            if (end.Equals(start)) return 0;
            // 初始化 int 化的基因，同时判断 end 是否在库内，获取对应索引
            var genes = new int[bank.Length];
            var endIdx = -1;
            var startGene = GeneStrToInt(start);
            for (int i = 0; i < bank.Length; i++)
            {
                genes[i] = GeneStrToInt(bank[i]);
                if (bank[i].Equals(end)) endIdx = i;
            }

            if (endIdx == -1) return -1;

            // 初始化基因转换 map，同时寻找 start 可以转换到的基因放入 queue 中作为第一跳的结果
            var visit = new bool[genes.Length];
            var map = new Dictionary<int, List<int>>();
            var queue = new Queue<int>();
            for (int i = 0; i < genes.Length; i++)
            {
                if (OneGeneMutation(startGene, genes[i]))
                {
                    queue.Enqueue(i);
                    visit[i] = true;
                }

                for (int j = i + 1; j < genes.Length; j++)
                {
                    if (OneGeneMutation(genes[i], genes[j]))
                    {
                        if (!map.ContainsKey(i)) map[i] = new List<int>();
                        map[i].Add(j);
                        if (!map.ContainsKey(j)) map[j] = new List<int>();
                        map[j].Add(i);
                    }
                }
            }

            // BFS
            var dist = 1;
            while (queue.Count > 0)
            {
                var c = queue.Count;
                while (c > 0)
                {
                    var deq = queue.Dequeue();
                    if (deq == endIdx) return dist;
                    if (map.ContainsKey(deq))
                    {
                        foreach (var to in map[deq])
                        {
                            if (!visit[to])
                            {
                                queue.Enqueue(to);
                                visit[to] = true;
                            }
                        }
                    }

                    c--;
                }

                dist++;
            }

            return -1;
        }

        private bool OneGeneMutation(int gene1, int gene2)
        {
            // 必须先判等，否则后面 lowBit 为 0 会导致除 0 错误
            if (gene1 == gene2) return false;
            var xor = gene1 ^ gene2;
            var lowBit = LowBit(xor);
            if (lowBit % 4 == 0) return xor / lowBit < 4;
            return xor == lowBit;
        }

        private int LowBit(int n) => n & -n;

        private int GeneStrToInt(string gene)
        {
            var result = 0;
            for (int i = 7; i >= 0; i--)
            {
                result <<= 2;
                result += GeneCharToInt(gene[i]);
            }

            return result;
        }

        private int GeneCharToInt(char c)
        {
            switch (c)
            {
                case 'A': return 0;
                case 'C': return 1;
                case 'G': return 2;
                // T
                default: return 3;
            }
        }
    }
}