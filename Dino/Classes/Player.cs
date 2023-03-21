// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dino.Classes
{
    using System.Drawing;

    public class Player
    {
        public Physics physics;
        public int framesCount = 0;
        public int animationCount = 0;
        public int Score = 0;

        public Player(PointF position, Size size)
        {
            this.physics = new Physics(position, size);
            this.framesCount = 0;
            this.Score = 0;
        }

        public void DrawSprite(Graphics g)
        {
            if (this.physics.IsCrouching)
            {
                this.DrawNeededSprite(g, 1870, 40, 109, 51, 118, 1.35f);
            }
            else
            {
                this.DrawNeededSprite(g, 1518, 0, 79, 91, 88, 1);
            }
        }

        public void DrawNeededSprite(Graphics g, int srcX, int srcY, int width, int height, int delta, float multiplier)
        {
            this.framesCount++;
            if (this.framesCount <= 10)
            {
                this.animationCount = 0;
            }
            else if (this.framesCount > 10 && this.framesCount <= 20)
            {
                this.animationCount = 1;
            }
            else if (this.framesCount > 20)
            {
                this.framesCount = 0;
            }

            g.DrawImage(GameController.Spritesheet, new Rectangle(new Point((int)this.physics.transform.Position.X, (int)this.physics.transform.Position.Y), new Size((int)(this.physics.transform.Size.Width * multiplier), this.physics.transform.Size.Height)), srcX + (delta * this.animationCount), srcY, width, height, GraphicsUnit.Pixel);
        }
    }
}
