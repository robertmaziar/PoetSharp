using PoetSharp.Desktop.Models;
using PoetSharp.Desktop.Services;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace PoetSharp.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISentenceService _sentenceService;

        public MainWindowViewModel()
        {
            inputText = "";
            validatedSentences = new ObservableCollection<Sentence>();
        }

        public MainWindowViewModel(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;

            inputText = "";
            validatedSentences = new ObservableCollection<Sentence>();
        }

        private string inputText;
        public string InputText
        {
            get => inputText;
            set
            {
                this.RaiseAndSetIfChanged(ref inputText, value);
                ValidatedSentences = _sentenceService.GetValidatedInput(inputText);
            }
        }

        private ObservableCollection<Sentence> validatedSentences;
        public ObservableCollection<Sentence> ValidatedSentences
        {
            get => validatedSentences;
            set => this.RaiseAndSetIfChanged(ref validatedSentences, value);
        }

        public ObservableCollection<SentenceViewModel> Sentences { get; } = new();

        public void LoadSentenceView()
        {
            Sentences.Clear();

            foreach (Sentence sentence in ValidatedSentences)
            {
                SentenceViewModel vm = new SentenceViewModel(sentence, _sentenceService);

                Sentences.Add(vm);
            }
        }
    }
}