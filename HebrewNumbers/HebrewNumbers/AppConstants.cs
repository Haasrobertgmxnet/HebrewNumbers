using Xamarin.Forms;

namespace HebrewNumbers
{
    public static class AppConstants
    {
        public static string AppId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// These Ids are test Ids from https://developers.google.com/admob/android/test-ads
        /// </summary>
        /// <value>The banner identifier.</value>
        public static string BannerId
        {

            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-4182244404624975~3142526058";
                    default:
                        return "ca-app-pub-4182244404624975~3142526058";
                }
            }
        }
    }
}


