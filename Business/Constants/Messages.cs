using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarInvalid = "Arabanın ismi minimum 2 karakter, günlük fiyatı en az 1 birim olmalıdır.";
        public static string DailyPriceInvalid = "Arabanın günlük kirası en az 1 birim olmalıdır.";
        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarsListed = "Arabalar listelendi.";

        public static string MaintenanceTime = "Bakım zamanı.";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorsListed = "Renkler listelendi.";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandsListed = "Markalar listelendi.";
    }
}
