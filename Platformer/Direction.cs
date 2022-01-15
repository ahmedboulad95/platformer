using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Platformer
{
    class Direction
    {
        public static Vector2 Up = new Vector2(0, 1);
        public static Vector2 Down = new Vector2(0, -1);
        public static Vector2 Left = new Vector2(-1, 0);
        public static Vector2 Right = new Vector2(1, 0);
        public static Vector2 UpLeft = new Vector2(-0.707f, 0.707f);
        public static Vector2 UpRight = new Vector2(0.707f, 0.707f);
        public static Vector2 DownLeft = new Vector2(-0.707f, -0.707f);
        public static Vector2 DownRight = new Vector2(0.707f, -0.707f);
    }
}
