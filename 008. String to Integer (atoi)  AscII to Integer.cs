 
/*
8. String to Integer (atoi)  AscII to Integer
Implement atoi to convert a string to an integer.


Company: Amz, M$, BB, Uber
Tag: String, Math
Similar: Reverse Integer E, Valid Number H

*/
//Author: new2500
/* Use long to handle overflow
   1. Need to consider sign, nutral #, float point, but for this question we just need to consider # & sign.
   
   2. If leading char is a whitespace, skip to the next non-whitespace char, if reach last index, return 0.
   
   3. If 1st non-whitespace char is sign(+/-), mark the sign flag.
   
   4. If next char is #, convert to Int, if appear non-numeric char, return that char.
   
   5. If res# over the range of Int, return the Range Value of Int
*/
//O(N) time. O(N) space to store tirmed string
public int MyAtoi(string str)
{
	long res = 0;
	int sign = 1;
	str = str.Trim();    //Remove all leading and tailing whitespace
	if(string.IsNullOrEmpty(s))
		return 0;
	
	int index = 0;
	if(s[0] == '+' || s[0] == '-')
	{
		sign = (s[0] == '+') ? 1 : -1;
		index++;
	}
	
	while(index < str.Length)
	{
		if(!char.IsNumber(str[index]))   //Exist illegal char
			break;
		res = res * 10 + (str[index] - '0');

        //Edge cases
        if(res*sign > int.MaxValue)
           return int.MaxValue;
        if(res*sign < int.MinValue)
           return int.MinValue;			
		index++;	
	}
	return (int) res*sign;
}