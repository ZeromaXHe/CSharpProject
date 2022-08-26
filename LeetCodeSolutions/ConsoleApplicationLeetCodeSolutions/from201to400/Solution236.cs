using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 236. 二叉树的最近公共祖先 | 难度：中等 | 标签：树、深度优先搜索、二叉树
    /// 给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。
    /// 
    /// 百度百科中最近公共祖先的定义为：“对于有根树 T 的两个节点 p、q，最近公共祖先表示为一个节点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”
    /// 
    /// 示例 1：
    /// 输入：root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
    /// 输出：3
    /// 解释：节点 5 和节点 1 的最近公共祖先是节点 3 。
    /// 
    /// 示例 2：
    /// 输入：root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
    /// 输出：5
    /// 解释：节点 5 和节点 4 的最近公共祖先是节点 5 。因为根据定义最近公共祖先节点可以为节点本身。
    /// 
    /// 示例 3：
    /// 输入：root = [1,2], p = 1, q = 2
    /// 输出：1
    /// 
    /// 提示：
    /// 树中节点数目在范围 [2, 105] 内。
    /// -109 <= Node.val <= 109
    /// 所有 Node.val 互不相同 。
    /// p != q
    /// p 和 q 均存在于给定的二叉树中。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/lowest-common-ancestor-of-a-binary-tree
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution236
    {
        /// <summary>
        /// 执行用时：76 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗：42.8 MB, 在所有 C# 提交中击败了 7.53% 的用户
        /// 通过测试用例：31 / 31
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var stackP = new Stack<TreeNode>();
            var stackQ = new Stack<TreeNode>();
            var findP = false;
            var findQ = false;
            InitPQStack(root, p, q, ref findP, ref findQ, stackP, stackQ);
            while (stackP.Count > stackQ.Count) stackP.Pop();
            while (stackP.Count < stackQ.Count) stackQ.Pop();
            while (stackP.Peek() != stackQ.Peek())
            {
                stackP.Pop();
                stackQ.Pop();
            }

            return stackP.Peek();
        }

        private void InitPQStack(TreeNode root, TreeNode p, TreeNode q, ref bool findP, ref bool findQ,
            Stack<TreeNode> stackP, Stack<TreeNode> stackQ)
        {
            if (findP && findQ) return;
            if (!findP)
            {
                stackP.Push(root);
                if (root == p) findP = true;
            }

            if (!findQ)
            {
                stackQ.Push(root);
                if (root == q) findQ = true;
            }

            if (root.left != null) InitPQStack(root.left, p, q, ref findP, ref findQ, stackP, stackQ);
            if (root.right != null) InitPQStack(root.right, p, q, ref findP, ref findQ, stackP, stackQ);
            if (!findP) stackP.Pop();
            if (!findQ) stackQ.Pop();
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
    }
}