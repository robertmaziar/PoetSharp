using PoetSharp.Desktop.Models;
using PoetSharp.Desktop.Services;
using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;

namespace PoetSharp.Desktop.ViewModels
{
    public class WordViewModel : ViewModelBase
    {

        private readonly ISentenceService _sentenceService;

        public ICommand OpenWordBookCommand { get; }
        public Interaction<WordBookViewModel, WordBookDefinitionViewModel> ShowDialog { get; }

        private readonly Word _word;

        public WordViewModel(Word word, ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;

            _word = word;

            ShowDialog = new Interaction<WordBookViewModel, WordBookDefinitionViewModel>();
            OpenWordBookCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var wordBook = new WordBookViewModel(_sentenceService);

                var result = await ShowDialog.Handle(wordBook);

                //if (result != null)
                //{
                //    Albums.Add(result);
                //}
            });
            _sentenceService = sentenceService;
        }

        public string Text => _word.Text;

        public int SyllableCount => _word.SyllableCount;

    }
}
