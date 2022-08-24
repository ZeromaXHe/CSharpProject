using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 113. 路径总和 II | 难度：中等 | 标签：树、深度优先搜索、回溯、二叉树
    /// 给你二叉树的根节点 root 和一个整数目标和 targetSum ，找出所有 从根节点到叶子节点 路径总和等于给定目标和的路径。
    /// 
    /// 叶子节点 是指没有子节点的节点。
    /// 
    /// 示例 1：
    /// 输入：root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
    /// 输出：[[5,4,11,2],[5,8,4,5]]
    /// 
    /// 示例 2：
    /// 输入：root = [1,2,3], targetSum = 5
    /// 输出：[]
    /// 
    /// 示例 3：
    /// 输入：root = [1,2], targetSum = 0
    /// 输出：[]
    /// 
    /// 提示：
    /// 树中节点总数在范围 [0, 5000] 内
    /// -1000 <= Node.val <= 1000
    /// -1000 <= targetSum <= 1000
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/path-sum-ii
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution113
    {
        /// <summary>
        /// 执行用时：128 ms, 在所有 C# 提交中击败了 96.00% 的用户
        /// 内存消耗：43.3 MB, 在所有 C# 提交中击败了 63.20% 的用户
        /// 通过测试用例：115 / 115
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;
            var list = new List<int>();
            PostOrder(root, result, list, 0, targetSum);
            return result;
        }

        private void PostOrder(TreeNode root, List<IList<int>> result, List<int> list, int sum, int targetSum)
        {
            list.Add(root.val);
            if (root.left == null && root.right == null)
            {
                if (sum + root.val == targetSum) result.Add(list.ToList());
            }
            else
            {
                if (root.left != null) PostOrder(root.left, result, list, sum + root.val, targetSum);
                if (root.right != null) PostOrder(root.right, result, list, sum + root.val, targetSum);
            }

            list.RemoveAt(list.Count - 1);
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