/*
31. Next Permutation
 
Total Accepted: 108008
Total Submissions: 377345
Difficulty: Medium
Contributor: LeetCode
Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).

The replacement must be in-place, do not allocate extra memory.

Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
1,2,3 → 1,3,2
3,2,1 → 1,2,3
1,1,5 → 1,5,1

Hide Company Tags Google
Hide Tags Array
Hide Similar Problems (M) Permutations (M) Permutations II (M) Permutation Sequence (M) Palindrome Permutation II
*/


//Author:new2500


/*  Example: 0, 1, 2, 5, 3, 3, 0
  
1. Find longest non-increasing suffix:               0,1,2,(5,3,3,0)
2. Pivot is 2                                            ^
3. Find the rightmost successor to the pivot in suffix: 5,3,3,0 => the 2nd "3"
4. Swap successor with Pivot =>                      0,1,{3},5,3,{2},0
5. Reverse the suffix,we have the result       =>     0,1,3,(0,2,3,5)
*/
//O(N) time, O(1) space
public void NextPermutation(int[] nums)
{
	int pivot = 0;
	//set the pivot 
	for(int i = nums.Length -1; i > 0; i--)
	{
		if(nums[i] > nums[i-1])
		{
			pivot = i-1;
			break;
		}
	}
	
	//Swap pivot with successor
	for(int i = nums.Length -1; i > pivot; i--)
	{
		if(nums[i] > nums[pivot])
		{
			Swap(ref nums[i], nums[pivot])
			pivot++;
			break;
		}
	}
	
	//Reverse suffix
	for(int i = pivot; i < pivot + (nums.Length-pivot)/2; i++)
	{
		Swap(ref nums[i], ref nums[nums.Length-1-(i-pivot));
	}
}

private static void Swap(ref int left, ref int right)
{
	var temp = left;
	left = right;
	right = temp;
}


