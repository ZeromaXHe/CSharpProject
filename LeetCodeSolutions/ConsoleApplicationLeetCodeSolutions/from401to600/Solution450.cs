namespace ConsoleApplicationLeetCodeSolutions.from401to600
{
    /// <summary>
    /// 450. 删除二叉搜索树中的节点 | 难度：中等 | 标签：树、二叉搜索树、二叉树
    /// 给定一个二叉搜索树的根节点 root 和一个值 key，删除二叉搜索树中的 key 对应的节点，并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的根节点的引用。
    /// 
    /// 一般来说，删除节点可分为两个步骤：
    /// 
    /// 首先找到需要删除的节点；
    /// 如果找到了，删除它。
    /// 
    /// 示例 1:
    /// 输入：root = [5,3,6,2,4,null,7], key = 3
    /// 输出：[5,4,6,2,null,null,7]
    /// 解释：给定需要删除的节点值是 3，所以我们首先找到 3 这个节点，然后删除它。
    /// 一个正确的答案是 [5,4,6,2,null,null,7], 如下图所示。
    /// 另一个正确答案是 [5,2,6,null,4,null,7]。
    /// 
    /// 示例 2:
    /// 输入: root = [5,3,6,2,4,null,7], key = 0
    /// 输出: [5,3,6,2,4,null,7]
    /// 解释: 二叉树不包含值为 0 的节点
    /// 
    /// 示例 3:
    /// 输入: root = [], key = 0
    /// 输出: []
    /// 
    /// 提示:
    /// 节点数的范围 [0, 104].
    /// -105 <= Node.val <= 105
    /// 节点值唯一
    /// root 是合法的二叉搜索树
    /// -105 <= key <= 105
    /// 
    /// 进阶： 要求算法时间复杂度为 O(h)，h 为树的高度。
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/delete-node-in-a-bst
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution450
    {
        public void Test()
        {
            var root = new TreeNode(5,
                new TreeNode(3, new TreeNode(2), new TreeNode(4)),
                new TreeNode(6, null, new TreeNode(7)));
            DeleteNode(root, 3);
        }

        /// <summary>
        /// 执行用时：88 ms, 在所有 C# 提交中击败了 86.83% 的用户
        /// 内存消耗：43.3 MB, 在所有 C# 提交中击败了 21.81% 的用户
        /// 通过测试用例：92 / 92
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val == key)
            {
                if (root.left != null)
                {
                    var ptr = root.left;
                    TreeNode pre = null;
                    while (ptr.right != null)
                    {
                        pre = ptr;
                        ptr = ptr.right;
                    }

                    if (pre == null)
                    {
                        root.left.left = DeleteNode(root.left, root.left.val);
                        root.left.right = root.right;
                        return root.left;
                    }

                    pre.right = DeleteNode(ptr, ptr.val);
                    ptr.left = root.left;
                    ptr.right = root.right;
                    return ptr;
                }

                if (root.right != null) return root.right;
                return null;
            }

            if (root.val > key)
            {
                if (root.left != null) root.left = DeleteNode(root.left, key);
            }
            else if (root.right != null) root.right = DeleteNode(root.right, key);

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