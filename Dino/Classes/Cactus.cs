// <copyright file="Cactus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dino.Classes
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Класс, отвечающий за кактус в игре.
    /// </summary>
    public class Cactus
    {
        /// <summary>
        /// Переменная класса transform, которая будет хранить в себе размеры и позицию птички.
        /// </summary>
        public Transform Transform;
        private int srcX = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cactus"/> class.
        /// </summary>
        /// <param name="pos">Позиция.</param>
        /// <param name="size">Размер.</param>
        public Cactus(PointF pos, Size size)
        {
            this.Transform = new Transform(pos, size);
            this.ChooseRandomPic();
        }

        /// <summary>
        /// Функция, выбирающая рандомно картинку кактуса.
        /// </summary>
        public void ChooseRandomPic()
        {
            Random r = new Random();
            int rnd = r.Next(0, 4);
            switch (rnd)
            {
                case 0:
                    this.srcX = 754;
                    break;
                case 1:
                    this.srcX = 804;
                    break;
                case 2:
                    this.srcX = 704;
                    break;
                case 3:
                    this.srcX = 654;
                    break;
            }
        }

        /// <summary>
        /// Функция, которая отрисовывает кактус.
        /// </summary>
        /// <param name="g">Графика.</param>
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(GameController.Spritesheet, new Rectangle(new Point((int)this.Transform.Position.X, (int)this.Transform.Position.Y), new Size(this.Transform.Size.Width, this.Transform.Size.Height)), this.srcX, 0, 48, 100, GraphicsUnit.Pixel);
        }
    }
}
