using System;

namespace first {
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
}
