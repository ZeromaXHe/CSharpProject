using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from601to800
{
    /// <summary>
    /// 654. 最大二叉树 | 难度：中等 | 标签：
    /// 给定一个不重复的整数数组 nums 。 最大二叉树 可以用下面的算法从 nums 递归地构建:
    /// 
    /// 创建一个根节点，其值为 nums 中的最大值。
    /// 递归地在最大值 左边 的 子数组前缀上 构建左子树。
    /// 递归地在最大值 右边 的 子数组后缀上 构建右子树。
    /// 返回 nums 构建的 最大二叉树 。
    /// 
    /// 示例 1：
    /// 输入：nums = [3,2,1,6,0,5]
    /// 输出：[6,3,5,null,2,0,null,null,1]
    /// 解释：递归调用如下所示：
    /// - [3,2,1,6,0,5] 中的最大值是 6 ，左边部分是 [3,2,1] ，右边部分是 [0,5] 。
    /// - [3,2,1] 中的最大值是 3 ，左边部分是 [] ，右边部分是 [2,1] 。
    /// - 空数组，无子节点。
    /// - [2,1] 中的最大值是 2 ，左边部分是 [] ，右边部分是 [1] 。
    /// - 空数组，无子节点。
    /// - 只有一个元素，所以子节点是一个值为 1 的节点。
    /// - [0,5] 中的最大值是 5 ，左边部分是 [0] ，右边部分是 [] 。
    /// - 只有一个元素，所以子节点是一个值为 0 的节点。
    /// - 空数组，无子节点。
    /// 
    /// 示例 2：
    /// 输入：nums = [3,2,1]
    /// 输出：[3,null,2,null,1]
    /// 
    /// 提示：
    /// 1 <= nums.length <= 1000
    /// 0 <= nums[i] <= 1000
    /// nums 中的所有整数 互不相同
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/maximum-binary-tree
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution654
    {
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
        /// 执行用时：96 ms, 在所有 C# 提交中击败了 52.17% 的用户
        /// 内存消耗：45.9 MB, 在所有 C# 提交中击败了 20.29% 的用户
        /// 通过测试用例：107 / 107
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            var stack = new Stack<TreeNode>();
            for (int i = 0; i < nums.Length; i++)
            {
                var node = new TreeNode(nums[i]);
                TreeNode ptr = null;
                while (stack.Count > 0 && stack.Peek().val < nums[i])
                {
                    var pop = stack.Pop();
                    pop.right = ptr;
                    ptr = pop;
                }

                if (ptr != null) node.left = ptr;
                stack.Push(node);
            }

            TreeNode root = null;
            while (stack.Count > 0)
            {
                var pop = stack.Pop();
                pop.right = root;
                root = pop;
            }

            return root;
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