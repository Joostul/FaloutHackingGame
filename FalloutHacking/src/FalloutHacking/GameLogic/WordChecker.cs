using FalloutHacking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalloutHacking.GameLogic
{
    public class WordChecker
    {
        public int GetCorrectLetters(string guess, HackingGameViewModel game)
        {
            int correctLetters = 0;

            for (int i = 0; i < game.WinningWord.Length; i++)
            {
                if (game.WinningWord.Contains(guess[i]))
                {
                    correctLetters += 1;
                }
            }

            return correctLetters;
        }
    }
}
