/*
81. Search in Rotated Sorted Array II
 
Total Accepted: 92926
Total Submissions: 283315
Difficulty: Medium
Contributor: LeetCode
Follow up for "Search in Rotated Sorted Array":
What if duplicates are allowed?

Would this affect the run-time complexity? How and why?
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

Write a function to determine if a given target is in the array.

The array may contain duplicates.

Hide Tags Array Binary Search
Hide Similar Problems (M) Search in Rotated Sorted Array
*/



//Author:new2500


#region Binary Search

//Since there could be duplicate in teh array and rotated at some pivot, the worst case is O(N).  (Think about 11115, rotated to 15111)

//In this case, we never know which part hold the target value, so we need to search left & right part simultaneously to decide which side we need to find. 

//But in this case, it's still better then Quick Sort and search O(NlogN).

	public bool Search(int[] nums, int target)
	{
		int left = 0, right = nums.Length - 1;

		while(left <= right)
		{
			int mid = left + (right - left)/2;
			
			if(nums[mid] == target)
				return true;
			
			if(nums[left] < nums[mid]) //Left part is sorted
			{
				if(nums[left] <= target && target <= nums[mid])
					right = mid - 1;
				else
					left = mid + 1;
			}
			else if(nums[left] > nums[mid]) //Right part is sorted
			{
				if(nums[mid] < target && target <= nums[right])
					left = mid + 1;
				else
					right = mid - 1;
			}
			else
				left++;
		}
		return false;
	}

#end