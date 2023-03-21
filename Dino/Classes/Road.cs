// <copyright file="Road.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dino.Classes
{
    using System.Drawing;

    /// <summary>
    /// Класс, отвечающий за дорогу в игре.
    /// </summary>
    public class Road
    {
        /// <summary>
        /// Переменная класса transform, которая будет хранить в себе размеры и позицию дороги.
        /// </summary>
        public Transform Transform;

        /// <summary>
        /// Initializes a new instance of the <see cref="Road"/> class.
        /// </summary>
        /// <param name="pos">Позиция.</param>
        /// <param name="size">Размер.</param>
        public Road(PointF pos, Size size)
        {
            this.Transform = new Transform(pos, size);
        }

        /// <summary>
        /// Функция, которая отрисовывает нашу дорогу.
        /// </summary>
        /// <param name="g">Графика.</param>
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(GameController.Spritesheet, new Rectangle(new Point((int)this.Transform.Position.X, (int)this.Transform.Position.Y), new Size(this.Transform.Size.Width, this.Transform.Size.Height)), 2300, 112, 100, 17, GraphicsUnit.Pixel);
        }
    }
}
