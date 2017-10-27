﻿using SwinGameSDK;

namespace MyGame
{
    public class Input
    {
        public int count;
        public bool released;
        public Vector2D vStart, vCurrent, vEnd;

        public Input()
        {
            released = true;
            count = 0;
            vStart = new Vector2D();
        }

        public Vector2D GetInput()
        {
            if (SwinGame.MouseDown(MouseButton.LeftButton))
            {
                vCurrent = new Vector2D();
                vCurrent.x = SwinGame.MousePositionAsVector().X;
                vCurrent.y = SwinGame.MousePositionAsVector().Y;
                released = false;

                if (count == 0)
                    vStart = vCurrent;
                count += 1;
                return vCurrent;
            }

            if (!released)
                if (SwinGame.MouseUp(MouseButton.LeftButton))
                {
                    vEnd = new Vector2D();
                    vEnd.x = SwinGame.MousePositionAsVector().X;
                    vEnd.y = SwinGame.MousePositionAsVector().Y;
                    released = true;
                    count = 0;
                    return vEnd;
                }
            return null;
        }
    }
}