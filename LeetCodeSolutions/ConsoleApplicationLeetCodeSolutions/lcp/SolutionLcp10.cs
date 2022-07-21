using System;

namespace ConsoleApplicationLeetCodeSolutions.lcp
{
    /// <summary>
    /// LCP 10. 二叉树任务调度 | 难度：困难 | 标签：树、深度优先搜索、动态规划、二叉树
    /// 任务调度优化是计算机性能优化的关键任务之一。在任务众多时，不同的调度策略可能会得到不同的总体执行时间，因此寻求一个最优的调度方案是非常有必要的。
    /// 
    /// 通常任务之间是存在依赖关系的，即对于某个任务，你需要先完成他的前导任务（如果非空），才能开始执行该任务。
    /// 我们保证任务的依赖关系是一棵二叉树，其中 root 为根任务，root.left 和 root.right 为他的两个前导任务（可能为空），root.val 为其自身的执行时间。
    /// 
    /// 在一个 CPU 核执行某个任务时，我们可以在任何时刻暂停当前任务的执行，并保留当前执行进度。在下次继续执行该任务时，会从之前停留的进度开始继续执行。暂停的时间可以不是整数。
    /// 
    /// 现在，系统有两个 CPU 核，即我们可以同时执行两个任务，但是同一个任务不能同时在两个核上执行。给定这颗任务树，请求出所有任务执行完毕的最小时间。
    /// 
    /// 示例 1：
    /// 输入：root = [47, 74, 31]
    /// 输出：121
    /// 解释：根节点的左右节点可以并行执行31分钟，剩下的43+47分钟只能串行执行，因此总体执行时间是121分钟。
    /// 
    /// 示例 2：
    /// 输入：root = [15, 21, null, 24, null, 27, 26]
    /// 输出：87
    /// 
    /// 示例 3：
    /// 输入：root = [1,3,2,null,null,4,4]
    /// 输出：7.5
    /// 限制：
    /// 1 <= 节点数量 <= 1000
    /// 1 <= 单节点执行时间 <= 1000
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/er-cha-shu-ren-wu-diao-du
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class SolutionLcp10
    {
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
        /// <summary>
        /// 执行用时：132 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：47.3 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// 通过测试用例：123 / 123
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public double MinimalExecTime(TreeNode root)
        {
            var (paraTime, seriTime) = MinimalExecTimePS(root);
            return paraTime + seriTime;
        }

        private (double paraTime, double seriTime) MinimalExecTimePS(TreeNode root)
        {
            if (root.left == null && root.right == null)
            {
                return (0, root.val);
            }

            if (root.left == null)
            {
                var (paraTime, seriTime) = MinimalExecTimePS(root.right);
                return (paraTime, root.val + seriTime);
            }

            if (root.right == null)
            {
                var (paraTime, seriTime) = MinimalExecTimePS(root.left);
                return (paraTime, root.val + seriTime);
            }

            var (paraTime1, seriTime1) = MinimalExecTimePS(root.left);
            var (paraTime2, seriTime2) = MinimalExecTimePS(root.right);
            double paraSeriTime = Math.Min(seriTime1, seriTime2);
            // leftSeriTime1 和 2 中最多只有一个非零的
            double leftSeriTime1 = seriTime1 - paraSeriTime;
            double leftSeriTime2 = seriTime2 - paraSeriTime;
            double paraSeriTime1 = Math.Min(paraTime2 * 2, leftSeriTime1);
            double paraSeriTime2 = Math.Min(paraTime1 * 2, leftSeriTime2);
            double seriTimeLeft = leftSeriTime1 - paraSeriTime1 + leftSeriTime2 - paraSeriTime2;
            return (paraTime1 + paraTime2 + paraSeriTime + (paraSeriTime1 + paraSeriTime2) / 2.0,
                seriTimeLeft + root.val);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }

        public void Test()
        {
            var root = new TreeNode(47);
            root.left = new TreeNode(74);
            root.right = new TreeNode(31);
            Console.WriteLine(MinimalExecTime(root));
        }
    }
}