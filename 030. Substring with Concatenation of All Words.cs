/*
30. Substring with Concatenation of All Words
 
Total Accepted: 78240
Total Submissions: 358475
Difficulty: Hard
Contributor: LeetCode
You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.

For example, given:
s: "barfoothefoobarman"
words: ["foo", "bar"]

You should return the indices: [0,9].
(order does not matter).

Hide Tags Hash Table Two Pointers String
Hide Similar Problems (H) Minimum Window Substring
*/

//Author: new2500
//O(NK) time, N is length of s, K is length of single word; O(2n) space for Hash table
public List<int> FindSubstring(string s, string[] words)
{
	List<int> res = new List<int>();
	
	if(string.IsNullOrEmpty(s) || words == null || words.Length == 0)
		return res;
	
	//key:word Value:Count
	var dict = new Dictionary<string, int>();
	foreach(var w in words)
	{
		if(!dict.ContainsKey(w))
			dict.Add(w, 1);
		else
			dict[w]++;
	}
	
	var dictCpoy = new Dictionary<string, int>(dict);
	int Width = words[0].Length;         //Since all word are same length, use as Width
	
	for(int i = 0; i <= s.Length - words.Length * Width; i++)
	{
		int j = 0;
		while(j < words.Length)
		{
			string temp = s.Substring(i+j*Width, Width);
			if(!dict.ContainsKey(temp))
				break;
			else if(--dict[temp] < 0)
				break;
			j++;
		}
		if(j == words.Length)   //All valid case reach this line
			res.Add(i);
		
        dict = new Dictionary<string, int>(dictCpoy);   //Since we use dict in the loop, need to restore back for each i		
	}
	return res;
}