using PoetSharp.Desktop.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace PoetSharp.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private SentenceValidator sentenceValidator;

        public MainWindowViewModel()
        {
            inputText = "";
            sentenceValidator = new SentenceValidator();
            validatedSentences = new ObservableCollection<Sentence>();
        }

        private string inputText;
        public string InputText
        {
            get => inputText;
            set
            {
                this.RaiseAndSetIfChanged(ref inputText, value);
                ValidatedSentences = sentenceValidator.GetValidatedInput(inputText);
            }
        }

        private ObservableCollection<Sentence> validatedSentences;
        public ObservableCollection<Sentence> ValidatedSentences
        {
            get => validatedSentences;
            set => this.RaiseAndSetIfChanged(ref validatedSentences, value);
        }

        public ObservableCollection<SentenceViewModel> SentenceViewModels { get; } = new();

        public void LoadSentenceView()
        {
            SentenceViewModels.Clear();

            foreach (Sentence sentence in ValidatedSentences)
            {
                SentenceViewModel vm = new SentenceViewModel(sentence);

                SentenceViewModels.Add(vm);
            }
        }
    }
}