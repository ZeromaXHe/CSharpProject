using System;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 222. 完全二叉树的节点个数 | 难度：中等 | 标签：树、深度优先搜索、二分查找、二叉树
    /// 给你一棵 完全二叉树 的根节点 root ，求出该树的节点个数。
    /// 
    /// 完全二叉树 的定义如下：在完全二叉树中，除了最底层节点可能没填满外，其余每层节点数都达到最大值，并且最下面一层的节点都集中在该层最左边的若干位置。若最底层为第 h 层，则该层包含 1~ 2h 个节点。
    /// 
    /// 示例 1：
    /// 输入：root = [1,2,3,4,5,6]
    /// 输出：6
    /// 
    /// 示例 2：
    /// 输入：root = []
    /// 输出：0
    /// 
    /// 示例 3：
    /// 输入：root = [1]
    /// 输出：1
    /// 
    /// 提示：
    /// 树中节点的数目范围是[0, 5 * 104]
    /// 0 <= Node.val <= 5 * 104
    /// 题目数据保证输入的树是 完全二叉树
    /// 
    /// 进阶：遍历树来统计节点是一种时间复杂度为 O(n) 的简单解决方案。你可以设计一个更快的算法吗？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/count-complete-tree-nodes
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution222
    {
        public void Test()
        {
            var root = new TreeNode(1,
                new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3, new TreeNode(6)));
            Console.WriteLine(CountNodes(root));
        }

        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         *         this.val = val;
         *         this.left = left;
         *         this.right = right;
         *     }
         * }
         */
        /// <summary>
        /// 执行用时：96 ms, 在所有 C# 提交中击败了 60.34% 的用户
        /// 内存消耗：45.7 MB, 在所有 C# 提交中击败了 31.90% 的用户
        /// 通过测试用例：18 / 18
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            var depth = 1;
            var ptr = root;
            while (ptr.left != null)
            {
                ptr = ptr.left;
                depth++;
            }

            var l = 1;
            var r = (1 << (depth - 1)) - 1;
            var lastIdx = 0;
            while (l <= r)
            {
                var mid = (l + r) / 2;
                var d = depth - 1;
                ptr = root;
                while (d > 0)
                {
                    if ((mid & (1 << (d - 1))) > 0)
                    {
                        if (ptr.right == null) break;
                        ptr = ptr.right;
                    }
                    else
                    {
                        if (ptr.left == null) break;
                        ptr = ptr.left;
                    }

                    d--;
                }

                if (d > 0) r = mid - 1;
                else
                {
                    l = mid + 1;
                    lastIdx = mid;
                }
            }

            return (1 << (depth - 1)) + lastIdx;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}