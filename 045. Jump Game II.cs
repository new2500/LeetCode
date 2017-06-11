/*
45. Jump Game II
 
Total Accepted: 91259
Total Submissions: 349135
Difficulty: Hard
Contributor: LeetCode
Given an array of non-negative integers, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Your goal is to reach the last index in the minimum number of jumps.

For example:
Given array A = [2,3,1,1,4]

The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)

Note:
You can assume that you can always reach the last index.

Hide Tags Array Greedy

*/

//Author: new2500

	public int Jump(int[] nums)
	{
		int NumOfJump = 0;
		int prev = 0;
		int next = prev;
		int MaxCanJump = prev + nums[prev];
		
		while(MaxCanJump < nums.Length - 1)
		{
			for(int i = prev, maxJump = MaxCanJump; i <= MaxCanJump; i++)
			{
				if(i + nums[i] > MaxCanJump)
				{
					MaxCanJump = i + nums[i];
					next = i;
				}
			}
			prev = next;
			NumOfJump++;
		}
		return NumOfJump;
	}