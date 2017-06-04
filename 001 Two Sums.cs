/*
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:
Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].

Author: new2500 @GitHub 
*/

//Hash-Table O(N) time, O(N) space
public int[] TwoSum(int[] nums, int target)
{
	if(nums == null)
		return null;
	var dict = new Dictionary<int, int>();
	
	for(int i = 0; i < nums.Length; i++)
	{
		var aim = target - nums[i];
		if(dict.ContainsKey(aim))
			return new int[] {dict[aim], i};
		else
			if(!dict.ContainsKey(nums[i]))
				dict.Add(nums[i], i);
	}
	return null;
}


//Naive O(N^2) time, O(1) space
public int[] TwoSumNaive(int[] nums, int target)
{
	if(nums == null)
		return null;
	
	for(int i = 0; i < nums.Length; i++)
	{
		for(int j = i+1; j < nums.Length; j++) //start at i+1, avoid using same element twice
		{
			if(num[i] + nums[j] == target)
				return new int[] {i, j};
		}
	}
	return null;
}
