namespace ConsoleApplicationLeetCodeSolutions.from201to400
{
    /// <summary>
    /// 215. 数组中的第K个最大元素 | 难度：中等 | 标签：数组、分治、快速选择、排序、堆（优先队列）
    /// 给定整数数组 nums 和整数 k，请返回数组中第 k 个最大的元素。
    /// 
    /// 请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。
    /// 
    /// 你必须设计并实现时间复杂度为 O(n) 的算法解决此问题。
    /// 
    /// 示例 1:
    /// 输入: [3,2,1,5,6,4], k = 2
    /// 输出: 5
    /// 
    /// 示例 2:
    /// 输入: [3,2,3,1,2,4,5,5,6], k = 4
    /// 输出: 4
    /// 
    /// 提示：
    /// 1 <= k <= nums.length <= 105
    /// -104 <= nums[i] <= 104
    /// 
    /// 来源：力扣（LeetCode）
    /// 链接：https://leetcode.cn/problems/kth-largest-element-in-an-array
    /// 著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    /// </summary>
    public class Solution215
    {
        /// <summary>
        /// 执行用时：156 ms, 在所有 C# 提交中击败了 48.43% 的用户
        /// 内存消耗：49.7 MB, 在所有 C# 提交中击败了 33.76% 的用户
        /// 通过测试用例：39 / 39
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            return Qsort(nums, 0, nums.Length - 1, nums.Length - k + 1);
        }

        public int Qsort(int[] nums, int low, int high, int k)
        {
            int pivot = Partition(nums, low, high);
            if (pivot == k - 1) return nums[pivot];
            return pivot >= k ? Qsort(nums, low, pivot - 1, k) : Qsort(nums, pivot + 1, high, k);
        }

        public int Partition(int[] nums, int low, int high)
        {
            int mid = low + (high - low) / 2;
            if (nums[low] > nums[high]) Swap(nums, low, high);
            if (nums[mid] > nums[high]) Swap(nums, mid, high);
            if (nums[mid] > nums[low]) Swap(nums, low, mid);
            int key = nums[low];
            while (low < high)
            {
                while (low < high && nums[high] >= key) high--;
                Swap(nums, low, high);
                while (low < high && nums[low] <= key) low++;
                Swap(nums, low, high);
            }

            return low;
        }

        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}