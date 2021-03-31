using NLog;
using System.Security.Cryptography;
using System.Text;
using WpfSMSApp.Model;

namespace WpfSMSApp
{
    public class Commons
    {
        //NLog 정적 인스턴스 생성
        public static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        // 로그인한 유저 정보
        public static User LOGINED_USER;

        //암호화 해줘서 관리자도 볼 수 없게 하는 것이다.
        public static string GetMd5Hash(MD5 md5Hash, string plainStr)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(plainStr));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));//모든 글자를 16진수로 바꾼다.
            }

            return builder.ToString();
        }
    }
}
