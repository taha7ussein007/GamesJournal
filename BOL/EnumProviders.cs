using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public static class userTypesEn
    {
        public const int ChiefEditor = 1;
        public const int Editor = 2;
        public const int User = 3;

        public const string ChiefEditorStr = "Chief Editor";
        public const string EditorStr = "Editor";
        public const string UserStr = "User";

        public static int GetEquivelant(string typeStr)
        {
            switch(typeStr)
            {
                case ChiefEditorStr:
                    return ChiefEditor;
                case EditorStr:
                    return Editor;
                case UserStr:
                    return User;
                default:
                    return 0;
            }
        }
        public static string GetEquivelant(int typeId)
        {
            switch (typeId)
            {
                case ChiefEditor:
                    return ChiefEditorStr;
                case Editor:
                    return EditorStr;
                case User:
                    return UserStr;
                default:
                    return "";
            }
        }
    }
    public static class articleTypeEn
    {
        public const int TechnicalReview = 1;
        public const int UserReview = 2;
        public const int Advertisement = 3;
        public const int Other = 4;

        public const string TechnicalReviewStr = "Technical Review";
        public const string UserReviewStr = "User Review";
        public const string AdvertisementStr = "Advertisement";
        public const string OtherStr = "Other";

        public static int GetEquivelant(string typeStr)
        {
            switch (typeStr)
            {
                case TechnicalReviewStr:
                    return TechnicalReview;
                case UserReviewStr:
                    return UserReview;
                case AdvertisementStr:
                    return Advertisement;
                case OtherStr:
                    return Other;
                default:
                    return 0;
            }
        }
        public static string GetEquivelant(int typeId)
        {
            switch (typeId)
            {
                case TechnicalReview:
                    return TechnicalReviewStr;
                case UserReview:
                    return UserReviewStr;
                case Advertisement:
                    return AdvertisementStr;
                case Other:
                    return OtherStr;
                default:
                    return "";
            }
        }
    }
    public static class articleStateEn
    {
        public const int Pending = 1;
        public const int Approved = 2;
        public const int Refused = 3;
        public const int Banned = 4;

        public const string PendingStr = "Pending";
        public const string ApprovedStr = "Approved";
        public const string RefusedStr = "Refused";
        public const string BannedStr = "Banned";

        public static int GetEquivelant(string stateStr)
        {
            switch (stateStr)
            {
                case PendingStr:
                    return Pending;
                case ApprovedStr:
                    return Approved;
                case RefusedStr:
                    return Refused;
                case BannedStr:
                    return Banned;
                default:
                    return 0;
            }
        }
        public static string GetEquivelant(int stateId)
        {
            switch (stateId)
            {
                case Pending:
                    return PendingStr;
                case Approved:
                    return ApprovedStr;
                case Refused:
                    return RefusedStr;
                case Banned:
                    return BannedStr;
                default:
                    return "";
            }
        }
    }
}
