using UnityEngine;

namespace Game
{
    public static class GameConstants 
    {
        private const string _device01 = "BE648950-B93C-4C02-8AB2-8BBB6B18CAC4"; //iPhone XR
        private const string _device02 = "2E11A658-DED6-448A-A739-2A4DB682834B";

        private const string _device03 = "0B8D5C16-1BE5-4066-810D-EDE967FDD13E"; //iPhone 6s
        private const string _device04 = "D5E577E6-2959-46F3-9E15-616BC6A33466";

        private const string _device05 = "FE1841DB-22D6-5C6A-9A53-9B5FF8AFE237"; //mac book pro 2015

        private const string _device06 = "9AA74ED8-EAE8-4350-9BE5-DA64D5347C89"; //iPad
        private const string _device07 = "D5E577E6-2959-46F3-9E15-616BC6A33466";

        private static string[] _developerDevicesID = new string[] { _device01, _device02, _device03, _device04, _device05, _device06, _device07 };

        private static string _cashIconString = "<sprite=\"CashIcon\" index=0>";
        private static string _adsIconString = "<sprite=\"AdsIcon\" index=0>";
        private static string _noInternetIconString = "<sprite=\"NoInternetIcon\" index=0>";
        private static string _assetStoreIconString = "<sprite=\"AssetStoreIcon\" index=0>";

        public static string CashIconString => _cashIconString;
        public static string AdsIconString => _adsIconString;
        public static string NoInternetIconString => _noInternetIconString;
        public static string AssetStoreIconString => _assetStoreIconString;

        public static bool IsDeveloperDevice()
        {
            if (Debug.isDebugBuild)
                return true;

            string deviceID = SystemInfo.deviceUniqueIdentifier;
            foreach (string device in _developerDevicesID)
            {
                if (device == deviceID)
                    return true;
            }
            return false;
        }

        public static bool IsDeveloperIPad()
        {
            bool isDeveloperDevice = IsDeveloperDevice();

            var identifier = SystemInfo.deviceModel;
            bool isiPad = identifier.StartsWith("iPad");

            return isDeveloperDevice && isiPad;
        }
    }
}