using Microsoft.VisualStudio.TestTools.UnitTesting;
using msUtilities;

namespace msUtilities_452_test
{
    [TestClass]
    public class msStringCipherTest
    {
        [TestMethod]
        public void TestStringEncryptDecrypt()
        {
            string testo = "this is a text";
            string password = "password";

            string encrypted = MsStringCipher.Encrypt(testo, password);
            string decrypted = MsStringCipher.Decrypt(encrypted, password);

            Assert.AreEqual(testo, decrypted);
        }

        [TestMethod]
        public void TestStringEncryptDecryptWithDifferentText()
        {
            string testo = "this is a different (and longer) text";
            string password = "this is a password";

            string encrypted = MsStringCipher.Encrypt(testo, password);
            string decrypted = MsStringCipher.Decrypt(encrypted, password);

            Assert.AreEqual(testo, decrypted);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Security.Cryptography.CryptographicException))]
        public void TestStringEncryptDecryptWithWrongPassword()
        {
            string testo = "this is a text";
            string password = "password";
            string wrongPassword = "wrong_password";

            string encrypted = MsStringCipher.Encrypt(testo, password);
            string decrypted = MsStringCipher.Decrypt(encrypted, wrongPassword);
        }
    }
}
