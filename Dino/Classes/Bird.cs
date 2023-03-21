// <copyright file="Bird.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dino.Classes
{
    using System.Drawing;

    /// <summary>
    /// Класс, отвечающий за птичку в игре.
    /// </summary>
    public class Bird
    {
        /// <summary>
        /// Переменная класса transform, которая будет хранить в себе размеры и позицию птички.
        /// </summary>
        public Transform Transform;
        private int frameCount = 0;
        private int animationCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bird"/> class.
        /// </summary>
        /// <param name="pos">Позиция.</param>
        /// <param name="size">Размер.</param>
        public Bird(PointF pos, Size size)
        {
            this.Transform = new Transform(pos, size);
        }

        /// <summary>
        /// Функция, которая отрисовывает птичку.
        /// </summary>
        /// <param name="g">Графика.</param>
        public void DrawSprite(Graphics g)
        {
            this.frameCount++;
            if (this.frameCount <= 10)
            {
                this.animationCount = 0;
            }
            else if (this.frameCount > 10 && this.frameCount <= 20)
            {
                this.animationCount = 1;
            }
            else if (this.frameCount > 20)
            {
                this.frameCount = 0;
            }

            g.DrawImage(GameController.Spritesheet, new Rectangle(new Point((int)this.Transform.Position.X, (int)this.Transform.Position.Y), new Size(this.Transform.Size.Width, this.Transform.Size.Height)), 264 + (92 * this.animationCount), 6, 83, 71, GraphicsUnit.Pixel);
        }
    }
}
