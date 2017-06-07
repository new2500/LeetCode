/*
20. Valid Parentheses

Total Accepted: 199995
Total Submissions: 604300
Difficulty: Easy
Contributor: LeetCode

Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.

Company Tags: Google Airbnb Facebook Twitter Zenefits Amazon Microsoft Bloomberg
Tags Stack String
Similar Problems (M) Generate Parentheses (H) Longest Valid Parentheses (H) Remove Invalid Parentheses
*/


//Author: new2500

//Stack with HashTable O(N) time, O(N) space
public bool IsValid(string s)
{
	//empty string and odd length string are invalid
	if(string.IsNullOrEmpty(s) || s.Length % 2 != 0)
		return false;
	
	Dictionary<char, char> LeftP = new Dictionary<char, char>();
	LeftP['('] = ')';
	LeftP['{'] = '}';
	LeftP['['] = ']';
	
	Dictionary<char, char> RightP = new Dictionary<char, char>();
    RightP[')'] = '(';
    RightP['}'] = '{';
	RightP[']'] = '[';
	
	Stack<char> stack = new Stack<char>();
	
	for(int i = 0 ; i < s.Length ; i++)
	{
		if(LeftP.ContainsKey(s[i]))   //Only push LeftP
			stack.Push(s[i]);
		else if(RightP.ContainsKey(s[i]))
		{
			if(stack.Count == 0) return false;  //Since must in correct order - Left come first
			char curr = stack.Pop();
			if(LeftP[curr] != s[i]) return false;   //Non-Match cases
		}			
	}
	if(stack.Count > 0) return false;
	return true;
}