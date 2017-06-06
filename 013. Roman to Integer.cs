/*13. Roman to Integer
Given a roman numeral, convert it to an integer.

Input is guaranteed to be within the range from 1 to 3999.

Company: M$, BB, Uber, FB, Yahoo
Tag: Math, String
Similar: Integer to Roman
*/


//Scan string once from tail to head. If s[i]'s corresponding integer is no less than the previous one, add it to the result; otherwise, subtract it from the result.
public int RomanToInt(string s)
{
	var dict = new Dictionary<char, int>();
	dict.Add('I', 1);
	dict.Add('V', 5);
	dict.Add('X', 10);
	dict.Add('L', 50);
	dict.Add('C', 100);
	dict.Add('D', 500);
	dict.Add('M', 1000);
	
	int res = 0;
	int index = s.Length -1;
	int preInt = 0;
	
	while(index >= 0)
	{
		char curr = s[index];
		int currInt = dict[curr];
		if(currInt >= preInt)
			res += currInt;
		else
			res -= currInt;
		
		preInt = currInt;
		index--;
	}
	return res;
}