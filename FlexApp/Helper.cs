using System;
using System.Collections.Generic;
using System.Text;

namespace FlexApp
{
    public static class Helper
    {
        public static class Message
        {
            public const string LoginSuccessful = "Cool, you're in";
            public const string LoginFailedWrongUsernameOrPassword = "Nope";
            public const string LoginPrompt = "Need to be logged in annars nej";

            public const string RentalErrorSelectDaysActive = "hur länge kompis?";
            public const string RentalErrorPaymentFailed = "kom tillbaks 26e";
            public const string RentalPaymentSuccessful = "Netflex and pills";

            public const string SearchErrorIncorectSearchTerm = "Skriv Bättre";
            public const string SearchReturnedNoResultsLine1 = "Sorry dude, can't find it";
            public const string SearchReturnedNoResultsLine2 = "Maybe try spelling";
            public const string SearchBoxText = " Search...";

            public const string RegistrationErrorPasswordMismatch = "Passwards no match, no go";
            public const string RegistrationErrorUsernameAlreadyExists = "Username taken, try 89712893821972873";
            public const string RegistrationErrorEmailAlreadyRegistered = "Email already have an account, go get your password";
            public const string RegistrationErrorUsernamePasswordIncorect = "Username must be at least 3 characters, password 7, make it safe osv";
            public const string RegistrationErrorUsernameLength = "Username needs to be at least 4 characters, you laazy?";
            public const string AvatarFailedToLoad = "Fel format eller för ful, testa igen";

            public const string RentalSelectedActiveDays = "Days Active";
            public const string RentalSelectActiveDaysError = "Choose how many days you want the movie active.";

            public const string TrailerErrorLoading = "Failed to load trailer";

        }

        public static class Image
        {
            public const string DefaultAvatarURL = "https://ets2.lt/wp-content/uploads/profile_builder/avatars/userID_18932_originalAvatar_Ugly-People-Pics-5-570x855.jpg";
            public const string BjornAvatarURL = "https://scontent.fgse2-1.fna.fbcdn.net/v/t1.0-9/72315_639451312777618_666643236_n.jpg?_nc_cat=111&ccb=2&_nc_sid=09cbfe&_nc_ohc=dOHOhw779EIAX91ov7k&_nc_ht=scontent.fgse2-1.fna&oh=5d8079e20e85ede5b1610439c8c96061&oe=5FE5AE24";
        }

        public static class TmdbApi
        {
            public const string APIKey = "0c810d916d7339ead3ad31c25f441a26";
        }


        public static class ImdbAPI
        {
            public const string APIKeyJack = "k_a4fdj6tm";
            public const string APIKeyRobin = "k_6f3w3pvw";
        }

    }
}
