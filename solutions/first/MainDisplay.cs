using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using first;


class MainDisplay {
    private static Regex regex = new Regex(@"(one|two|three|four|five|six|seven|eight|nine)|[1-9]", RegexOptions.IgnoreCase);
    private static Regex regex2 = new Regex(@"(one|two|three|four|five|six|seven|eight|nine)|[1-9]", RegexOptions.RightToLeft);
    const string Path = @"C:\Users\damia\Desktop\sideprojects\aoc#\inputs\input";
    public static void Main(string[] args) {
        if (!File.Exists(Path)) return;
        
        long sum = 0;
        using (StreamReader streamReader = File.OpenText(Path)) {
            string input;
            while ((input = streamReader.ReadLine()) != null) {
                List<string> result = GetRegexArray(regex, input);
                List<string> result2 = GetRegexArray(regex2, input);
                List<int> ints = ParseInt(result);
                List<int> ints2 = ParseInt(result2);
                sum += ints[0] * 10;
                sum += ints2[0];
            }
        }
        Console.WriteLine($"Suma: {sum}");
    }
    private static List<string> GetRegexArray(Regex regex, string input) {
        List<string> matchesList = new List<string>();
        MatchCollection matches = regex.Matches(input);
        for (int i = 0; i < matches.Count; i++) {
            matchesList.Add(matches[i].Groups[0].Value);
        }

        return matchesList;
    }
    private static List<int> ParseInt(List<string> digits) {
        List<int> integerResults = new List<int>();
        digits.ForEach(digit =>
        {
            if(int.TryParse(digit, out int value)) {
                integerResults.Add(value);
            }
            else {
                DigitParser digitParser = new DigitParser();
                int result = digitParser.Parse(digit);
                integerResults.Add(result);
            }
            
        });


        return integerResults;
    }


}

public class DigitParser {
    private Dictionary<string, int> digits = InitializeDictionary();

    public int Parse(string key) {
        if (!digits.ContainsKey(key)) return 0;
        digits.TryGetValue(key, out int value);
        return value;
    }
    private static Dictionary<string, int> InitializeDictionary() {
        Dictionary<string, int> digits = new Dictionary<string, int>();
        int value = 1;
        foreach (string digit in Enum.GetNames(typeof(Digits))) {
            digits.Add(digit.ToLower(), value);
            value++;
        }
        return digits;
    }
}

