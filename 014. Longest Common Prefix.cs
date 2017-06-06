/*14. Longest Common Prefix

Write a function to find the longest common prefix string amongst an array of strings.
Company: Yelp
Tag: String
*/

//Author: new2500

//Sort and Combine O(N*logN) time, 
public string LongestCommonPrefix(string[] strs)
{
	if(strs.Length == 0)
		return string.Empty;
	
	Array.Sort(strs);
	
	var first = strs[0];
	var last = strs[strs.Length-1];
	
	StringBuilder sb = new StringBuilder();
	
	for(int i = 0; i < first.Length; i++)
	{
		if(frist[i] != last[i])
			break;
		sb.Append(first[i]);
	}
	
	return sb.ToString();
}



//Using Min Index Method
/*
1. start at index 0
2. check each string if they have the same char at the index
3. if all have the same char increment the index
4. terminate if any mismatch is found or any string has exceeded it's length
*/
public string LongestCommonPrefix(string[] strs)
{
	int min = 0;
	while(strs.Length > 0)
	{
		foreach(string s in strs)
		{
			if(s.Length == min || s[min] != strs[0][min])
				return strs[0].Substring(0, min);
		}
		min++;
	}
	return "";
}