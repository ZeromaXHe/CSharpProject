using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 127. 单词接龙 | 难度：困难 | 标签：广度优先搜索、哈希表、字符串
    /// 字典 wordList 中从单词 beginWord 和 endWord 的 转换序列 是一个按下述规格形成的序列 beginWord -> s1 -> s2 -> ... -> sk：
    /// 
    /// 每一对相邻的单词只差一个字母。
    /// 对于 1 <= i <= k 时，每个 si 都在 wordList 中。注意， beginWord 不需要在 wordList 中。
    /// sk == endWord
    /// 给你两个单词 beginWord 和 endWord 和一个字典 wordList ，返回 从 beginWord 到 endWord 的 最短转换序列 中的 单词数目 。如果不存在这样的转换序列，返回 0 。
    /// 
    /// 示例 1：
    /// 输入：beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
    /// 输出：5
    /// 解释：一个最短转换序列是 "hit" -> "hot" -> "dot" -> "dog" -> "cog", 返回它的长度 5。
    /// 
    /// 示例 2：
    /// 输入：beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log"]
    /// 输出：0
    /// 解释：endWord "cog" 不在字典中，所以无法进行转换。
    /// 
    /// 提示：
    /// 1 <= beginWord.length <= 10
    /// endWord.length == beginWord.length
    /// 1 <= wordList.length <= 5000
    /// wordList[i].length == beginWord.length
    /// beginWord、endWord 和 wordList[i] 由小写英文字母组成
    /// beginWord != endWord
    /// wordList 中的所有字符串 互不相同
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/word-ladder
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution127
    {
        /// <summary>
        /// 执行用时：236 ms, 在所有 C# 提交中击败了 53.06% 的用户
        /// 内存消耗：43.3 MB, 在所有 C# 提交中击败了 61.22% 的用户
        /// 通过测试用例：50 / 50
        ///
        /// 题解虚拟节点的思路值得学习，直接把建图 O(n^2) 的复杂度减到 O(n * m) 了（m 为字符串长度）
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var visit = new bool[wordList.Count];
            var map = new Dictionary<int, List<int>>();
            var queue = new Queue<int>();
            var endIdx = -1;
            /*
             * 不引入 wordArr 而是直接访问 wordList 的话：
             * 执行用时：588 ms, 在所有 C# 提交中击败了 22.45% 的用户
             * 内存消耗：43.2 MB, 在所有 C# 提交中击败了 63.27% 的用户
             * 通过测试用例：50 / 50
             */
            var wordArr = new string[wordList.Count];
            var i = 0;
            foreach (var word in wordList)
            {
                if (endWord.Equals(word)) endIdx = i;

                if (OneCharDiff(beginWord, word))
                {
                    queue.Enqueue(i);
                    visit[i] = true;
                }

                wordArr[i] = word;

                for (int j = 0; j < i; j++)
                {
                    if (OneCharDiff(wordArr[i], wordArr[j]))
                    {
                        if (!map.ContainsKey(i)) map[i] = new List<int>();
                        map[i].Add(j);
                        if (!map.ContainsKey(j)) map[j] = new List<int>();
                        map[j].Add(i);
                    }
                }

                i++;
            }

            if (endIdx == -1) return 0;

            // BFS
            var dist = 2;
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

            return 0;
        }

        private bool OneCharDiff(string s1, string s2)
        {
            var diff = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (diff == 1) return false;
                    diff++;
                }
            }

            return diff == 1;
        }
    }
}