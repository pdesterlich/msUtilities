using Microsoft.VisualStudio.TestTools.UnitTesting;
using msUtilities;

namespace msUtilities_452_test
{
    [TestClass]
    public class MsStringCipherTest
    {
        [TestMethod]
        public void TestStringEncryptDecrypt()
        {
            const string testo = "this is a text";
            const string password = "password";

            var encrypted = MsStringCipher.Encrypt(testo, password);
            var decrypted = MsStringCipher.Decrypt(encrypted, password);

            Assert.AreEqual(testo, decrypted);
        }

        [TestMethod]
        public void TestStringEncryptDecryptWithDifferentText()
        {
            const string testo = "this is a different (and longer) text";
            const string password = "this is a password";

            var encrypted = MsStringCipher.Encrypt(testo, password);
            var decrypted = MsStringCipher.Decrypt(encrypted, password);

            Assert.AreEqual(testo, decrypted);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Security.Cryptography.CryptographicException))]
        public void TestStringEncryptDecryptWithWrongPassword()
        {
            const string testo = "this is a text";
            const string password = "password";
            const string wrongPassword = "wrong_password";

            var encrypted = MsStringCipher.Encrypt(testo, password);
            MsStringCipher.Decrypt(encrypted, wrongPassword);
        }
    }
}
