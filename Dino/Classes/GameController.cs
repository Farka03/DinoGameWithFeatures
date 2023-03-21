// <copyright file="GameController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dino.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    ///
    /// </summary>
    public static class GameController
    {
        public static Image Spritesheet;
        public static List<Road> Roads;
        public static List<Cactus> Cactuses;
        public static List<Bird> Birds;

        public static int DangerSpawn = 10;
        public static int CountDangerSpawn = 0;

        public static void Init()
        {
            Roads = new List<Road>();
            Birds = new List<Bird>();
            Cactuses = new List<Cactus>();
            Spritesheet = Properties.Resources.sprite;
            GenerateRoad();
        }

        public static void MoveMap()
        {
            for (int i = 0; i < Roads.Count; i++)
            {
                Roads[i].Transform.Position.X -= 4;
                if (Roads[i].Transform.Position.X + Roads[i].Transform.Size.Width < 0)
                {
                    Roads.RemoveAt(i);
                    GetNewRoad();
                }
            }

            for (int i = 0; i < Cactuses.Count; i++)
            {
                Cactuses[i].Transform.Position.X -= 4;
                if (Cactuses[i].Transform.Position.X + Cactuses[i].Transform.Size.Width < 0)
                {
                    Cactuses.RemoveAt(i);
                }
            }

            for (int i = 0; i < Birds.Count; i++)
            {
                Birds[i].Transform.Position.X -= 4;
                if (Birds[i].Transform.Position.X + Birds[i].Transform.Size.Width < 0)
                {
                    Birds.RemoveAt(i);
                }
            }
        }

        public static void GetNewRoad()
        {
            Road road = new Road(new PointF(0 + (100 * 9), 200), new Size(100, 17));
            Roads.Add(road);
            CountDangerSpawn++;

            if (CountDangerSpawn >= DangerSpawn)
            {
                Random r = new Random();
                DangerSpawn = r.Next(5, 9);
                CountDangerSpawn = 0;
                int obj = r.Next(0, 2);
                switch (obj)
                {
                    case 0:
                        Cactus cactus = new Cactus(new PointF(0 + (100 * 9), 150), new Size(50, 50));
                        Cactuses.Add(cactus);
                        break;
                    case 1:
                        Bird bird = new Bird(new PointF(0 + (100 * 9), 110), new Size(50, 50));
                        Birds.Add(bird);
                        break;
                }
            }
        }

        public static void GenerateRoad()
        {
            for (int i = 0; i < 10; i++)
            {
                Road road = new Road(new PointF(0 + (100 * i), 200), new Size(100, 17));
                Roads.Add(road);
                CountDangerSpawn++;
            }
        }

        public static void DrawObjets(Graphics g)
        {
            for (int i = 0; i < Roads.Count; i++)
            {
                Roads[i].DrawSprite(g);
            }

            for (int i = 0; i < Cactuses.Count; i++)
            {
                Cactuses[i].DrawSprite(g);
            }

            for (int i = 0; i < Birds.Count; i++)
            {
                Birds[i].DrawSprite(g);
            }
        }
    }
}
