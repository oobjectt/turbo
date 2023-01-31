using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Turbo.Core.Game.Rooms.PathFinder.Constants;

namespace Turbo.Core.Game
{
    public class DefaultSettings
    {
        public static int GameCycleMs = 500;
        public static int StoreCycleMs = 10000;
        public static HeuristicFormula PathingFormula = HeuristicFormula.Manhattan;
        public static bool PathingAllowsDiagonals = true;
        public static double MaximumStepHeight = 2.0;
        public static double MaximumFurnitureHeight = 40.0;
        public static int TileHeightDefault = 32767;
        public static int TileHeightMultiplier = 256;
        public static double MinimumStackHeight = 0.001;
        public static int FurniPerFragment = 100;
        public static int BadgesPerFragment = 100;
        public static int MaxActiveBadges = 5;
        public static int DiceCycles = 4;
        public static int WiredFurniSelectionLimit = 5;
        public static string Delimiter = ";";
        public static int MaximumChatDistance = 50;
        public static Regex RoomNameRegex = new Regex("^(?=.*[A-Z,a-z,0-9]).{3,60}$");
        public static Regex RoomDescriptionRegex = new Regex("^(?=.*[A-Z,a-z,0-9]).{1,60}$");
        public static Regex RoomPasswordRegex = new Regex("^(?=.*[A-Z,a-z,0-9]).{1,60}$");
        public static int MaximumUsersPerRoom = 100;
        public static int RoomDisposeTicks = 120;
        public static int RoomTryDisposeTicks = 1200;
    }
}