using System;
using System.IO;

namespace PMPHF05
{
  class Program
  {
    private static int[] registers = new int[4];

    static void Main()
    {
      ReadFromFile();
      WriteToFile();
    }

    static void ReadFromFile()
    {
      StreamReader sr = new StreamReader("input.txt");
      string tmp = sr.ReadLine();
      string[] tmp1 = tmp.Split(',');
      for (int i = 0; i < tmp1.Length; i++)
      {
        registers[i] = int.Parse(tmp1[i]);
      }
      while (!sr.EndOfStream)
      {
        string line = sr.ReadLine();
        string[] split = line.Split(' ');
        if (split[0] == "SUB")
        {
          Sub(split[1], split[2], split[3]);
        } else if (split[0] == "SUB")
        {
          Mov(split[1], split[2]);
        } else if (split[0] == "ADD")
        {
          Add(split[1], split[2], split[3]);
        } else
        {
          Jne(split[1], split[2], split[3]);
        }
      }
      sr.Close();
    }

    static void ReadFromFile(int num)
    {
      StreamReader sr = new StreamReader("input.txt");
      for (int i = 0; i <= num; i++)
      {
        sr.ReadLine();
      }
      
      string line = sr.ReadLine();
      string[] split = line.Split(" ");
      if (split[0] == "SUB")
      {
        Sub(split[1], split[2], split[3]);
      } else if (split[0] == "MOV")
      {
        Mov(split[1], split[2]);
      } else if (split[0] == "ADD")
      {
        Add(split[1], split[2], split[3]);
      } else
      {
        Jne(split[1], split[2], split[3]);
      }

      sr.Close();
    }

    static void WriteToFile()
    {
      StreamWriter sw = new StreamWriter("output.txt");
      for (int i = 0; i < registers.Length; i++)
      {
        if (i > 0)
        {
          sw.Write("," + registers[i]);
        }
        else
        {
          sw.Write(registers[i]);
        }
        Console.Write(registers[i] + " ");
      }
      sw.Close();
    }

    static int GetNumber(string num)
    {

      if (num == "A")
      {
        return registers[0];
      } else if (num == "B")
      {
        return registers[1];
      } else if (num == "C")
      {
        return registers[2];
      } else if (num == "D")
      {
        return registers[3];
      } else {
        return int.Parse(num);
      }
    }

    static void Mov(string dest, string num)
    {
        SaveResult(GetNumber(num), dest);
    }

    static void Add(string dest, string num0, string num1)
    {
      int result = GetNumber(num0) + GetNumber(num1);
      SaveResult(result, dest);
    }

    static void Sub(string dest, string num0, string num1)
    {
      int result = GetNumber(num0) - GetNumber(num1);
      SaveResult(result, dest);
    }

    static void Jne(string method, string src, string num)
    {
      while (GetNumber(src) != GetNumber(num))
      {
        ReadFromFile(int.Parse(method));
      }
    }

    static void SaveResult(int result, string register)
    {
      if (register == "A")
      {
        registers[0] = result;
      } else if (register == "B")
      {
        registers[1] = result;
      } else if (register == "C")
      {
        registers[2] = result;
      } else
      {
        registers[3] = result;
      }
    }
  }
}
