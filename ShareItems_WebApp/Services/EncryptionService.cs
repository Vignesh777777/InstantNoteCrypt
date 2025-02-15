using Microsoft.AspNetCore.DataProtection;
using ShareItems_WebApp.Services;

public class EncryptionService : IEncryptionService
{
    private readonly IDataProtector _protector;

    // Constructor to initialize the IDataProtector using dependency injection
    public EncryptionService(IDataProtectionProvider provider)
    {
        // 'MyPurpose' is a unique string that ensures different protection policies for different purposes
        _protector = provider.CreateProtector("MyPurpose");
    }

    // Method to encrypt plain text data
    public string EncryptData(string plainText)
    {
        return _protector.Protect(plainText);
    }

    // Method to decrypt the encrypted data
    public string DecryptData(string encryptedData)
    {
        try
        {
            return _protector.Unprotect(encryptedData);
        }
        catch (Exception ex)
        {
            // If decryption fails (e.g., data is tampered or invalid), handle the exception
            return $"Decryption failed: {ex.Message}";
        }
    }

    // Method to encrypt byte array data
    public byte[] EncryptData(byte[] plainData)
    {
        return _protector.Protect(plainData);
    }

    // Method to decrypt byte array data
    public byte[] DecryptData(byte[] encryptedData)
    {
        try
        {
            return _protector.Unprotect(encryptedData);
        }
        catch (Exception ex)
        {
            // If decryption fails (e.g., data is tampered or invalid), handle the exception
            throw new Exception($"Decryption failed: {ex.Message}", ex);
        }
    }
}
