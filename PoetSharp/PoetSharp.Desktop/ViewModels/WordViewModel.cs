using PoetSharp.Desktop.Models;
using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;

namespace PoetSharp.Desktop.ViewModels
{
    public class WordViewModel : ViewModelBase
    {
        public ICommand OpenDictionaryCommand { get; }
        public Interaction<DictionaryViewModel, WordViewModel> ShowDialog { get; }

        private readonly Word _word;

        public WordViewModel(Word word)
        {
            _word = word;

            ShowDialog = new Interaction<DictionaryViewModel, WordViewModel>();
            OpenDictionaryCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var dictionary = new DictionaryViewModel();

                var result = await ShowDialog.Handle(dictionary);

                //if (result != null)
                //{
                //    Albums.Add(result);
                //}
            });
        }

        public string Text => _word.Text;

        public int SyllableCount => _word.SyllableCount;

    }
}
