/*
34. Search for a Range
 
Total Accepted: 133990
Total Submissions: 429440
Difficulty: Medium
Contributor: LeetCode
Given an array of integers sorted in ascending order, find the starting and ending position of a given target value.

Your algorithm's runtime complexity must be in the order of O(log n).

If the target is not found in the array, return [-1, -1].

For example,
Given [5, 7, 7, 8, 8, 10] and target value 8,
return [3, 4].

Hide Company Tags LinkedIn
Hide Tags Binary Search Array
Hide Similar Problems (E) First Bad Version

*/

//Author: new2500


public int[] SearchRange(int[] nums, int target)
{
	return helper(nums,target, 0, nums.Length-1);
}

private int[] helper(int[] nums, int target, int low, int high)
{
	//Invalid cases
	if(low > high || nums[low] > nums[high] || nums[low] > target || nums[high] < target)
		return new int[] {-1, -1};
	
	//Same element
	if(nums[low] == target && nums[high] == target)
		return new int[] {low, high};
	
	//Mid point
	int mid = low + (high - low)/2;
	
	int[] left = helper(nums, target, low, mid);      //Search Left part
	int[] right = helper(nums, target, mid+1, high);  //Search Right part
	
	if(left[0] == -1)  //check if target exists in left part
		return right;
	if(right[0] == -1) //check if target exists in right part
		return left;
	
	return new int[] {left[0], right[1]};    ////return 1st of left to last of right as a range
}