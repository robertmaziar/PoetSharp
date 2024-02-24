using PoetSharp.Desktop.Models;

namespace PoetSharp.Desktop.ViewModels
{
    public class HighlightedWordViewModel : ViewModelBase
    {
        private readonly WordWithSyllableCount _wordWithSyllableCount;
        public HighlightedWordViewModel(WordWithSyllableCount wordWithSyllableCount)
        {
            _wordWithSyllableCount = wordWithSyllableCount;
        }

        public string Word => _wordWithSyllableCount.Word;

        public int SyllableCount => _wordWithSyllableCount.SyllableCount;

    }
}
