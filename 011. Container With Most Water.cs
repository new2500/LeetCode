 
/*
11. Container With Most Water

Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container and n is at least 2.

Company: BB
tags: Array, Two Pointers
Similar: Trapping Rain Water H
*/

//Author: new2500

//Two pointers O(N) time, O(1) space
public int MaxArea(int[] height)
{
	int left = 0, right = height.Length-1;
	int max = 0;
	
	while(left < right)
	{
		max = Math.Max(max, Math.Min(height[left], height[right])*(right-left));
		
		if(height[left] < hright[right])
			left++;
		else
			right--;
	}
	return max;
}