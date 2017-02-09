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

        #region
        //internal void PlayGame(List<string> words)
        //{
        //    foreach (var word in words)
        //    {
        //        Console.WriteLine(word);
        //    }

        //    words = words.OrderBy(a => Guid.NewGuid()).ToList();
        //    string correctWord = words[0];

        //    int guessesLeft = 4;
        //    bool hasWon = false;

        //    while (guessesLeft > 0 && hasWon == false)
        //    {
        //        Console.WriteLine("Now guess a word ({0} guesses left): "
        //            , guessesLeft);
        //        string guess = Console.ReadLine().ToUpper();
        //        if (words.Contains(guess))
        //        {
        //            if (guess == correctWord)
        //            {
        //                hasWon = true;
        //            }
        //            else
        //            {
        //                guessesLeft -= 1;
        //                int correctLetters = 0;

        //                // Check how many letters are correct.
        //                for (int i = 0; i < correctWord.Length; i++)
        //                {
        //                    if (guess[i] == correctWord[i])
        //                    {
        //                        correctLetters += 1;
        //                    }
        //                }

        //                Console.WriteLine("{0} out of {1} characters were correct (and in the correct location), please guess again."
        //                    , correctLetters
        //                    , correctWord.Length);
        //            }
        //        }
        //        else
        //        {
        //            guessesLeft -= 1;
        //            Console.WriteLine("Your word is not in the list.");
        //        }
        //    }

        //    if (hasWon)
        //    {
        //        Console.WriteLine("You guessed correctly! Congratulations!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("No guesses left, your word was {0}"
        //            , correctWord);
        //    }
        //}
        #endregion
    }
}
