using System.Security.Cryptography;
using System.Text;

namespace CourseWork.User
{
    public class PasswordService
    {
        private DataBase.DataBase Db { get; }

        public PasswordService(DataBase.DataBase dataBase)
        {
            Db = dataBase;
        }

        public bool ComparePasswords(User user, string password)
        {
            return Driver(user, password);
        }

        private bool Driver(User user, string password)
        {
            var givenBytePassword = CreateBytePassword(password);
            var storedPassword = GetStoredPassword(user);
            var storedBytePassword = CreateBytePassword(storedPassword);

            return Compare(givenBytePassword, storedBytePassword);
        }

        private static bool Compare(byte[] password, byte[] storedPassword)
        {
            if (password.Length != storedPassword.Length)
            {
                return false;
            }
            
            var i = 0;
            while ((i < storedPassword.Length) && (storedPassword[i] == password[i]))
            {
                i += 1;
            }
            
            return i == storedPassword.Length;
        }

        private string GetStoredPassword(User user)
        {
            var users = Db.Users;

            foreach (var u in users)
            {
                if (u.Equals(user)) //todo cwitch it up 
                {
                    return u.Password;
                }
            }

            return "";
        }

        private static byte[] CreateBytePassword(string password)
        {
            var bytePassword = Encoding.ASCII.GetBytes(password);
            return new MD5CryptoServiceProvider().ComputeHash(bytePassword);
        }

        private static string ConvertToString(byte[] arrInput)
        {
            int i;
            var sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }

            return sOutput.ToString();
        } // try: convert saved pass to string and the create byte password to store it properly, not like a string - ? 
    }
}