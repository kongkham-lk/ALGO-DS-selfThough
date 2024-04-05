public class Solution
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("LongestPalindrome of babad: " + LongestPalindrome("babad") + "\n");
        //Console.WriteLine("LongestPalindrome of cbbd: " + LongestPalindrome("cbbd") + "\n");
        //Console.WriteLine("LongestPalindrome of aaaa: " + LongestPalindrome("aaaa") + "\n");
        Console.WriteLine("LongestPalindrome of aacabdkacaa: " + LongestPalindrome("aacabdkacaa") + "\n");
    }

    public static string LongestPalindrome(string s)
    {
        if (s.Length == 0)
            return s;

        var longestStr = s.Substring(0, 1);

        int l = 0;
        int r = s.Length - 1;

        List<string> memo = new();

        while (l < s.Length - 1 && r >= 0)
        {
            if (longestStr.Length < r - l + 1 && IsPalindrome(s.Substring(l, r - l + 1), ref memo))
                longestStr = s.Substring(l, r - l + 1);
            if (longestStr.Length < s.Length - l && IsPalindrome(s.Substring(l, s.Length - l), ref memo))
                longestStr = s.Substring(l, s.Length - l);
            if (longestStr.Length < r + 1 && IsPalindrome(s.Substring(0, r + 1), ref memo))
                longestStr = s.Substring(0, r + 1);

            l++;
            r--;
        }

        return longestStr;
    }

    public static bool IsPalindrome(string s, ref List<string> memo)
    {
        if (memo.Contains(s))
            return false;

        if (s.Length <= 1)
            return true;

        if (s.Substring(0, 1).Equals(s.Substring(s.Length - 1, 1)))
        {
            if (IsPalindrome(s.Substring(1, s.Length - 1 - 1), ref memo))
                return true;
            else
            {
                if (!memo.Contains(s.Substring(1, s.Length - 1 - 1)))
                    memo.Add(s.Substring(1, s.Length - 1 - 1));
                return false;
            }
        }

        return false;
    }
}