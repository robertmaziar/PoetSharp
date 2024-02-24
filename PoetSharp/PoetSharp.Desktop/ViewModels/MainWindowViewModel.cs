using PoetSharp.Desktop.Models;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace PoetSharp.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private SyllableHighlighter syllableHighlighter;

        public MainWindowViewModel()
        {
            syllableHighlighter = new SyllableHighlighter();
            Sentences = new ObservableCollection<Sentence>();
   
            //this.WhenAnyValue(x => x.HighlightedWords)
            //   .Where(x => x.Count > 0)
            //   .Throttle(TimeSpan.FromMilliseconds(400))
            //   .ObserveOn(RxApp.MainThreadScheduler)
            //   .Subscribe(LoadWordsView!);    
        }

        private string inputText;
        public string InputText
        {
            get => inputText;
            set
            {
                this.RaiseAndSetIfChanged(ref inputText, value);
                Sentences = syllableHighlighter.HighlightStressedSyllables(inputText);
            }
        }

        //private ObservableCollection<WordWithSyllableCount> highlightedWords;
        //public ObservableCollection<WordWithSyllableCount> HighlightedWords
        //{
        //    get => highlightedWords;
        //    set => this.RaiseAndSetIfChanged(ref highlightedWords, value);
        //}

        private ObservableCollection<Sentence> sentences;
        public ObservableCollection<Sentence> Sentences
        {
            get => sentences;
            set => this.RaiseAndSetIfChanged(ref sentences, value);
        }

        public ObservableCollection<SentenceViewModel> SentenceViewModels { get; } = new();

        public void LoadSentenceView()
        {
            SentenceViewModels.Clear();

            foreach (var sentence in Sentences)
            {
                var vm = new SentenceViewModel(sentence);

                SentenceViewModels.Add(vm);
            }
        }
    }
}