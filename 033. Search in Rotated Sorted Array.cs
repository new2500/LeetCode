/*
33. Search in Rotated Sorted Array
 
Total Accepted: 168160
Total Submissions: 523287
Difficulty: Medium
Contributor: LeetCode
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

You are given a target value to search. If found in the array return its index, otherwise return -1.

You may assume no duplicate exists in the array.

Hide Company Tags LinkedIn Bloomberg Uber Facebook Microsoft
Hide Tags Binary Search Array
Hide Similar Problems (M) Search in Rotated Sorted Array II (M) Find Minimum in Rotated Sorted Array
*/


//Author: new2500



#region BinarySearch

////make a mid
//if mid >= low, mid is in the left part, If target >= low && target < mid. Search left, otherwsie search right;
//If mid < low, mid is in the right part, If target <= high and x> mid, search right part, otherwise seach left part
//O(logN) time, 
public int Search(int[] nums, int target)
{
	return helper(nums, 0, nums.Length-1, target)
}


public int helper(int[] nums, int low, int high, int target)
{
	if(low > high)
		return -1;
	
	int mid = (high-low)/2 + low;
	
	if(nums[mid] == target)
		return mind;
	
	if(nums[mid] >= nums[low])  //mid in the left
	{
		if(target >= nums[low] && target < mid[mid]) //Search Left
		   return helper(nums, low, mid-1, target);
		
        return helper(nums, mid+1, high, target);   Right
	}
	else     //nums[mid] < nums[low], mid in the right
	{
	    if(target<= nums[high] && target > nums[mid])   //Search Right
			return helper(nums, mid+1, high,target);
		
		return helper(nums, low, mid-1, target);       //Left
	}

}



#endregion
