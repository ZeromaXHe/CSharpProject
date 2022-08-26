using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 297. 二叉树的序列化与反序列化 | 难度：困难 | 标签：树、深度优先搜索、广度优先搜索、设计、字符串、二叉树
    /// 序列化是将一个数据结构或者对象转换为连续的比特位的操作，进而可以将转换后的数据存储在一个文件或者内存中，同时也可以通过网络传输到另一个计算机环境，采取相反方式重构得到原数据。
    /// 
    /// 请设计一个算法来实现二叉树的序列化与反序列化。这里不限定你的序列 / 反序列化算法执行逻辑，你只需要保证一个二叉树可以被序列化为一个字符串并且将这个字符串反序列化为原始的树结构。
    /// 
    /// 提示: 输入输出格式与 LeetCode 目前使用的方式一致，详情请参阅 LeetCode 序列化二叉树的格式。你并非必须采取这种方式，你也可以采用其他的方法解决这个问题。
    /// 
    /// 示例 1：
    /// 输入：root = [1,2,3,null,null,4,5]
    /// 输出：[1,2,3,null,null,4,5]
    /// 
    /// 示例 2：
    /// 输入：root = []
    /// 输出：[]
    /// 
    /// 示例 3：
    /// 输入：root = [1]
    /// 输出：[1]
    /// 
    /// 示例 4：
    /// 输入：root = [1,2]
    /// 输出：[1,2]
    /// 
    /// 提示：
    /// 树中结点数在范围 [0, 104] 内
    /// -1000 <= Node.val <= 1000
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/serialize-and-deserialize-binary-tree
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution297
    {
        /// <summary>
        /// 执行用时：100 ms, 在所有 C# 提交中击败了 43.86% 的用户
        /// 内存消耗：43.8 MB, 在所有 C# 提交中击败了 87.72% 的用户
        /// 通过测试用例：52 / 52
        /// </summary>
        public class Codec
        {
            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                var sb = new StringBuilder();
                PreOrder(root, sb);
                return sb.ToString();
            }

            private void PreOrder(TreeNode root, StringBuilder sb)
            {
                if (sb.Length > 0) sb.Append(',');
                if (root == null) sb.Append("null");
                else
                {
                    sb.Append(root.val);
                    PreOrder(root.left, sb);
                    PreOrder(root.right, sb);
                }
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                var strs = data.Split(',');
                var idx = 0;
                return BuildTree(strs, ref idx);
            }

            private TreeNode BuildTree(string[] strs, ref int idx)
            {
                idx++;
                if ("null".Equals(strs[idx - 1])) return null;
                var root = new TreeNode(int.Parse(strs[idx - 1]));
                root.left = BuildTree(strs, ref idx);
                root.right = BuildTree(strs, ref idx);
                return root;
            }
        }

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));

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