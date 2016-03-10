namespace CodeBook.Languages
{
    /// <summary>
    /// Represents a language
    /// </summary>
    public interface ILanguage
    {
        char[] Alphabet { get; }
        string RotateText(string text, int shift);
    }
}
