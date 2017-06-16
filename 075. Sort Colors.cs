/*
75. Sort Colors
 
Total Accepted: 158729
Total Submissions: 422416
Difficulty: Medium
Contributor: LeetCode
Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

Note:
You are not suppose to use the library's sort function for this problem.

 

Hide Company Tags Pocket Gems Microsoft Facebook
Hide Tags Array Two Pointers Sort
Hide Similar Problems (M) Sort List (M) Wiggle Sort (M) Wiggle Sort II
*/

#region  Two-pass using Counting Sort 
	public void SortColors(int[] nums)
	{
		int lowCount = 0, midCount = 0, highCount = nums.Length;
		
		for(int i = 0; i < nums.Length; i++)
		{
			if(nums[i] == 0)
			{
				lowCount++; highCount--;
			}
			else if(nums[i] == 1)
			{
				midCount++; highCount--;
			}
		}
		
		for(int i = 0; i < nums.Length; i++)
		{
			if(lowCount > 0)
			{
				nums[i] = 0; lowCount--;
			}
			else if(midCount > 0)
			{
				nums[i] = 1; midCount--;
			}
			else
			{
				nums[i] = 2;
			}
		}
	}


#end
/*
Follow up:
A rather straight forward solution is a two-pass algorithm using counting sort.
First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.

Could you come up with an one-pass algorithm using only constant space?
*/

//Reference: Duth Flag Problem https://www.wikiwand.com/en/Dutch_national_flag_problem

#region Swap algorithm O(N) time, O(1) space
	public void SortColors(int[] nums)
	{
		int left = 0, right = nums.Length - 1;
		int i = 0;
		int mid = 1;    //Set the middle value
		
		while(i < right)
		{
			if(nums[i] < mid)  //If less than mid, set to left
			{
				Swap(nums, i, left);
				i++; left++;
			}
			else if(nums[i] > mid) //If greater then mid, set to right
			{
				Swap(nums, i, right);
				right--;
			}
			else
			{
				i++;
			}
		}
	}	
	private void SwapWithTemp(int[] nums, int i, int j)
	{
		int temp = nums[i];
		nums[i] = nums[j];
		nums[j] = nums[i];
	}
	//Fast in runtime, no extra space
	private void SwapUseBits(int[] nums, int i, int j)
	{                         //e.p: nums[i]:1(01b) nums[j]:3(11b)
		nums[j] ^= nums[i];   //nums[j] = 11^01 = 10b = 2  
		nums[i] ^= nums[j];   //nums[i] = 01^10 = 11b = 3
		nums[j] ^= nums[i];   //nums[j] = 10^11 = 01b = 1   
		                      //Now nums[j] = 1, nums[i] = 3
	}
