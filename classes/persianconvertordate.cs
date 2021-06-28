using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
namespace mycms
{
    public static class persianconvertordate
    {
      private static string  m, d; 
        private static string yy;
        public static string toshamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");
        }

        public static string toshamsisrc(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            string sal = Convert.ToString(pc.GetYear(value));
           int sall = pc.GetYear(value);
            string mah = Convert.ToString(pc.GetMonth(value));
            string roz = Convert.ToString(pc.GetDayOfMonth(value));
         
            switch (sall)
            {
                case 1399:
                    yy = "1399";
                    break;

                case 1400:
                    yy = "1400";
                    break;
                case 1401:
                    yy = "1401";
                    break;
                case 1402:
                    yy = "1402";
                    break;
                case 1403:
                    yy = "1403";
                    break;
                case 1404:
                    yy = "1404";
                    break;
                case 1405:
                    yy = "1405";
                    break;
            }
          switch (mah)
            {
                case "1":
                    m = "فروردین";
                    break;
                case "2":
                    m = "اردیبهشت";
                    break;
                case "3":
                    m = "خرداد";
                    break;
                case "4":
                    m = "تیر";
                    break;
                case "5":
                    m = "مرداد";
                    break;
                case "6":
                    m = "شهریور";
                    break;
                case "7":
                    m = "مهر";
                    break;
                case "8":
                    m = "ابان";
                    break;
                case "9":
                    m = "اذر";
                    break;
                case "10":
                    m = "دی";
                    break;
                case "11":
                    m = "بهمن";
                    break;
                case "12":
                    m = "اسفند";
                    break;
                   

            }
            switch (roz)
              {
                case "1":
                    d = "1";
                    break;
                case "2":
                    d = "2";
                    break;
                case "3":
                    d = "3";
                    break;
                case "4":
                    d = "4";
                    break;
                case "5":
                    d = "5";
                    break;
                case "6":
                    d = "6";
                    break;
                case "7":
                    d = "7";
                    break;
                case "8":
                    d = "8";
                    break;
                case "9":
                    d = "9";
                    break;
                case "10":
                    d = "10";
                    break;
                case "11":
                    d = "11";
                    break;
                case "12":
                    d = "12";
                    break;
                case "13":
                    d = "13";
                    break;
                case "14":
                    d = "14";
                    break;
                case "15":
                    d = "15";
                    break;
                case "16":
                    d = "16";
                    break;
                case "17":
                    d = "17";
                    break;
                case "18":
                    d = "18";
                    break;
                case "19":
                    d = "19";
                    break;
                case "20":
                    d = "20";
                    break;
                case "21":
                    d = "21";
                    break;
                case "22":
                    d = "22";
                    break;
                case "23":
                    d = "23";
                    break;
                case "24":
                    d = "24";
                    break;
                case "25":
                    d = "25";
                    break;
                case "26":
                    d = "26";
                    break;
                case "27":
                    d = "27";
                    break;
                case "28":
                    d = "28";
                    break;
                case "29":
                    d = "29";
                    break;
                case "30":
                    d = "30";
                    break;
                case "31":
                    d = "31";
                    break;
                   
              }

         

            return Convert.ToString("امروز"+ d + " امین " + "روز از  " + m + "ماه  " + "سال  " + yy + " است");
        }
    }
}