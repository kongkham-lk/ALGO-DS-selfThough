using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        string testStr1 = "babad";
        string testStr2 = "cbbd";
        string testStr3 = "bb";
        string testStr4 = "aaaaa";
        string testStr5 = "civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth";
        Console.WriteLine($"{testStr1}: {LongestPalindrome(testStr1)}\n");
        Console.WriteLine($"{testStr2}: {LongestPalindrome(testStr2)}\n");
        Console.WriteLine($"{testStr3}: {LongestPalindrome(testStr3)}\n");
        Console.WriteLine($"{testStr4}: {LongestPalindrome(testStr4)}\n");
        Console.WriteLine($"{testStr5}: {LongestPalindrome(testStr5)}\n");
    }

    public static string LongestPalindrome(string s)
    {
        if (s == null || s.Length == 0)
            return s;

        string result = "";
        List<string> memo = new List<string>();

        for (int i = 0; i < s.Length; i++)
        {
            int l = i;
            int r = i;

            IsPalindrome(s, ref result, l, r, ref memo);

            IsPalindrome(s, ref result, l, r + 1, ref memo);
        }

        return result;
    }

    public static bool IsPalindrome(string s, ref string result, int l, int r, ref List<string> memo)
    {
        if (!(l >= 0 && r < s.Length))
            return false;
        else if (memo.Contains(s.Substring(l, r - l + 1)))
            return false;

        if (s.Substring(l, 1).Equals(s.Substring(r, 1)))
        {
            if (result.Length < r - l + 1)
                result = s.Substring(l, r - l + 1);
            if (IsPalindrome(s, ref result, l-1, r+1, ref memo))
                return true;
        }
        else if (!memo.Contains(s.Substring(l, r - l + 1)))
            memo.Add(s.Substring(l, r - l + 1));

        return false;
    }
}