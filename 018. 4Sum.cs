/*18. 4Sum

Total Accepted: 115564
Total Submissions: 437973
Difficulty: Medium
Contributor: LeetCode

Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.

Note: The solution set must not contain duplicate quadruplets.

For example, given array S = [1, 0, -1, 0, -2, 2], and target = 0.

A solution set is:
[
  [-1,  0, 0, 1],
  [-2, -1, 1, 2],
  [-2,  0, 0, 2]
]
Show Tags: Array, Hash Table, Two Pointers
Show Similar Problems: 2 Sum E, 3 Sum M, 4 SumII Medium
*/

//Author: new2500
//K-sum reduce to 2-sum method. Backtracking O(N^3) time
public List<List<int>> FourSum(int[] nums, target)
{
	List<List<int>> res = new List<List<int>>();
	
	if(nums == null || nums.Length < 4)
		return res;
	Array.Sort(nums);
	KSumTrim(nums, target, 4, 0, res, new List<int>());
	return res;
}

private void KSumTrim(int[] nums, int target, int k, int start, List<List<int>> res, List<int> path)
{
	int max = nums[nums.Length-1];
	//answer not exist cases:
	if(k * max < target || k * nums[0] > target)
		return;
	
	if(k == 2)
	{
		int left = start;
		int right = nums.Length-1;
		while(left < right)
		{
			if(nums[left] + nums[right] < target)
				left++;
			else if(nums[left] + nums[right] > target)
				right--;
			else  //Found one
			{
				res.Add(new List<int>(path));
				res[res.Count-1].Add(nums[left]);
				res[res.Count-1].Add(nums[right]);
				//de-duplicate
				while(left < right && nums[left] == nums[left+1]) left++;
				while(left < right && nums[right-1] == nums[right]) right--;
				
				left++;right--;
			}
		}
	}
	else //K sum, trim down to 2 sum
	{
		for(int i = start; i < nums.Length - k +1; i++)
		{
			if(i > start && nums[i] == nums[i-1]) continue;
			if(nums[i] + max *(k-1) < target)     continue;
			if(nums[i] * k > target)              continue;
			if(nums[i] * k == target)
			{
				//for same element case
				if(nums[i+k-1] == nums[i])
				{
					res.Add(new List<int>(path));
					for(int x = 0; x < k; x++)
						res[Count-1].Add(nums[i]);
				}
				break;
			}
			path.Add(nums[i]);
			KSumTrim(nums, target - nums[i], k-1, i+1, res, path);
			path.RemoveAt(path.Count-1);      //Backtracking
		}
	}
}
