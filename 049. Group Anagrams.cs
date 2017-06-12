/*
49. Group Anagrams
 
Total Accepted: 132421
Total Submissions: 393518
Difficulty: Medium
Contributor: LeetCode
Given an array of strings, group anagrams together.

For example, given: ["eat", "tea", "tan", "ate", "nat", "bat"], 
Return:

[
  ["ate", "eat","tea"],
  ["nat","tan"],
  ["bat"]
]
Note: All inputs will be in lower-case.

Hide Company Tags Amazon Bloomberg Uber Facebook Yelp
Hide Tags Hash Table String
Hide Similar Problems (E) Valid Anagram (M) Group Shifted Strings

*/

//Author: new2500


#region HashTable O(N^2) time, O(N) space
// Sort the string by char. Have a Hash table- key:sorted string; value: List of string that has same sorted string(Anagrams)

	public List<List<string>> GroupAnagram(string[] strs)
	{
		var dict = new Dictionary<string, List<string>>();
		
		foreach(var s in strs)
		{
			//Using new string much faster then string.concat...
			string SortedString = new string(s.OrderBy(c => c).ToArray());
			
			if(dict.ContainsKey(SortedString))
			{
				dict[SortedString].Add(s);
			}
			else
			{
				dict.Add(SortedString, new List<string>() {s} );
			}
		}	
		return dict.Select(one => one.Value).ToList();
	}
#endregion




#region Improvment on Sorting, using Counting Sort

	public List<List<string>> GroupAnagram(string[] strs)
	{
		var map = new Dictionary<string, List<string>>();
		int[] countingMap = new int[26];
		
		foreach(string s in strs)
		{
			string key = SortString(s, countingMap);
			if(!map.ContainsKey(key))
				map[key] = new List<string>();
			map[key].Add(s);
		}
		return map.Values.ToList();
	}
	
	
	public string SortString(string str, int[] countingMap)
	{
		char[] chars = new char[s.Length];
		
		foreach(char c in str)
		{
			countingMap[c - 'a']++;
		}
		int pos = 0;
		for(int i = 0; i < 26; i++)
		{
			while(countingMap[i] > 0)
			{
				chars[pos++] = (char)('a' + i);
				countingMap[i]--;
			}
		}
		return new string(chars);
	}


#endregion