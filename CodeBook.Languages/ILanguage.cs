namespace CodeBook.Languages
{
    /// <summary>
    /// Represents a language
    /// </summary>
    public interface ILanguage
    {
        string RotateText(string text, int shift);
    }
}
