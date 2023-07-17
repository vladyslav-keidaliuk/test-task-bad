using System;
using System.Collections.Generic;

namespace TestTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string text = @"The Tao gave birth to machine language. Machine language gave birth
to the assembler.
The assembler gave birth to the compiler. Now there are ten thousand
languages.
Each language has its purpose, however humble. Each language
expresses the Yin and Yang of software. Each language has its place within
the Tao.
But do not program in COBOL if you can avoid it.
        -- Geoffrey James, ""The Tao of Programming"" ";
            

            Console.WriteLine(FindFirstUniqueSymbol(text));// Поверне 'm'
            
        }


        private static char FindFirstUniqueSymbol(string text)
        {
            string[] words = text.Split();
        
            List<char> uniqueSymbols = GetUniqueSymbols(words);
            char firstUniqueSymbol = FindFirstSymbolWithSingleOccurrence(uniqueSymbols);
        
            return firstUniqueSymbol;
        }

        private static List<char> GetUniqueSymbols(string[] words)
        {
            List<char> uniqueSymbols = new List<char>();
            foreach (string word in words)
            {
                Dictionary<char, int> symbolCount = GetSymbolCount(word);
                foreach (char c in word)
                {
                    if (symbolCount[c] == 1)
                    {
                        uniqueSymbols.Add(c);
                        break;
                    }
                }
            }
            return uniqueSymbols;
        }

        private static Dictionary<char, int> GetSymbolCount(string word)
        {
            Dictionary<char, int> symbolCount = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (symbolCount.ContainsKey(c))
                    symbolCount[c]++;
                else
                    symbolCount[c] = 1;
            }
            
            return symbolCount;
        }

        private static char FindFirstSymbolWithSingleOccurrence(List<char> uniqueSymbols)
        {
            foreach (char symbol in uniqueSymbols)
            {
                if (uniqueSymbols.IndexOf(symbol) == uniqueSymbols.LastIndexOf(symbol))
                    return symbol;
            }
            return '\0'; 
        }
        
    }
}