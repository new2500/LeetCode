/*
38. Count and Say
 
Total Accepted: 133674
Total Submissions: 394740
Difficulty: Easy
Contributor: LeetCode
The count-and-say sequence is the sequence of integers with the first five terms as following:

1.     1
2.     11
3.     21
4.     1211
5.     111221
1 is read off as "one 1" or 11.
11 is read off as "two 1s" or 21.
21 is read off as "one 2, then one 1" or 1211.
Given an integer n, generate the nth term of the count-and-say sequence.

Note: Each term of the sequence of integers will be represented as a string.

Example 1:

Input: 1
Output: "1"
Example 2:

Input: 4
Output: "1211"
Hide Company Tags Facebook
Hide Tags String
Hide Similar Problems (M) Encode and Decode Strings

*/


//Author: new2500

        public string CountAndSay(int n)
        {
            string s = "1";

            while (n > 1)
            {
                StringBuilder next = new StringBuilder();
                for (int i = 1, count = 1; i <= s.Length; i++,count++)
                {
                    if (i == s.Length || s[i] != s[i - 1])
                    {
                        next.Append(count).Append(s[i - 1]);
                        count = 0;
                    }
                }
                s = next.ToString();
                n--;
            }
            return s;
        }


#region Recursive Slow
	public string CountAnySay(int n)
	{
		if(n==1){
			return "1";
		}
		string pre = CountAnySay(n-1);
	
		return SayNext(pre);
	}

	private string SayNext(string start)
	{
		StringBuilder res = new StringBuilder();
		int pre = 0;
	
		for(int i = 0; i < start.Length; i++)
		{
			if(start[i] != start[pre])
			{
				res.Append(i-pre).Append(start[pre]);
				pre = i;
			}
		}
		res.Append(start.Length - pre).Append(start[pre]);
	
		return res.ToString();
	}

#endregion

