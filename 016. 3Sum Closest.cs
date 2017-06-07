/*16. 3Sum Closest

Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.

    For example, given array S = {-1 2 1 -4}, and target = 1.

    The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

	
	
Show Company Tags: BB
Show Tags: Array, 2 Pointers
Show Similar Problems: 3 Sum M, 3 Sum Smaller M
*/



//Author: new2500
//O(N^2) time, O(logN) space for quick sort
public int ThreeSumCloest(int[] nums, int target)
{
	int diff = 0;
	int res = 0;
	int sum = 0;
	int maxDiff = int.MaxValue;
	
	Array.Sort(nums);
	
	for(int i = 0; i < nums.Length - 2; i++)
	{
		int left = i+1;
		int right = nums.Length-1;
		
		while(left < right)
		{
			sum = nums[i] + nums[left] + nums[right];
			if(sum == target)   //Found same
				return sum;
			else if(sum < target)
				left++;
			else if(sum > target)
				right--;
			
			//Calculate Diff
			diff = Math.Abs(target - sum);
			
			if(diff < maxDiff)
			{
				res = sum;
				maxDiff = diff;
			}
		}
	}
	return sum;
}
