using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CubeConundrum {
  class MyMain {
    private const string path = @"C:\Users\damia\Desktop\sideprojects\aoc#\inputs\input2";
    private const int Red = 12;
    private const int Green = 13;
    private const int Blue = 14;

    public static void Main(string[] args) {
      if (!File.Exists(path)) return;
      string line;
      double sum = 0;
      using (StreamReader streamReader = File.OpenText(path)) {
        while ((line = streamReader.ReadLine()) != null) {
          DataExporter dataExporter = new DataExporter(line);
          sum += dataExporter.GetMultiplicationValue();
        }
      }
      Console.WriteLine(sum);
    }
  }

  public class DataExporter {
    private Dictionary<string, List<int>> colorValues = new Dictionary<string, List<int>>();
    private string header;
    private string value;
    public DataExporter(string line) {
      string[] split = line.Split(':');
      header = split[0];
      value = split[1];
      InitializeDictionary();
      GetColorValues();
      SortListsDescending();
    }
    public int GetGameID() {
      string digit = header.Replace("Game", "");
      if (int.TryParse(digit, out int value)) {
        return value;
      }


      return 0;
    }
    public double GetMultiplicationValue() {
      List<int> greenValues = colorValues[Colors.green.ToString()];
      List<int> redValues = colorValues[Colors.red.ToString()];
      List<int> blueValues = colorValues[Colors.blue.ToString()];
      double multiplication = greenValues.First() * redValues.First() * blueValues.First();


      return multiplication;
    }
    public bool IsGamePossible() {
      List<int> greenValues = colorValues[Colors.green.ToString()];
      List<int> redValues = colorValues[Colors.red.ToString()];
      List<int> blueValues = colorValues[Colors.blue.ToString()];


      if (blueValues.Last() <= 14) return true;
      if (greenValues.Last() <= 13) return true;
      if (redValues.Last() <= 12) return true;


      return false;
    }
    private void SortListsDescending() {
      List<int> greenValues = colorValues[Colors.green.ToString()];
      List<int> redValues = colorValues[Colors.red.ToString()];
      List<int> blueValues = colorValues[Colors.blue.ToString()];
      redValues.Sort();
      redValues.Reverse();
      greenValues.Sort();
      greenValues.Reverse();
      blueValues.Sort();
      blueValues.Reverse();
    }
    private void GetColorValues() {
      string replaced = value.Replace(";", "");
      replaced = replaced.Replace(",", "");

      string[] split = replaced.Split(' ');

      for (var i = 0; i < split.Length - 1; i++) {
        if (int.TryParse(split[i], out int value)) {
          string color = split[i + 1];
          colorValues[color].Add(value);
        }
      }
    }
    private void InitializeDictionary() {
      colorValues.Add("red", new List<int>());
      colorValues.Add("green", new List<int>());
      colorValues.Add("blue", new List<int>());
    }


    public enum Colors {
      red,
      green,
      blue
    }
  }
}

