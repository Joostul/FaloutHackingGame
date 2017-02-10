using FalloutHacking.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FalloutHacking.GameLogic
{
    public class HackingGame
    {
        private int _guessesLeft;
        private List<string> _gameWords;
        private string _winningWord;

        public int GuessesLeft { get { return _guessesLeft; } set { _guessesLeft = value; } }
        public List<string> GameWords
        {
            get { return _gameWords; }
            private set { _gameWords = value; }
        }
        public string WinningWord
        {
            get { return _winningWord; }
            private set { _winningWord = value; }
        }

        public void SetWordsWithDifficulty(int difficulty)
        {
            GuessesLeft = 4;

            List<string> words = new List<string>();
            switch (difficulty)
            {
                case 1:
                    words = GetGameWords(4, 6);
                    break;
                case 2:
                    words = GetGameWords(6, 8);
                    break;
                case 3:
                    words = GetGameWords(8, 11);
                    break;
                case 4:
                    words = GetGameWords(10, 13);
                    break;
                case 5:
                    words = GetGameWords(12, 15);
                    break;
                default:
                    words = GetGameWords(4, 6);
                    break;
            }

            GameWords = words;
        }

        private List<string> GetGameWords(int wordLength, int amountWords)
        {
            string path = Path.Combine(Path.GetDirectoryName(typeof(HackingGame).GetTypeInfo().Assembly.ToString()), @"GameFiles\enable1.txt");
            string[] files = File.ReadAllLines(path);

            string[] words = files
                .Select(s => s.ToUpperInvariant())
                .ToArray();

            var listedWords = words.Where(x => x.Length == wordLength)
                .OrderBy(g => Guid.NewGuid())
                .Take(amountWords).ToList();

            WinningWord = listedWords.FirstOrDefault();

            listedWords = listedWords
                .OrderBy(g => Guid.NewGuid())
                .ToList();

            return listedWords;
        }
    }
}
