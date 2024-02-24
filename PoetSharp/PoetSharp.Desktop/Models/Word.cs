namespace PoetSharp.Desktop.Models
{
    public class Word
    {
        public string Text { get; set; } = "";
        public int SyllableCount { get; set; }

        public Word(string text, int syllableCount)
        {
            Text = text;
            SyllableCount = syllableCount;
        }
    }
}
