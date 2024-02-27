using PoetSharp.Desktop.Models;
using PoetSharp.Desktop.Services;

namespace PoetSharp.Desktop.ViewModels
{
    public class WordBookDefinitionViewModel : ViewModelBase
    {
        private readonly ISentenceService _sentenceService;
        private readonly WordBookDefinition _wordBookDefinition;

        public WordBookDefinitionViewModel(WordBookDefinition wordBookDefinition, ISentenceService sentenceService)
        {
            _wordBookDefinition = wordBookDefinition;
            _sentenceService = sentenceService;
        }

    }
}
