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

        for (int i = 0; i < s.Length; i++)
        {
            int l = i;
            int r = i;

            result = IsPalindrome(s, result, l, r);

            result = IsPalindrome(s, result, l, r + 1);
        }

        return result;
    }

    public static string IsPalindrome(string s, string result, int l, int r)
    {
        while (l >= 0 && r < s.Length
            && s.Substring(l, 1).Equals(s.Substring(r, 1)))
        {
            if (result.Length < r - l + 1)
                result = s.Substring(l, r - l + 1);
            l -= 1;
            r += 1;
        }

        return result;
    }
}