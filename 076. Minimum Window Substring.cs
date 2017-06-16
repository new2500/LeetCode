/*
76. Minimum Window Substring
 
Total Accepted: 100410
Total Submissions: 404628
Difficulty: Hard
Contributor: LeetCode
Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

For example,
S = "ADOBECODEBANC"
T = "ABC"
Minimum window is "BANC".

Note:
If there is no such window in S that covers all characters in T, return the empty string "".

If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.

Hide Company Tags LinkedIn Snapchat Uber Facebook
Hide Tags Hash Table Two Pointers String
Hide Similar Problems (H) Substring with Concatenation of All Words (M) Minimum Size Subarray Sum (H) Sliding Window Maximum (M) Permutation in String
*/


//Author:new2500



#region Using an Array for ASCII case, If for general cases, please replace the array for a Dictionary<char,int> hashtable

	public string MinWindow(string s, string t)
	{
		int[] dict = new int[256];   //Contains all char in ASCII
		foreach(var c in t)
		{
			dict[c]++;
		}
		
		int minLen = int.MaxValue;
		int minStart = 0;
		int total = t.Length;
		//Version1: Using a For-loop
		for(int i = 0, j = 0; i < s.Length; i++)
		{
			char sCurr = s[i];
			if(dict[sCurr] > 0)
				total--;
			
			dict[sCurr]--;
			
			//If we found a valid window, track the minWindow
			while(total == 0)
			{
				if(i - j + 1 < minLen)
				{
					minLen = i - j + 1;
					minStart = j;
				}
				
				//Proceed to find next window, need to move j
				dict[s[j]]++;
				if(dict[s[j]] > 0)
				{
					total++;
				}
				j++;
			}
		}
		#region Same logic as Version1, might help understand the whole flow
		//Version2 While loop 
		int end = 0, start = 0
		while(end < s.Length)
		{
			char sEnd = s[end];
			if(dict[sEnd] > 0)
			{
				total--;
			}
			dict[sEnd]--;
			end++;
			
			//Found a valid window, track the minWindow
			while(total == 0)
			{
				if(end - start < minLen)
				{
					minLen = end - start;
					minStart = start;
				}
				//Proceed to find next window, need to move start
				char s[start] = sStart;
				dict[sStart]++;
				if(dict[sStart] > 0)
				{
					total++;
				}
				start++;  //Now will out of while "total == 0" loop
			}
		}
		#end
		return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen);
	}

#end