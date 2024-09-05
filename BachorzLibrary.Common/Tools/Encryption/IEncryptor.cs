﻿namespace BachorzLibrary.Common.Tools.Encryption
{
    public interface IEncryptor
    {
        string Encrypt(string text);
        string Decrypt(string encryptedText);
    }
}
