using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Untils
{
    public class GlobalConstant
    {

        #region 游戏边界坐标

        public const float GAME_MAX_X = 6.6f;

        public const float GAME_MIN_X = -6.6f;

        public const float GAME_MAX_Y = 2.24f;

        public const float GAME_MIN_Y = -3.35f;

        #endregion

        #region 金块

        public const int GOLD_MIN_COUNT = 10;

        public const int GOLD_MAX_SCORE = 500;

        public const int GOLD_MIN_SCORE = 50;

        #endregion
    }
}
