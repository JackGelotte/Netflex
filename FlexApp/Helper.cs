using System;
using System.Collections.Generic;
using System.Text;

namespace FlexApp
{
    public static class Helper
    {
        public static class Message
        {
            public static readonly string LoginSuccessful = "Cool";
            public static readonly string LoginFailedWrongUsernameOrPassword = "Nope";
            public static readonly string LoginPrompt = "Need to be logged in annars nej";

            public static readonly string RentalErrorSelectDaysActive = "hur länge kompis?";
            public static readonly string RentalErrorPaymentFailed = "kom tillbaks 26e";
            public static readonly string RentalPaymentSuccessful = "Netflex and pills"; 

            public static readonly string SearchErrorIncorectSearchTerm = "Skriv Bättre";
            public static readonly string SearchReturnedNoResults = "Sorry dude";

            public static readonly string RegistrationErrorPasswordMismatch = "Passwards no match, no go";
            public static readonly string RegistrationErrorUsernameAlreadyExists = "Username taken, try 89712893821972873";
            public static readonly string RegistrationErrorEmailAlreadyRegistered = "Email already have an account, go get your password";
            public static readonly string RegistrationErrorUsernamePasswordIncorect = "Username must be at least 3 characters, password 7, make it safe osv";
            public static readonly string RentalSelectedActiveDays = "Days Active";
            public static readonly string RentalSelectActiveDaysError = "Choose how many days you want the movie active.";
        }

        public static class Image
        {
            public static readonly string DefaultAvatarURL = "https://ets2.lt/wp-content/uploads/profile_builder/avatars/userID_18932_originalAvatar_Ugly-People-Pics-5-570x855.jpg";
        }

        public static class CsvFile
        {

        }


    }
}
