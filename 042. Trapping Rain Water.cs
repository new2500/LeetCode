/*
42. Trapping Rain Water
 
Total Accepted: 111363
Total Submissions: 307025
Difficulty: Hard
Contributor: LeetCode
Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.

For example, 
Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.
Graph: https://leetcode.com/static/images/problemset/rainwatertrap.png

The above elevation map is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped. Thanks Marcos for contributing this image!

Hide Company Tags Google Twitter Zenefits Amazon Apple Bloomberg
Hide Tags Array Stack Two Pointers
Hide Similar Problems (M) Container With Most Water (M) Product of Array Except Self (H) Trapping Rain Water II
*/



#region Two pointers O(N) time, O(1) space
// Initialize left pointer to 0, right pointer to last index;
/* While left < right, do:
     if height[left] >= max, update the max
	 Else add max - height[left] to Total vol
	 left++
   Else
     Similar to left part, right--	   
	 */
	public int Trap(int[] height)
    {
    	if(height == null || height.Length == 0)
    		return 0;
	
     	int max = 0;
		int vol = 0;
		int left = 0;
		int right = height.Length-1;
	
		while(left <= right)
		{
			if(height[left] < height[right])
			{
				max = Math.Max(max, height[left]);
				vol = vol + (max - height[left]);
				left++;
			}
			else
			{
				max = Math.Max(max, height[right]);
				vol = vol + (max - height[right]);
				right--;
			}
		}
		return vol;
	}
#endregion




#region Brute Force O(N^2) time, O(1) space

        public int Trap(int[] height)
        {
            int vol = 0;

            for (int i = 1; i < height.Length - 1; i++)
            {
                int MaxLeft = 0, MaxRight = 0;
                for (int j = i; j >= 0; j--) //Search the left part for max bar 
                {
                    MaxLeft = Math.Max(MaxLeft, height[j]);
                }
                for (int j = i; j < height.Length; j++)
                {
                    MaxRight = Math.Max(MaxRight, height[j]); //Search the right part for max bar
                }

                vol += Math.Min(MaxLeft, MaxRight) - height[i];
            }
            return vol;
        }