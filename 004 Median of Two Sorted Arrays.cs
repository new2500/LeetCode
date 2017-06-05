/*Median of Two Sorted Arrays

There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

Example 1:
nums1 = [1, 3]
nums2 = [2]

The median is 2.0
Example 2:
nums1 = [1, 2]
nums2 = [3, 4]

The median is (2 + 3)/2 = 2.5

Company Tags: Google, Zenefits, Microsoft, Apple, Yahoo, Dropbox, Adobe
Tags: Binary Search, Array, Divide and Conquer

*/

//Author: new2500 @ GitHub

/*
      Thoughts: Convert it to find K th Problem.
	  if (midA < midB) [a0....midA....an] [b0...midB....bn]
  if(midA < midB) we know k must ahead of a mid, so we move a0 to miaA
  Each step reduce of k by k/2 time, Give us a Log time
*/




public double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
	int totalLen = nums1.Length + nums2.Length;
	int k = totalLen/2;                       //k: mid of total
	if(total%2 == 0)   //Even-case
	{
		return (findKth(k+1, nums1, nums2, 0, 0) + findKth(k, nums1, nums2, 0, 0))/ 2.0;
	}
     else//Odd-case
	 {
		 return (double)findKth(k+1, nums1, nums2,0,0);
	 }
}

//Binary-Search for Kth number
private int findKth(int k, int[] nums1, int[] nums1, int start1, int start2)
{
	//Two base exit cases:
	//1.if A is empty, result would be Kth of the B.
	//2.K==1, return min of {A,B}
	
	//Case 1:
	if(start1 >= nums1.Length) return nums2[start2+k-1];
	if(start2 >= nums2.Length) return nums1[start1+k-1];
	
	//Case 2:
	if(k == 1) return Math.Min(nums1[start1], nums2[start2]);
	
	
	//Binary Search Part:
	
	int midIdx1 = start1 + k/2 -1;
	int midIdx2 = start2 + k/2 -1;
	
	int mid1 = midIdx1 >= nums1.Length ? int.MaxValue : nums1[midIdx1];
	int mid2 = midIdx2 >= nums2.Length ? int.MaxValue : nums2[midIdx2];
	
	if(mid1 > mid2)
		return findKth(k-k/2, nums1, nums2, start1, midIdx2+1);
	else
		return findKth(k-k/2,nums1, nums2, midIdx1+1, start2);

}

