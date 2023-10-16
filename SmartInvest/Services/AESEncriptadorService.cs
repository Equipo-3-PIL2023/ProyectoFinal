using SmartInvest.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SmartInvest.Services
{
    public class AESEncriptadorService : IEncriptador
    {
        private const int TamanioClave = 32; // Tamaño de la clave en bytes (256 bits).
        private const int TamanioIV = 16; // Tamaño del vector de inicialización en bytes (128 bits).
        private readonly string key = "GWhQi2rFbDeC8uuiHgueSunKdfvkj";
        private readonly byte[] iv;

        public AESEncriptadorService()
        {
            // Genera el IV una vez durante la inicialización del servicio.
            iv = Encoding.UTF8.GetBytes("13abf09c6bea2f91");
        }

        public string Encriptar(string textoPlano)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key.PadRight(TamanioClave));
                aesAlg.IV = iv; // Usa el mismo IV para el cifrado y el descifrado.

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
                aesAlg.IV = iv; // Usa el mismo IV para el cifrado y el descifrado.

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

        /*private byte[] GenerarIV()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateIV();
                return aesAlg.IV;
            }
        }*/
    }
}