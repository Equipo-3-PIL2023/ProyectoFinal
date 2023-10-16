using SmartInvest.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SmartInvest.Services
{
    public class AESEncriptadorService : IEncriptador
    {
        private const int TamanioClave = 32; // Tamaño de la clave en bytes (256 bits).
        private const int TamanioIV = 16; // Tamaño del vector de inicialización en bytes (128 bits).
        private readonly string key = "GWhQi2rFbDeC8uuiHgueSunKdf";

        public string Encriptar(string textoPlano)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(TamanioClave));
                aesAlg.IV = GenerarIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(textoPlano);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Desencriptar(string textoCifrado)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(TamanioClave));
                aesAlg.IV = GenerarIV();

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(textoCifrado)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private byte[] GenerarIV()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateIV();
                return aesAlg.IV;
            }
        }
    }
}