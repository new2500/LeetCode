/*
58. Length of Last Word
 
Total Accepted: 143353
Total Submissions: 452855
Difficulty: Easy
Contributor: LeetCode
Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

If the last word does not exist, return 0.

Note: A word is defined as a character sequence consists of non-space characters only.

For example, 
Given s = "Hello World",
return 5.

Hide Tags String

*/


//Author:new2500


    
	public int LengthOfLastWord(string s)
	{
		int index = s.Length - 1;
		
		//Start from tail - Count the non-space index
		while(index >= 0 && s[index] == ' ') 
		{
			index--;  //This is Total length of non-whitespace chars
		}
		
		//Length of last word
		int len = 0;
		while(index >= 0 && s[index] != ' ') //Stop once we meet white-space => length of last word
		{
			len++;
			index--;
		}
		
		return len;
	}