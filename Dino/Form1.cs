// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dino
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Dino.Classes;

    public partial class Form1 : Form
    {
        private Player player;
        private Timer mainTimer;

        public Form1()
        {
            this.InitializeComponent();

            this.Width = 700;
            this.Height = 300;
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(this.DrawGame);
            this.KeyUp += new KeyEventHandler(this.OnKeyboardUp);
            this.KeyDown += new KeyEventHandler(this.OnKeyboardDown);
            this.mainTimer = new Timer();
            this.mainTimer.Interval = 10;
            this.mainTimer.Tick += new EventHandler(this.Update);

            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.ShowDialog();

            this.Init();
        }

        /// <summary>
        /// Функция запускает игру. Создает персонажа, запускает таймер.
        /// </summary>
        public void Init()
        {
            GameController.Init();
            this.player = new Player(new PointF(50, 149), new Size(50, 50));
            this.mainTimer.Start();
            this.Invalidate();
        }

        public void Update(object sender , EventArgs e)
        {
            this.player.Score++;
            this.Text = "Dino - Score: " + this.player.Score;
            if (this.player.physics.Collide())
            {
                //DialogResult result = MessageBox.Show("Ваш счет: " + this.player.Score + "\n" + "Попытаемя ещё?", "Game Over",
                //    MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                //    MessageBoxDefaultButton.Button1,
                //    MessageBoxOptions.DefaultDesktopOnly);

                //if (result == DialogResult.No)
                //{
                //    Application.Exit();
                //}

                //this.Show();
                this.Init();
            }

            this.player.physics.ApplyPhysics();
            GameController.MoveMap();
            this.Invalidate();
        }

        private void OnKeyboardDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (!this.player.physics.IsJumping)
                    {
                        this.player.physics.IsCrouching = true;
                        this.player.physics.IsJumping = false;
                        this.player.physics.transform.Size.Height = 25;
                        this.player.physics.transform.Position.Y = 174;
                    }

                    break;
            }
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!this.player.physics.IsCrouching)
                    {
                        this.player.physics.IsCrouching = false;
                        this.player.physics.AddForce();
                    }

                    break;
                case Keys.Down:
                    this.player.physics.IsCrouching = false;
                    this.player.physics.transform.Size.Height = 50;
                    this.player.physics.transform.Position.Y = 150.2f;
                    break;
            }
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.player.DrawSprite(g);
            GameController.DrawObjets(g);
        }
    }
}
