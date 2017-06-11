/*
40. Combination Sum II
 
Total Accepted: 111639
Total Submissions: 339733
Difficulty: Medium
Contributor: LeetCode
Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.

Each number in C may only be used once in the combination.

Note:
All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.
For example, given candidate set [10, 1, 2, 7, 6, 1, 5] and target 8, 
A solution set is: 
[
  [1, 7],
  [1, 2, 5],
  [2, 6],
  [1, 1, 6]
]
Hide Company Tags Snapchat
Hide Tags Array Backtracking
Hide Similar Problems (M) Combination Sum
*/


//Author:new2500

	public List<List<int>> CombinationSum2(int[] candidates, int target)
	{
		var res = new List<List<int>>();
		var path = new List<int>();
		helper(candidates, target, 0, path, res);
		return res;
	}

	private void helper(int[] nums, int target, int start, Lsit<int> path, List<List<int>> res)
	{
		if(target == 0)
		{
			res.Add(new List<int>(path));
			return;
		}
	
		for(int i = start; i < nums.Length; i++)
		{
			if(nums[i] > target)
				return;
		
			path.Add(nums[i]);
			helper(nums, target-nums[i], i+1, path, res);
			path.RemoveAt(path.Count-1);
		
			//Remove Duplicate used: For cases: {1,1,1} and target = 2
			while(i+1 < nums.Length && nums[i+1] == nums[i])
				i++;
		}
	}
