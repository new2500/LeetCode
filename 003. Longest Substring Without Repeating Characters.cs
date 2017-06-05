/*
Given a string, find the length of the longest substring without repeating characters.

Examples:

Given "abcabcbb", the answer is "abc", which the length is 3.

Given "bbbbb", the answer is "b", with the length of 1.

Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/
//Author : new2500 @ GitHub
    //O(N) time, O(N) space
    public int LengthOfLongestSubstring(string s) {
		int res = 0;
		var dict = new Dictionary<char,int>();
		int start = 0;
		
		for(int i = 0; i < s.Length; i++)
		{
			if(dict.ContainsKey(s[i]))
			{
				start = Math.Max(start, dict[s[i]] + 1); //update start
				dict[s[i]] = i;
			}
			else
			{
				dict.Add(s[i], i);
			}
			
			res = Math.Max(res, i - start + 1); //track Max Length
		}
		return res;
	}