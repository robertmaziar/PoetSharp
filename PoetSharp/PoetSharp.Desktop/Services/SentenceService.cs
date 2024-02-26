using PoetSharp.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PoetSharp.Desktop.Services
{
    public class SentenceService
    {
        private Dictionary<string, string> data;

        public SentenceService()
        {
            Init();
        }

        private void Init()
        {
            data = new Dictionary<string, string>();

            LoadFromFile();
        }

        private void LoadFromFile()
        {
            string dictionaryFilePath = Path.Combine("C://Users//rober//Desktop", "words_with_stress.txt"); // Update with the path to your CMU Pronouncing Dictionary file
            //string dictionaryFilePath = Path.Combine("Resources", "words_with_stress.txt"); // Update with the path to your CMU Pronouncing Dictionary file
            string[] lines = File.ReadAllLines(dictionaryFilePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string word = parts[0];
                string pronunciation = parts[1].Replace('-', '·');
                int syllableCount = pronunciation.Count(c => c == '·') + 1;
                data[word.ToLower()] = pronunciation;
            }
        }

        private void LoadFromDb()
        {
            // TODO: May need to implement SQL Lite
            throw new NotImplementedException();
        }

        public ObservableCollection<Sentence> GetValidatedInput(string input)
        {
            ObservableCollection<Sentence> sentences = new ObservableCollection<Sentence>();

            // Split input into lines
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                List<Word> stressedWords = new List<Word>();
                // Split the line into words
                string[] words = Regex.Split(line, @"\s+");

                foreach (string word in words.Where(o => !string.IsNullOrWhiteSpace(o)))
                {
                    // Check if the word is in the CMU Pronouncing Dictionary
                    if (data.TryGetValue(word.ToLower(), out string pronunciation))
                    {
                        string stressedWord = pronunciation;
                        int syllableCount = pronunciation.Count(c => c == '·') + 1;
                        stressedWords.Add(new Word(stressedWord, syllableCount));
                    }
                    else
                    {
                        // If the word is not found in the dictionary, keep it unchanged
                        stressedWords.Add(new Word(word, 0));
                    }
                }

                sentences.Add(new Sentence() { Words = stressedWords });
            }

            return sentences;
        }
    }
}
