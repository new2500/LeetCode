/*
41. First Missing Positive
 
Total Accepted: 97207
Total Submissions: 384040
Difficulty: Hard
Contributor: LeetCode
Given an unsorted integer array, find the first missing positive integer.

For example,
Given [1,2,0] return 3,
and [3,4,-1,1] return 2.

Your algorithm should run in O(n) time and uses constant space.

Hide Tags Array
Hide Similar Problems (E) Missing Number (M) Find the Duplicate Number (E) Find All Numbers Disappeared in an Array
*/


//Author: new2500

//Iterate through array, if the value of curr is between 1 and length of array, swap value with item, which index is that value. Then loop again, check value == index+1 to find first mssing positive

//Sort(using swap) and find O(N) time, O(1) space
	public int FirstMissingPositive(int[] nums)
	{
		for(int i = 0; i < nums.Length;)
		{
			//ignore cases
			if(nums[i] == i+1          //Sorted 
			|| nums[i] < 1            //Negative element
			|| nums[i] > nums.Length  //Greater than length value
			|| nums[i] == nums[nums[i]-1])  // n == nums[n+1]
			{
				i++; continue;
			}
		 
			//Swap sort; nums[i] and nums[nums[i]-1] : n and nums[n+1]
			var temp = nums[i];
			nums[i] = nums[temp-1];
			nums[temp - 1] = temp;
		}

		for(int i = 0; i < nums.Length; i++)
		{
			if(nums[i] != i+1)
				return i+1;
		}
		return nums.Length+1;	
	}