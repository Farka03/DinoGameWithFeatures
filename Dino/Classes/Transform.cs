// <copyright file="Transform.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dino.Classes
{
    using System.Drawing;

    /// <summary>
    /// Класс который хранит размеры и позицию передаваемого объекта.
    /// </summary>
    public class Transform
    {
        /// <summary>
        /// Перменная, отвечающая за позицию объекта.
        /// </summary>
        public PointF Position;

        /// <summary>
        /// Перменная, отвечающая за размер объекта.
        /// </summary>
        public Size Size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> class.
        /// </summary>
        /// <param name="pos">Позиция.</param>
        /// <param name="size">Размер.</param>
        public Transform(PointF pos, Size size)
        {
            this.Position = pos;
            this.Size = size;
        }
    }
}
