using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takas.Common.SystemConstants
{
    public class SystemConstannts
    {
        public enum ERROR_CODES
        {
            SUCCESS = 1,
            SYSTEMERROR = 2,
            NOTFOUND = 3

        }


        public static Dictionary<int, string> ERROR_MESSAGE = new Dictionary<int, string>
        {
            {1,"İşlem başarılı" },
            {2,"Sistem Hatası" },
            {3,"Kullanıcı Bulunamadı" }


        };
        public enum Brands
        {
            Marka1=1,
            Marka2=2,
            Marka3=3
        }
        public enum Situation
        {
            BEKLEMEDE=1,
            ONAYLANDI=2,
            AKTİF=3,
            PASİF=4,
            ENGELLENDİ=5,
            SOCİALUSER = 6
        }
        public enum SOCIAL_TYPE : byte
        {
            FACEBOOK = 1

        }
        public const string SmtpCredentialUserName = "wissen502@outlook.com";
        public const string SmtpCredentialPassword = "Wisen502!!";

        public static Dictionary<int, string> Cities = new Dictionary<int, string>()
        {
            {1,"Adana"},
            {2,"Adıyaman"},
            {3,"Afyon"},
            {4,"Ağrı"},
            {5,"Amasya"},
            {6,"Ankara" },
            {7,"Antalya" },
            {8,"Artvin" },
            {9,"Aydın" },
            {10,"Balıkesir" },
            {11,"Bileck" },
            {12,"Bingöl" },
            {13,"Bitlis" },
            {14,"Bolu" },
            {15,"Burdur" },
            {16,"Bursa" },
            {17,"Çanakkale" },
            {18,"Çankırı" },
            {19,"Çorum" },
            {20,"Denizli" },
            {21,"Diyarbakır" },
            {22,"Edirne" },
            {23,"Elazığ" },
            {24,"Erzincan" },
            {25,"Erzurum" },
            {26,"Eskişehir" },
            {27,"Gaziantep" },
            {28,"Giresun" },
            {29,"Gümüşhane" },
            {30,"Hakkari" },
            {31,"Hatay" },
            {32,"Isparta" },
            {33,"İçel" },
            {34,"İstanbul" },
            {35,"İzmir" },
            {36,"Kars" },
            {37,"Kastamonu" },
            {38,"Kayseri" },
            {39,"Kırklareli" },
            {40,"Kırşehir" },
            {41,"Kocaeli" },
            {42,"Konya" },
            {43,"Kütahya" },
            {44,"Malatya" },
            {45,"Manisa" },
            {46,"Kahraman Maraş" },
            {47,"Mardin" },
            {48,"Muğla" },
            {49,"Muş" },
            {50,"Nevşehir" },
            {51,"Niğde" },
            {52,"Ordu" },
                 {53,"Rize" },
            {54,"Sakarya" },
            {55,"Samsun" },
            {56,"Siirt" },
            {57,"Sinop" },
            {58,"Sivas" },
            {59,"Tekirdağ" },
            {60,"Tokat" },
            {61,"Trabzon" },
            {62,"Tunceli" },
            {63,"Şanlıurfa" },
            {64,"Uşak" },
            {65,"Van" },
             {66,"Yozgat" },
            {67,"Zonguldak" },
            {68,"Aksaray" },
            {69,"Bayburt" },
            {70,"Karaman" },
            {71,"Kırıkkale" },
            {72,"Batman" },
            {73,"Şırnak" },
            {74,"Bartın" },
            {75,"Ardahan" },
            {76,"Iğdır" },
            {77,"Yalova" },
            {78,"Karabük" },
                 {79,"Kilis" },
            {80,"Osmaniye" },
            {81,"Düzce" }
        };
    }
}
