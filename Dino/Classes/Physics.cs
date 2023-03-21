// <copyright file="Physics.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dino.Classes
{
    using System;
    using System.Drawing;

    public class Physics
    {
        public Transform transform;
        private float gravity;
        private float a;

        public bool IsJumping;
        public bool IsCrouching;

        public Physics(PointF position, Size size)
        {
            this.transform = new Transform(position, size);
            this.gravity = 0;
            this.a = 0.4f;
            this.IsJumping = false;
            this.IsCrouching = false;
        }

        public void ApplyPhysics()
        {
            this.CalculatePhysics();
        }

        public void CalculatePhysics()
        {
            if (this.transform.Position.Y < 150 || this.IsJumping)
            {
                this.transform.Position.Y += this.gravity;
                this.gravity += a;
            }

            if (this.transform.Position.Y > 150)
            {
                this.IsJumping = false;
            }
        }

        public bool Collide()
        {
            for (int i = 0; i < GameController.Cactuses.Count; i++)
            {
                var cactus = GameController.Cactuses[i];
                PointF delta = default(PointF);
                delta.X = (this.transform.Position.X + (this.transform.Size.Width / 2)) - (cactus.Transform.Position.X + (cactus.Transform.Size.Width / 2));
                delta.Y = (this.transform.Position.Y + (this.transform.Size.Height / 2)) - (cactus.Transform.Position.Y + (cactus.Transform.Size.Height / 2));
                if (Math.Abs(delta.X) <= (this.transform.Size.Width / 2) + (cactus.Transform.Size.Width / 2))
                {
                    if (Math.Abs(delta.Y) <= (this.transform.Size.Height / 2) + (cactus.Transform.Size.Height / 2))
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < GameController.Birds.Count; i++)
            {
                var bird = GameController.Birds[i];
                PointF delta = default(PointF);
                delta.X = (this.transform.Position.X + (this.transform.Size.Width / 2)) - (bird.Transform.Position.X + (bird.Transform.Size.Width / 2));
                delta.Y = (this.transform.Position.Y + (this.transform.Size.Height / 2)) - (bird.Transform.Position.Y + (bird.Transform.Size.Height / 2));
                if (Math.Abs(delta.X) <= (this.transform.Size.Width / 2) + (bird.Transform.Size.Width / 2))
                {
                    if (Math.Abs(delta.Y) <= (this.transform.Size.Height / 2) + (bird.Transform.Size.Height / 2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void AddForce()
        {
            if (!this.IsJumping)
            {
                this.IsJumping = true;
                this.gravity = -10;
            }
        }
    }
}
