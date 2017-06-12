/*
47. Permutations II
 
Total Accepted: 117235
Total Submissions: 364450
Difficulty: Medium
Contributor: LeetCode
Given a collection of numbers that might contain duplicates, return all possible unique permutations.

For example,
[1,1,2] have the following unique permutations:
[
  [1,1,2],
  [1,2,1],
  [2,1,1]
]
Hide Company Tags LinkedIn Microsoft
Hide Tags Backtracking
Hide Similar Problems (M) Next Permutation (M) Permutations (M) Palindrome Permutation II
*/

//Author: new2500

	public List<List<int>> Permutation2(int[] nums)
	{
		var res = new List<List<int>>();
		Array.Sort(nums);
		helper(res, nums, new List<int>(), new bool[nums.Length]);
		return res;
	}
	
	private void helper(List<List<int>> res, 
						int[] nums, 
						List<int> path, 
						bool[] used)
	{
		//Exit 
		if(path.Count == nums.Length)
		{
			res.Add(new List<int>(path));
			return;
		}
		
		for(int i = 0; i < nums.Length; i++)
		{
			//Element Used or Duplicate
			if(used[i] || (i > 0 && nums[i] == nums[i-1] && !used[i-1]))
				continue;
				
			used[i] = true;   //Mask
			path.Add(nums[i]);
			helper(res,nums, path, used);
			used[i] = false;  //Unmask
			path.RemoveAt(path.Count - 1);   //Backtracking
		}
	}
