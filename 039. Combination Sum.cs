/*
39. Combination Sum
 
Total Accepted: 155224
Total Submissions: 412245
Difficulty: Medium
Contributor: LeetCode
Given a set of candidate numbers (C) (without duplicates) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.

The same repeated number may be chosen from C unlimited number of times.

Note:
All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.
For example, given candidate set [2, 3, 6, 7] and target 7, 
A solution set is: 
[
  [7],
  [2, 2, 3]
]
Hide Company Tags Snapchat Uber
Hide Tags Array Backtracking
Hide Similar Problems (M) Letter Combinations of a Phone Number (M) Combination Sum II (M) Combinations (M) Combination Sum III (M) Factor Combinations (M) Combination Sum IV
What a family plan.......
*/



//Author:new2500
//Iteratively choose the ith element, recursively find(target-nums[i]) in the rest of array(including nums[i] itself)
//1. When target == 0, get one solution
//2. When target <= 0 OR index out of range, no soluiton

	public List<List<int>> CombinationSum(int[] candidates, int target)
	{
		var res = new List<List<int>>();
		var path = new List<int>();
		Array.Sort(candidates);
		helper(candidates, target, 0, path, res);
		return res;
	}

	private void helper(int[] nums, int target, int start, List<int> path, List<List<int>> res)
	{
		if(target < 0) {
			return;   //Could be omitted
		}
		if(target == 0)
		{
			res.Add(new List<int>(path));
			return;
		}
	
		for(int i = start; i < nums.Length; i++)
		{
			if(nums[i] > target)  //No need to searching
				return;
			path.Add(nums[i]);
			helper(nums, target - nums[i], i, path, res);
			path.RemoveAt(path.Count-1);
		}
	}




