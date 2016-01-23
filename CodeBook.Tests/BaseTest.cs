namespace CodeBook.Tests
{
    public abstract class BaseTest
    {
        protected const string Keyphrase = "businafasol";
        protected const string Keyword = "white";
        protected const string Message = "divert troops to east ridge";

        public abstract void EncryptTest();
        public abstract void DecryptTest();

    }
}
