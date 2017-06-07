/*15. 3Sum

Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note: The solution set must not contain duplicate triplets.

For example, given array S = [-1, 0, 1, 2, -1, -4],

A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]
Show Company Tags: AmZ, M$, BB, FB, Adb, Works Applications
Show Tags: Array, Two Pointers
Show Similar Problems: Two Sum E, 3Sum Closest M, 4Sum M, 3Sum Smaller M
*/

//Author: new2500


//Two Pointer
//O(N^2) time, O(lgN) space
public List<List<int>> ThreeSum(int[] nums)
{
	var res = new List<List<int>>();
	Array.Sort(nums);
	
	for(int i = 0; i < nums.Length -2; i++)
	{
		if(i==0 || i > 0 && nums[i] != nums[i-1])  //de-duplicate
		{
			int low = i+1; 
			int high = nums.Length-1;
			int sum = 0 - nums[i];
			
			while(low < high)
			{
				if(nums[low] + nums[high] == sum) //Found one
				{
					res.Add(new List<int>{nums[i], nums[low], nums[high]});
					
					while(low < high && nums[low] == nums[low+1])
						low++;
					while(low < high && nums[high-1] == nums[high])
						high--;
					
					low++; high--;
				}
				else if(nums[low] + nums[high] < sum)
					low++;
				else
					high--;
			}
		}
	}
	return res;
}






