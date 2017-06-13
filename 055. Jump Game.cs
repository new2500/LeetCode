/*
55. Jump Game
 
Total Accepted: 120940
Total Submissions: 411053
Difficulty: Medium
Contributor: LeetCode
Given an array of non-negative integers, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Determine if you are able to reach the last index.

For example:
A = [2,3,1,1,4], return true.

A = [3,2,1,0,4], return false.

Hide Company Tags Microsoft
Hide Tags Array Greedy

*/


//Author: new2500


#region   Iterate from 1st element

//Iterate from 1st, check how far it can jump, make the jump most index as iterative index.
//Use index + nums[index] to compare for jump most index.

	public bool CanJump(int[] nums)
	{
		int maxJump = nums[0];
		
		for(int i = 0; i <= maxJump; i++)
		{
			if(i >= nums.Length-1)
				return true;
			
			maxJump = Math.Max(maxJump, nums[i] + i);
		}
	}
#end





#region     Iterate from backward

	public bool CanJump(int[] nums)
	{
		int index = nums.Length - 1;
		for(int i = nums.Length - 2; i >= 0; i--)
		{
			if(nums[i] + i >= index)
				index = i;
		}
		
		return index <= 0;
	}



#end