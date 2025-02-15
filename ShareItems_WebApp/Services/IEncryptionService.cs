namespace ShareItems_WebApp.Services
{
    public interface IEncryptionService
    {
        string EncryptData(string plainText);
        string DecryptData(string encryptedData);
        byte[] EncryptData(byte[] plainData);
        byte[] DecryptData(byte[] encryptedData);
    }
}
