using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing3_17 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}Listing 3-17 shows an example of using this algorithm to encrypt and decrypt a piece of text. As you can see, AES is a symmetric algorithm that uses a key and IV for encryption. By using the same key and IV, you can decrypt a piece of text. The cryptography classes all work on byte sequences.", FriendlyName());

            EncryptText("my secrete text");
            Console.WriteLine("Done.");
        }

        public string FriendlyName()
        {
            return "Listing 3-17";
        }

        #endregion

        private static void EncryptText(string text)
        {
            string original = text;
            using (SymmetricAlgorithm symmetricAlg = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlg, original);
                string roundTrip = Decrypt(symmetricAlg, encrypted);

                Console.WriteLine("Original: {0}", original);
                Console.WriteLine("Roundtrip: {0}", roundTrip);
            }
        }

        private static byte[] Encrypt(SymmetricAlgorithm symmetricAlg, string original)
        {
            ICryptoTransform encryptor = symmetricAlg.CreateEncryptor(symmetricAlg.Key, symmetricAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrpt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrpt = new StreamWriter(csEncrpt))
                    {
                        swEncrpt.Write(original);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        private static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
