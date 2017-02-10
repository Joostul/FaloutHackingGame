using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FalloutHacking.ViewModels
{
    public class HackingGameViewModel
    {
        public int GuessesLeft;
        public List<string> GameWords;
        public string WinningWord;
        public int CorrectLetters;
    }
}
