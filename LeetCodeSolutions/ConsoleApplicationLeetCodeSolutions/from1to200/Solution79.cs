﻿namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 79. 单词搜索 | 难度：中等 | 标签：数组、回溯、矩阵
    /// 给定一个 m x n 二维字符网格 board 和一个字符串单词 word 。如果 word 存在于网格中，返回 true ；否则，返回 false 。
    /// 
    /// 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
    /// 
    /// 示例 1：
    /// 输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
    /// 输出：true
    /// 
    /// 示例 2：
    /// 输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
    /// 输出：true
    /// 
    /// 示例 3：
    /// 输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
    /// 输出：false
    /// 
    /// 提示：
    /// m == board.length
    /// n = board[i].length
    /// 1 <= m, n <= 6
    /// 1 <= word.length <= 15
    /// board 和 word 仅由大小写英文字母组成
    /// 
    /// 进阶：你可以使用搜索剪枝的技术来优化解决方案，使其在 board 更大的情况下可以更快解决问题？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/word-search
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution79
    {
        /// <summary>
        /// 执行用时：220 ms, 在所有 C# 提交中击败了 68.72% 的用户
        /// 内存消耗：39.8 MB, 在所有 C# 提交中击败了 34.12% 的用户
        /// 通过测试用例：84 / 84
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (Dfs(board, i, j, word, 0)) return true;
                }
            }

            return false;
        }

        private bool Dfs(char[][] board, int i, int j, string word, int idx)
        {
            if (idx == word.Length) return true;
            if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length || board[i][j] != word[idx]) return false;
            var backup = board[i][j];
            board[i][j] = '#';
            var result = Dfs(board, i - 1, j, word, idx + 1) || Dfs(board, i + 1, j, word, idx + 1) ||
                         Dfs(board, i, j - 1, word, idx + 1) || Dfs(board, i, j + 1, word, idx + 1);
            board[i][j] = backup;
            return result;
        }
    }
}