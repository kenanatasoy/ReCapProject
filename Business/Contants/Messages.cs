using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Contants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi gereklidir";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarActivelyRented = "Araba aktif olarak kiralanmış";
        public static string CarCountError = "Markanın araba sayısında limit aşılmamalı";
        public static string CarDescriptionError = "Aynı açıklamaya sahip ikinci bir araba eklenemez";
        
        public static string MaintenanceTime = "Sistem bakımda";
        public static string BrandLimitExceed = "Marka limiti aşılmamalı";
        public static string CarHaveNoImage = "Arabanın resmi yok";
        public static string ImageLimitExpiredForCar = "Resim limiti aşılamaz";
        //public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".GIF" };
        public static string ValidImageFileTypes = "Geçersiz resim uzantısı girdiniz. Jpg, jpeg, png veya gif uzantılarından biri makbuldür.";
        public static string InvalidImageExtension = "Geçersiz imaj-resim uzantısı";
        public static string CarImageMustBeExists = "Arabanın resmi olmalıdır";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "AccessToken oluşturuldu";
    }
}
