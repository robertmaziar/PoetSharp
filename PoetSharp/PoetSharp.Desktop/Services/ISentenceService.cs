using PoetSharp.Desktop.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PoetSharp.Desktop.Services
{
    public interface ISentenceService
    {
        Dictionary<string, string> GetData();
        ObservableCollection<Sentence> GetValidatedInput(string input);
    }
}