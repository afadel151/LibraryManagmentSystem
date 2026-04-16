using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Radzen.Blazor.Markdown;
using System.Security.Cryptography;
using System.Text;
namespace Borrowing.Web.Providers;

public interface IImageHelper
{
    string EncryptString(string plainText);
    string GetSmallImageUrl(string matricule);
}

public class ImageHelper : IImageHelper
{
    private readonly bool _useMock;
    private readonly string? _smallByMatriculeUrl;
    private readonly string? _appKey;
    private readonly string? _initialVector;

    public ImageHelper(IConfiguration configuration)
    {
        _useMock = configuration.GetValue<bool>("ImageSettings:UseMock");

        _smallByMatriculeUrl = _useMock
            ? configuration.GetValue<string>("MockImage:SmallByMatriculeUrl")
            : configuration.GetValue<string>("ImageSettings:SmallByMatriculeUrl");

        _appKey = _useMock
            ? configuration.GetValue<string>("MockImage:AppKey")
            : configuration.GetValue<string>("ImageSettings:AppKey");

        _initialVector = _useMock
            ? configuration.GetValue<string>("MockImage:InitialVector")
            : configuration.GetValue<string>("ImageSettings:InitialVector");
    }


    public string EncryptString(string plainText)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Encoding.UTF8.GetBytes(_appKey!);
        aesAlg.IV = Encoding.UTF8.GetBytes(_initialVector!);

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msEncrypt = new();
        using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            using StreamWriter swEncrypt = new(csEncrypt);
            swEncrypt.Write(plainText);
        }
        string encodedString = Convert.ToBase64String(msEncrypt.ToArray());
        return Base64UrlEncoder.Encode(encodedString);
    }

    public string GetSmallImageUrl(string matricule)
    {
        var encrypted = EncryptString(matricule);
        return _smallByMatriculeUrl +"/"+ encrypted;
    }
}