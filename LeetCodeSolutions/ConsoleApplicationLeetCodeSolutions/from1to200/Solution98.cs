namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 98. 验证二叉搜索树 | 难度：中等 | 标签：树、深度优先搜索、二叉搜索树、二叉树
    /// 给你一个二叉树的根节点 root ，判断其是否是一个有效的二叉搜索树。
    /// 
    /// 有效 二叉搜索树定义如下：
    /// 
    /// 节点的左子树只包含 小于 当前节点的数。
    /// 节点的右子树只包含 大于 当前节点的数。
    /// 所有左子树和右子树自身必须也是二叉搜索树。
    /// 
    /// 示例 1：
    /// 输入：root = [2,1,3]
    /// 输出：true
    /// 
    /// 示例 2：
    /// 输入：root = [5,1,4,null,null,3,6]
    /// 输出：false
    /// 解释：根节点的值是 5 ，但是右子节点的值是 4 。
    /// 
    /// 提示：
    /// 树中节点数目范围在[1, 104] 内
    /// -231 <= Node.val <= 231 - 1
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/validate-binary-search-tree
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution98
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
        /// 执行用时：108 ms, 在所有 C# 提交中击败了 16.50% 的用户
        /// 内存消耗：41.5 MB, 在所有 C# 提交中击败了 22.42% 的用户
        /// 通过测试用例：80 / 80
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST_MinMax(TreeNode root)
        {
            return isValidBST(root, long.MinValue, long.MaxValue);
        }

        private bool isValidBST(TreeNode root, long min, long max)
        {
            if (root == null) return true;
            if (root.val >= max || root.val <= min) return false;
            if (!isValidBST(root.left, min, root.val)) return false;
            if (!isValidBST(root.right, root.val, max)) return false;
            return true;
        }
        
        /// <summary>
        /// 执行用时：100 ms, 在所有 C# 提交中击败了 37.44% 的用户
        /// 内存消耗：41.2 MB, 在所有 C# 提交中击败了 72.91% 的用户
        /// 通过测试用例：80 / 80
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            TreeNode pre = null;
            return InOrder(root, ref pre) != null;
        }

        private TreeNode InOrder(TreeNode root, ref TreeNode pre)
        {
            if (root.left != null && InOrder(root.left, ref pre) == null) return null;
            if (pre == null || pre.val < root.val) pre = root;
            else return null;
            if (root.right != null && InOrder(root.right, ref pre) == null) return null;
            return pre;
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