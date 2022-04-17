using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public static class Messages
    {
        public static class User
        {
            public static string UserNotFound => "Kullanıcı bulunamadı";
            public static string EmailAlreadyExists => "Email Sistemde kayıtlı lütfen farklı bir email adresi giriniz";

            public static string PasswordError => "Kullanıcı Adı veya Şifre Hatalı";
            public static string PasswordNotMatch => "Şifreler uyuşmuyor";

        }

        public static class Block
        {
            public static string BlockNameExists => "Blok Adı Zaten Kullanılıyor.";
            public static string BlockNotFound => "Blok bulunamadı";
        }
    }
}
