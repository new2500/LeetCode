/*
84. Largest Rectangle in Histogram
 
Total Accepted: 89433
Total Submissions: 340159
Difficulty: Hard
Contributor: LeetCode
Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.

https://leetcode.com/static/images/problemset/histogram.png
Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].

https://leetcode.com/static/images/problemset/histogram_area.png
The largest rectangle is shown in the shaded area, which has area = 10 unit.

For example,
Given heights = [2,1,5,6,2,3],
return 10.
*/




//Author:new2500



#region Two pass using a stack O(N) time, O(N) stack
    /* 
    1. Push things into stack when histogram is increasing
    2. Once the histogram start decreasing, pop th stack, and find the area
    3. Once we reach the end, pointer will be at the height.Length -1
    4. Pop and do the same things as we did
    5. Use maxArea to track the maximum of area
    
	If the stack is not empty, then one by one remove all bars from stack and do step 2.b for every removed bar.
    */

	public int LargestRectangleArea(int[] height)
	{
		//Check null
		if(heights == null || heights.Length == 0)
			return 0;
		
		Stack<int> stack = new Stack<int>();
		
		int maxArea = 0, i = 0;
		
		while(i < heights.Length)
		{
			if(!stack.Any() || heights[i] >= heights[stack.Peek()])
			{
				stack.Push(i);
				i++;
			}
			else
			{
				int stackTop = stack.Pop();
				//Height
				int hst = heights[stackTop];
				//Width
				int range = stack.Any() ? i - stack.Peek() - 1 : i;
				maxArea = Math.Max(maxArea, hst * range);
			}
		}
		while(stack.Any())
		{
				int stackTop = stack.Pop();
				//Height
				int hst = heights[stackTop];
				//Width
				int range = stack.Any() ? i - stack.Peek() - 1 : i;
				maxArea = Math.Max(maxArea, hst * range);
		}
		return maxArea;
	}
	
		
#end


#region Brute Forece, O(N^2) time but have O(1) constant Space

	public int SpaceSavingLargestRectangleArea(int[] heights)
	{
		int maxArea = 0;
		
		for(int i = 0; i < heights.Length; i++)
		{
			int minHeight = int.MaxValue;
			for(int j = i; j < heights.Length; j++)
			{
				minHeight = Math.Min(minHeight, heights[j]);
				maxArea = Math.Max(maxArea, minHeight * (j - i + 1));
			}
		}
		return maxArea;
	}

#end 