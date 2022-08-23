using System;

namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 782. 变为棋盘 | 难度：困难 | 标签：位运算、数组、数学、矩阵
    /// 一个 n x n 的二维网络 board 仅由 0 和 1 组成 。每次移动，你能任意交换两列或是两行的位置。
    /// 
    /// 返回 将这个矩阵变为  “棋盘”  所需的最小移动次数 。如果不存在可行的变换，输出 -1。
    /// 
    /// “棋盘” 是指任意一格的上下左右四个方向的值均与本身不同的矩阵。
    /// 
    /// 示例 1:
    /// 输入: board = [[0,1,1,0],[0,1,1,0],[1,0,0,1],[1,0,0,1]]
    /// 输出: 2
    /// 解释:一种可行的变换方式如下，从左到右：
    /// 第一次移动交换了第一列和第二列。
    /// 第二次移动交换了第二行和第三行。
    /// 
    /// 示例 2:
    /// 输入: board = [[0, 1], [1, 0]]
    /// 输出: 0
    /// 解释: 注意左上角的格值为0时也是合法的棋盘，也是合法的棋盘.
    /// 
    /// 示例 3:
    /// 输入: board = [[1, 0], [1, 0]]
    /// 输出: -1
    /// 解释: 任意的变换都不能使这个输入变为合法的棋盘。
    /// 
    /// 提示：
    /// n == board.length
    /// n == board[i].length
    /// 2 <= n <= 30
    /// board[i][j] 将只包含 0或 1
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/transform-to-chessboard
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution782
    {
        /// <summary>
        /// 执行用时：84 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：39.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// 通过测试用例：126 / 126
        ///
        /// 参考题解做的
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int MovesToChessboard(int[][] board)
        {
            int n = board.Length;
            int rowMask = 0, colMask = 0;

            /* 检查棋盘的第一行与第一列 */
            for (int i = 0; i < n; i++)
            {
                rowMask |= board[0][i] << i;
                colMask |= board[i][0] << i;
            }

            int reverseRowMask = ((1 << n) - 1) ^ rowMask;
            int reverseColMask = ((1 << n) - 1) ^ colMask;
            int rowCnt = 0, colCnt = 0;
            for (int i = 0; i < n; i++)
            {
                int currRowMask = 0;
                int currColMask = 0;
                for (int j = 0; j < n; j++)
                {
                    currRowMask |= board[i][j] << j;
                    currColMask |= board[j][i] << j;
                }

                /* 检测每一行的状态是否合法 */
                if (currRowMask != rowMask && currRowMask != reverseRowMask) return -1;
                /* 记录与第一行相同的行数 */
                if (currRowMask == rowMask) rowCnt++;
                /* 检测每一列的状态是否合法 */
                if (currColMask != colMask && currColMask != reverseColMask) return -1;
                /* 记录与第一列相同的列数 */
                if (currColMask == colMask) colCnt++;
            }

            int rowMoves = GetMoves(rowMask, rowCnt, n);
            int colMoves = GetMoves(colMask, colCnt, n);
            return (rowMoves == -1 || colMoves == -1) ? -1 : (rowMoves + colMoves);
        }

        public int GetMoves(int mask, int count, int n)
        {
            int ones = BitCount(mask);
            if ((n & 1) == 1)
            {
                /* 如果 n 为奇数，则每一行中 1 与 0 的数目相差为 1，且满足相邻行交替 */
                if (Math.Abs(n - 2 * ones) != 1 || Math.Abs(n - 2 * count) != 1) return -1;
                /* 以 0 为开头的最小交换次数 */
                if (ones == n >> 1) return n / 2 - BitCount((int) (mask & 0xAAAAAAAA));
                return (n + 1) / 2 - BitCount(mask & 0x55555555);
            }

            /* 如果 n 为偶数，则每一行中 1 与 0 的数目相等，且满足相邻行交替 */
            if (ones != n >> 1 || count != n >> 1) return -1;
            /* 找到行的最小交换次数 */
            int count0 = n / 2 - BitCount((int) (mask & 0xAAAAAAAA));
            int count1 = n / 2 - BitCount(mask & 0x55555555);
            return Math.Min(count0, count1);
        }

        private static int BitCount(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (i + (i >> 4)) & 0x0f0f0f0f;
            i = i + (i >> 8);
            i = i + (i >> 16);
            return i & 0x3f;
        }
    }
}