/*
35. Search Insert Position
 
Total Accepted: 171521
Total Submissions: 434277
Difficulty: Easy
Contributor: LeetCode
Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You may assume no duplicates in the array.

Here are few examples.
[1,3,5,6], 5 → 2
[1,3,5,6], 2 → 1
[1,3,5,6], 7 → 4
[1,3,5,6], 0 → 0

Hide Tags Array Binary Search
Hide Similar Problems (E) First Bad Version
*/

//O(logN) time
public int SearchInsert(int[] nums, int taarget)
{
	int low = 0;
	int high = nums.Length -1;
	while(low <= high)
	{
		int mid = low + (high-low)/2;
		if(nums[mid] == target)
			return mid;
		else if(nums[mid] < target)
			low = mid+1;
		else
			high = mid - 1;
	}
	
	return low;
}
