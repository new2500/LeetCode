/*7. Reverse Integer

Reverse digits of an integer.

Example1: x = 123, return 321
Example2: x = -123, return -321

The input is assumed to be a 32-bit signed integer. Your function should return 0 when the reversed integer overflows.

Company: BB, Apple
Tags: Math
Similar: atoi M

*/

//Author: new2500

//Using Check keyword in C# to avoid all the invalid cases.
//Simple way, put last digit of x to first digit of res
//check keyword Doc: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked
public int Reverse(int x)
{
	try
	{
		int res = 0;
		while(x!=0)
		{
			res = checked(res*10 + x%10);
			x = x/10;
		}
		return res;
	}
	catch(Exception)
	{
		return 0;
	}
}


//A more general way(Not using Checked keyword)
//If overflow exist, the new result will not equal to previous one

public int Reverse(int x)
{
	int res = 0;
	
	while(x != 0)
	{
		int tail = x%10;
		int newRes = res*10 + tail;
		
		if((newRes - tail)/ 10 != res)   //check if the same
			return 0;
		res = newRes;
        x = x/10;		
	}
	return res;
}