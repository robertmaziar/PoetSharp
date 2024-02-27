using PoetSharp.Desktop.Services;
using System.Collections.ObjectModel;

namespace PoetSharp.Desktop.ViewModels
{
    public class WordBookViewModel : ViewModelBase
    {
        private readonly ISentenceService _sentenceService;

        public WordBookViewModel(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;
            var temp = _sentenceService.GetData();
        }

        public ObservableCollection<WordBookDefinitionViewModel> wordBookDefinitions { get; } = new();
    }
}
