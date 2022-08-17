using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 187. 重复的DNA序列 | 难度：中等 | 标签：位运算、哈希表、字符串、滑动窗口、哈希函数、滚动哈希
    /// DNA序列 由一系列核苷酸组成，缩写为 'A', 'C', 'G' 和 'T'.。
    /// 
    /// 例如，"ACGAATTCCG" 是一个 DNA序列 。
    /// 在研究 DNA 时，识别 DNA 中的重复序列非常有用。
    /// 
    /// 给定一个表示 DNA序列 的字符串 s ，返回所有在 DNA 分子中出现不止一次的 长度为 10 的序列(子字符串)。你可以按 任意顺序 返回答案。
    /// 
    /// 示例 1：
    /// 输入：s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
    /// 输出：["AAAAACCCCC","CCCCCAAAAA"]
    /// 
    /// 示例 2：
    /// 输入：s = "AAAAAAAAAAAAA"
    /// 输出：["AAAAAAAAAA"]
    /// 
    /// 提示：
    /// 0 <= s.length <= 105
    /// s[i]=='A'、'C'、'G' or 'T'
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/repeated-dna-sequences
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution187
    {
        /// <summary>
        /// 执行用时：144 ms, 在所有 C# 提交中击败了 72.13% 的用户
        /// 内存消耗：50.4 MB, 在所有 C# 提交中击败了 73.77% 的用户
        /// 通过测试用例：31 / 31
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            if (s.Length < 10) return new List<string>();
            var result = new HashSet<string>();
            var set = new HashSet<string>();
            var first10 = s.Substring(0, 10);
            var sb = new StringBuilder(first10);
            set.Add(first10);
            for (int i = 10; i < s.Length; i++)
            {
                sb.Remove(0, 1).Append(s[i]);
                var seq10 = sb.ToString();
                if (set.Contains(seq10)) result.Add(seq10);
                else set.Add(seq10);
            }

            return result.ToList();
        }
    }
}