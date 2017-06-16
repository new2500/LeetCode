/*
80. Remove Duplicates from Sorted Array II

Total Accepted: 115875 Total Submissions: 325223 Difficulty: Medium
Contributor: LeetCode
Follow up for "Remove Duplicates":
What if duplicates are allowed at most twice?

For example,
Given sorted array nums = [1,1,1,2,2,3],

Your function should return length = 5, with the first five elements of nums being 1, 1, 2, 2 and 3. It doesn't matter what you leave beyond the new length.

Hide Company Tags Facebook
Hide Tags Array Two Pointers
*/




//Author:new2500


#region Thought: Go through the array and include those in the result that haven't been included twice already.

	publci int RemoveDuplicates(int[] nums)
	{
		int length = 0;
		//Work only for a sorted array.
		foreach(int num in nums)
		{
			if(length < 2 || num > nums[length - 2])
			{
				nums[length] = num;
				length++;
			}
		}
		return length;
	}




#end