using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public enum Digits {
    One, Two, Three, Four, Five, Six, Seven, Eight, Nine
}
class Program {
    private static Regex regex = new Regex(@"(one|two|three|four|five|six|seven|eight|nine)|[1-9]", RegexOptions.RightToLeft);
    const string Path = @"C:\Users\damia\Desktop\sideprojects\aoc#\inputs\input";
    public static void Main(string[] args) {
        if (!File.Exists(Path)) return;
        
        StringSolution stringSolution = new StringSolution();
        long sum = 0;
        
        using (StreamReader streamReader = File.OpenText(Path)) {
            string input;   
            int i = 1;
            while((input = streamReader.ReadLine()) != null) {
                MatchCollection matches = regex.Matches(input);
                string firstMatchValue = matches[matches.Count-1].Groups[0].Value;
                string lastMatchValue = matches[0].Groups[0].Value;
    
                if (firstMatchValue != string.Empty) {
                    int firstValue = 0;
                    int lastValue = 0;
                    stringSolution.digits.TryGetValue(firstMatchValue, out firstValue);
                    stringSolution.digits.TryGetValue(lastMatchValue, out lastValue);
                    Console.WriteLine($"no. {i}: {firstMatchValue} | {firstValue} | {lastMatchValue} | {lastValue}");
                    sum += firstValue * 10;
                    sum += lastValue;
                }
                i++;
            }
        }
        Console.WriteLine($"Suma: {sum}");
    }


}

public class StringSolution {
    public Dictionary<string, Int32> digits = CreateDigitsDictionary();

    private static Dictionary<string, Int32> CreateDigitsDictionary() {
        Dictionary<string, Int32> digits = new Dictionary<string, int>();
        Int32 value = 1;
        foreach (string digit in Enum.GetNames(typeof(Digits))) {
            digits.Add(digit.ToLower(), value);
            digits.Add(value.ToString(), value);
            value++;
        }
        return digits;
    }
}
public class IntegerSolution {
    public int FindFirstDigitInString(string str) {
        Int32 number = 0;
        foreach (char letter in str) {
            if(Int32.TryParse(letter.ToString(), out number)) return number;
        }

        return number;
    }
    public int FindLastDigitInString(string str) {
        Int32 number = 0;
        foreach (char letter in str) {
            Int32 numberFromString = 0;
            if (Int32.TryParse(letter.ToString(), out numberFromString)) {
                number = numberFromString;
            }
        }

        return number;
    }
}
