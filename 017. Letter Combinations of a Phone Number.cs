/*
17. Letter Combinations of a Phone Number

Given a digit string, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below.

Watch your phone keyboard!
1      2abc   3def
4ghi   5jkl   6mno
7pqrs  8tuv   9wxyz
*       0      #


Input:Digit string "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
*/

//Author: new2500

public List<string> LetterCombinations(string digits)
{
	if(string.IsNullOrEmpty(digits))
		return new List<string>();
	
	Queue<string> ans = new Queue<string>();
	
	string[] map = {"0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs","tuv", "wxyz"};
	
	for(int i = 0; i < digits.Length; i++)
	{
		int x = digits[i] - '0';
		
		while(ans.Peek().Length == i)
		{
			string temp = ans.Dequeue();
			foreach(char s in map[x])
			{
				ans.Enqueue(temp + s);
			}
		}
	}
	return ans.ToList();
}