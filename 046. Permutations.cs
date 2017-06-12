/*
46. Permutations
Given a collection of distinct numbers, return all possible permutations.

For example,
[1,2,3] have the following permutations:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]
Hide Company Tags LinkedIn Microsoft
Hide Tags Backtracking
Hide Similar Problems (M) Next Permutation (M) Permutations II (M) Permutation Sequence (M) Combinations
*/

//Author: new2500

	public List<List<int>> Permute(int[] nums)
	{
		List<List<int>> res = new List<List<int>>();
		helper(res, nums, new List<int>());
		return res;
	}
	
	private void helper(List<List<int>> res, int[] nums, List<int> path)
	{
		if(path.Count == nums.Length)
		{
			res.Add(new List<int>(path));
			return;
		}
	    
		for(int i = 0; i < nums.Length; i++)
		{
			if(!path.Contains(nums[i]))
			{
				path.Add(nums[i]);
				helper(res, nums, path);
				path.RemvoeAt(path.Count - 1);
			}
		}
	}