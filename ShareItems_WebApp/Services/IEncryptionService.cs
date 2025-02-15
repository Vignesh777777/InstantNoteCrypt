namespace ShareItems_WebApp.Services
{
    public interface IEncryptionService
    {
        public string EncryptData(string plainText);
        public string DecryptData(string plainText);
    }
}
