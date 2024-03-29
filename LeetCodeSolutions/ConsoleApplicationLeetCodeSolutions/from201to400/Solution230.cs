﻿namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 230. 二叉搜索树中第K小的元素 | 难度：中等 | 标签：树、深度优先搜索、二叉搜索树、二叉树
    /// 给定一个二叉搜索树的根节点 root ，和一个整数 k ，请你设计一个算法查找其中第 k 个最小元素（从 1 开始计数）。
    /// 
    /// 示例 1：
    /// 输入：root = [3,1,4,null,2], k = 1
    /// 输出：1
    /// 
    /// 示例 2：
    /// 输入：root = [5,3,6,2,4,null,null,1], k = 3
    /// 输出：3
    /// 
    /// 提示：
    /// 树中的节点数为 n 。
    /// 1 <= k <= n <= 104
    /// 0 <= Node.val <= 104
    /// 
    /// 进阶：如果二叉搜索树经常被修改（插入/删除操作）并且你需要频繁地查找第 k 小的值，你将如何优化算法？
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/kth-smallest-element-in-a-bst
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution230
    {
        /// <summary>
        /// 执行用时：84 ms, 在所有 C# 提交中击败了 92.06% 的用户
        /// 内存消耗：41.5 MB, 在所有 C# 提交中击败了 38.09% 的用户
        /// 通过测试用例：93 / 93
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k)
        {
            TreeNode result = null;
            PreOrder(root, k, ref result);
            return result.val;
        }

        private int PreOrder(TreeNode root, int k, ref TreeNode find)
        {
            if (root == null) return k;
            var left = PreOrder(root.left, k, ref find);
            if (find != null) return left;
            if (left == 1)
            {
                find = root;
                return k;
            }

            return PreOrder(root.right, left - 1, ref find);
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