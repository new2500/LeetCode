/*
53. Maximum Subarray
 
Total Accepted: 195700
Total Submissions: 497045
Difficulty: Easy
Contributor: LeetCode
Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

For example, given the array [-2,1,-3,4,-1,2,1,-5,4],
the contiguous subarray [4,-1,2,1] has the largest sum = 6.

click to show more practice.

Hide Company Tags LinkedIn Bloomberg Microsoft
Hide Tags Array Dynamic Programming Divide and Conquer
Hide Similar Problems (E) Best Time to Buy and Sell Stock (M) Maximum Product Subarray
*/

VOSS-029


//Author: new2500



#region DP 

	public int MaxSubArray(int[] nums)
	{
		if(nums == null || nums.Length == 0)
			return 0;
		
		int maxSoFar = nums[0];
		int maxEndingHere = nums[0];
		
		for(int i = 1; i< nums.Length; i++)
		{
			maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
			maxSoFar = Math.Max(maxSoFar, maxEndingHere);
		}
		return maxSoFar;
	}
#endregion




#region Divide and Conquer - Backtracking

    //divid and conquer - more subtle
    public int MaxSubArray(int[] nums) {
        int max = helper(nums,0, nums.Length - 1);
        return max;
    }
    //2 * O(logN) * O(N)
    private int helper(int[] nums, int left, int right)
    {
        if(left == right) //base case
          return nums[left];
          
        int mid = left + (right - left)/2;  
        int maxLeftSum = helper(nums, left, mid);
        int maxRightSum = helper(nums,mid+1, right);
        int acrossSum = acrossHelper(nums, left, mid, right);
        
        if(maxLeftSum >= maxRightSum && maxLeftSum >= acrossSum)
          return maxLeftSum;
        if(maxRightSum >= maxLeftSum && maxRightSum >= acrossSum)
          return maxRightSum;
        else
          return acrossSum;
    }
    //O(N)
    private int acrossHelper(int[] nums,int left,int mid,int right)
    {
        int maxLeftSum = int.MinValue, maxRightSum = int.MinValue;
        
        //max left
        int allLeftSum = 0;
        for(int i = mid; i >= left; i--)
        {
            allLeftSum = allLeftSum + nums[i];
            if(maxLeftSum < allLeftSum)
            maxLeftSum = allLeftSum;
        }
        
        //max right
        int allRightSum = 0;
        for(int i = mid +1; i <= right; i++)
        {
            allRightSum = allRightSum + nums[i];
            if(maxRightSum < allRightSum)
             maxRightSum = allRightSum;
        }
        
        return maxLeftSum + maxRightSum;
    }
	#endregion





