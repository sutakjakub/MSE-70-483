using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing3_24 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\n shows how to use this generated certificate to sign and verify some text. The data is hashed and then signed. When verifying, the same hash algorithm is used to make sure the data has not changed.", FriendlyName());

            SignAndVerify();
            Console.WriteLine("Done.");
        }

        public string FriendlyName()
        {
            return "Listing 3-24";
        }

        #endregion


        public static void SignAndVerify()
        {
            string textToSign = "Testing paragrpah!";
            byte[] signature = Sign(textToSign, "cn=WouterDeKort");
            //signature[0] = 0;

            Console.WriteLine(Verify(textToSign, signature));
        }

        private static bool Verify(string text, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        private static byte[] Sign(string text, string p)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        private static byte[] HashData(string text)
        {
            HashAlgorithm alg = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = alg.ComputeHash(data);

            return hash;
        }

        private static X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store("testCertStore", StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            var certificate = my.Certificates[0];

            return certificate;
        }
    }
}
