/*
68. Text Justification
 
Total Accepted: 54049
Total Submissions: 288187
Difficulty: Hard
Contributor: LeetCode
Given an array of words and a length L, format the text such that each line has exactly L characters and is fully (left and right) justified.

You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly L characters.

Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line do not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.

For the last line of text, it should be left justified and no extra space is inserted between words.

For example,
words: ["This", "is", "an", "example", "of", "text", "justification."]
L: 16.

Return the formatted lines as:
[
   "This    is    an",
   "example  of text",
   "justification.  "
]
Note: Each word is guaranteed not to exceed L in length.

click to show corner cases.

Hide Company Tags LinkedIn Airbnb Facebook
Hide Tags String
*/



//Author:new2500
#region
	public List<string> FullJustify(string[] words, int maxWidth)
	{
		List<string> res = new List<string>();
		
		for(int i = 0, currIndex; i < words.Length; i = currIndex)
		{
			//i:index of words
			//currIndex: The current index of words in 1 line
			//lineLen: Current total length of words in 1 line
			
			int lineLen = -1;//We need to skip the space for last word hence set to -1
			
			for(currIndex = i; 
			    currIndex < words.Length && lineLen + words[currIndex].Length + 1 <= maxWidth;
				currIndex++)
			{
				lineLen = lineLen + words[currIndex].Length + 1; //Need add 1 for space
				
				StringBuilder curStr = new StringBuilder(words[i]);
				int space = 1, extra = 0;
				
				//Default value for evenlyDistributeSpace -> Deal with last line case
				
				//If Not 1 char, Not last line cases: currIndex - i - 1
				//currIndex is already pointing to next index
				//-1: for n word, there are n-1 spaces
				if(currIndex != i + 1 && currIndex != words.Length)
				{
					space = (maxWidth - lineLen) / (currIndex - i - 1) + 1; //+1 for default 1 space between words 
					extra = (maxWidth - lineLen) & (currIndex - i - 1);
				}
				
				//Not 1 char, including last line
				for(int j = i + 1; j < currIndex; j++)
				{
					//j: index of word in the current line
					
					for(int s = space; s > 0; s--) //Add the "even" space
					{
						curStr.Append(" ");
					}
					if(extra-- > 0)
					{
						curStr.Append(" ");
					}
					curStr.Append(word[j]);
				}
				
				//Last line case
				int strLen = maxWidth - curStr.Length;
				while(strLen > 0)
				{
					curStr.Append(" ");
					strLen--;
				}
				
				
				res.Add(curStr.ToString());
			}
		}
		return res;
	}


#end