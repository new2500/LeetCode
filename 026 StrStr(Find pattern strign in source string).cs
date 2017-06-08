/*
28. Implement strStr()
 
Total Accepted: 180442
Total Submissions: 650739
Difficulty: Easy
Contributor: LeetCode
Implement strStr().

Returns the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Hide Company Tags Pocket Gems Microsoft Apple Facebook
Hide Tags Two Pointers String
Hide Similar Problems (H) Shortest Palindrome (E) Repeated Substring Pattern
*/

//Author: new2500
//This question could be lead to HARD KMP algorithm, be careful


//Brute Force O((n-m)*n)

public int StrStr(string haystack, string needle)
{
	if(string.IsNullOrEmpty(needle)) return 0;
	
	for(int i = 0; i <= haystack.Length - needle.Length; i++)
	{
		for(int j = 0; j < needle.Length && haystack[i+j] == needle[j];j++)
		{
			if(j == needle.Length-1)   //All needle found in haystack
				return i;              //return the start index in haystack
		}
	}
}


#region KMP
//KMP algorithm O(N), HARD in interview, deserve a strong hire

public int StrStr(string haystack, string needle)
{
	//Invalid input
	if(haystack == null || needle == null || needle.Length > haystack.Length)
		return -1;
	
	int[] prefixTable = KMP(needle);
	
	int i = 0, j = 0;
	while(i < haystack.Length && j < needle.Length)
	{
		if(haystack[i] == needle[j])
		{
			i++; j++;
		}
		else if(j > 0)
		{
			j = prefixTable[j-1];
		}
		else
			i++;
	}
	return j == needle.Length ? i-j : -1;
}

//Generate the Prefix Table
//Value in the table: The length of longest proper prefix that matches a proper suffix in the same subpattern
/*  Example:       ACACA
 *     prefix[]:   00123
 *    why  "ACA" is 1? becasue for ACA, "AC" could be prefix, "A" could be a suffix, the length of "A" is 1
 *    why "ACAC" is 2? Because "AC" could be a prefix and suffix, "AC" is length 2, so it's 2
       Same applied to "ACACA" since "ACA" 
 */    
private int[] KMP(string pattern)
{
	//invalid input
	if(string.IsNullOrEmpty(pattern))
		return null;
	
	int[] res = new int[pattern.Length];
	
	if(pattern.Length == 1)
		return res;
	
	int i = 1, j = 0;
	
	while(i < pattern.Length)
	{
		if(pattern[i] == pattern[j])
		{
			res[i] = j+1;
			i++; j++;
		}
		else if(j > 0)
			j = res[j-1];
		else
			i++;
	}
	return res;
}



#endregion
