using PoetSharp.Desktop.Models;

namespace PoetSharp.Desktop.ViewModels
{
    public class WordViewModel : ViewModelBase
    {
        private readonly Word _word;
        public WordViewModel(Word word)
        {
            _word = word;
        }

        public string Word => _word.Text;

        public int SyllableCount => _word.SyllableCount;

    }
}
