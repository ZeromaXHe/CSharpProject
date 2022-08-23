using System.Collections.Generic;

namespace ConsoleApplicationLeetCodeSolutions.from1to200
{
    /// <summary>
    /// 105. 从前序与中序遍历序列构造二叉树 | 难度：中等 | 标签：树、数组、哈希表、分治、二叉树
    /// 给定两个整数数组 preorder 和 inorder ，其中 preorder 是二叉树的先序遍历， inorder 是同一棵树的中序遍历，请构造二叉树并返回其根节点。
    /// 
    /// 示例 1:
    /// 输入: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
    /// 输出: [3,9,20,null,null,15,7]
    /// 
    /// 示例 2:
    /// 输入: preorder = [-1], inorder = [-1]
    /// 输出: [-1]
    /// 
    /// 提示:
    /// 1 <= preorder.length <= 3000
    /// inorder.length == preorder.length
    /// -3000 <= preorder[i], inorder[i] <= 3000
    /// preorder 和 inorder 均 无重复 元素
    /// inorder 均出现在 preorder
    /// preorder 保证 为二叉树的前序遍历序列
    /// inorder 保证 为二叉树的中序遍历序列
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/construct-binary-tree-from-preorder-and-inorder-traversal
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution105
    {
        /// <summary>
        /// 执行用时：76 ms, 在所有 C# 提交中击败了 97.10% 的用户
        /// 内存消耗：40.2 MB, 在所有 C# 提交中击败了 28.63% 的用户
        /// 通过测试用例：203 / 203
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++) map[inorder[i]] = i;
            return BuildTree(preorder, 0, preorder.Length, 0, map);
        }

        private TreeNode BuildTree(int[] preorder, int fromPre, int toPre, int fromIn, Dictionary<int, int> map)
        {
            if (toPre == fromPre) return null;
            var index = map[preorder[fromPre]];
            var root = new TreeNode(preorder[fromPre],
                BuildTree(preorder, fromPre + 1, fromPre + 1 + index - fromIn, fromIn, map),
                BuildTree(preorder, fromPre + 1 + index - fromIn, toPre, index + 1, map));
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