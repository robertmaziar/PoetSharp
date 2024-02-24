using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PoetSharp.Desktop.Models
{
    public class SyllableHighlighter
    {
        private Dictionary<string, string> cmuDictionary;

        public SyllableHighlighter()
        {
            LoadHardCodedDictionary();
        }

        private void LoadHardCodedDictionary()
        {
            cmuDictionary = new Dictionary<string, string>();
            string dictionaryFilePath = Path.Combine("C://Users//rober//Desktop", "words_with_stress.txt"); // Update with the path to your CMU Pronouncing Dictionary file
            //string dictionaryFilePath = Path.Combine("Resources", "words_with_stress.txt"); // Update with the path to your CMU Pronouncing Dictionary file
            string[] lines = File.ReadAllLines(dictionaryFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string word = parts[0];
                string pronunciation = parts[1].Replace('-', '·');
                int syllableCount = pronunciation.Count(c => c == '·') + 1;
                cmuDictionary[word.ToLower()] = pronunciation;
            }
        }

        //public ObservableCollection<WordWithSyllableCount> HighlightStressedSyllables(string sentence)
        //{
        //    // TODO: Split into words and lines
        //    // Split the sentence into words
        //    string[] words = Regex.Split(sentence, @"\s+");

        //    ObservableCollection<WordWithSyllableCount> stressedWords = new ObservableCollection<WordWithSyllableCount>();

        //    foreach (string word in words)
        //    {
        //        // Check if the word is in the CMU Pronouncing Dictionary
        //        if (cmuDictionary.TryGetValue(word.ToLower(), out string pronunciation)) // If the word exists but plural, allow
        //        {
        //            string stressedWord = pronunciation;
        //            int syllableCount = pronunciation.Count(c => c == '·') + 1;
        //            stressedWords.Add(new WordWithSyllableCount() { Word = stressedWord, SyllableCount = syllableCount });
        //        }
        //        else
        //        {
        //            // If the word is not found in the dictionary, keep it unchanged
        //            stressedWords.Add(new WordWithSyllableCount() { Word = word, SyllableCount = 0 });
        //        }
        //    }

        //    return stressedWords;
        //}

        public ObservableCollection<Sentence> HighlightStressedSyllables(string input)
        {
            ObservableCollection<Sentence> sentences = new ObservableCollection<Sentence>();

            // Split input into lines
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                List<WordWithSyllableCount> stressedWords = new List<WordWithSyllableCount>();
                // Split the line into words
                string[] words = Regex.Split(line, @"\s+");

                foreach (string word in words.Where(o => !string.IsNullOrWhiteSpace(o)))
                {
                    // Check if the word is in the CMU Pronouncing Dictionary
                    if (cmuDictionary.TryGetValue(word.ToLower(), out string pronunciation)) // If the word exists but plural, allow
                    {
                        string stressedWord = pronunciation;
                        int syllableCount = pronunciation.Count(c => c == '·') + 1;
                        stressedWords.Add(new WordWithSyllableCount() { Word = stressedWord, SyllableCount = syllableCount });
                    }
                    else
                    {
                        // If the word is not found in the dictionary, keep it unchanged
                        stressedWords.Add(new WordWithSyllableCount() { Word = word, SyllableCount = 0 });
                    }
                }

                sentences.Add(new Sentence() { WordGroup = stressedWords });
            }

            return sentences;
        }

    }
}
