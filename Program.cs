namespace SharpKingdoms
{
    using Love;
    using Sharp_Kingdoms;
    using System;

    public class Program : Scene
    {
        Global g = Global.Instance;
        float nextTime;
        float minDt;

        static void Main(string[] args)
        {
            Boot.Init();
            Boot.Run(new Program());
        }

        public override void Draw()
        {
            g.Terrain.DrawTerrain();
            Graphics.Draw(g.TerrainImage, g.Iso.IsoToScreenX(g.LocalX, g.LocalY) - g.ViewX, g.Iso.IsoToScreenY(g.LocalX, g.LocalY) - g.ViewY);

            Graphics.Print("\n LocalX: " + g.LocalX +
                           "\n LocalY: " + g.LocalY +
                           "\n ViewX: " + g.ViewX +
                           "\n ViewY: " + g.ViewY +
                           "\n MouseX: " + g.MouseX +
                           "\n MouseY: " + g.MouseY +
                           "\n Current FPS: " + Timer.GetFPS()
                            );

            // Limit the FPS to 60
            var currentTime = Timer.GetTime();
            if (nextTime <= currentTime)
            {
                nextTime = currentTime;
                return;
            }
            Timer.Sleep(nextTime - currentTime);
        }

        public override void Load()
        {
            minDt = 1 / 60;
            nextTime = Timer.GetTime();
            WindowSettings settings = new WindowSettings();
            settings.vsync = true;
            Love.Window.SetMode(800, 600, settings);
            Window.SetTitle("Sharp Empires");
            g.TerrainImage = Graphics.NewImage(@"..\..\..\Assets\Tiles\collection148.png");
            g.ViewX = 0;
            g.ViewY = 0;
            g.MouseX = 0;
            g.MouseY = 0;
            g.ScaleX = 1;
            g.ScaleY = 1;

            g.Iso = new Isometric();
            // It will generate the terrain
            g.Terrain = new Terrain();
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            nextTime += minDt;
            if (Keyboard.IsDown(KeyConstant.Up) || Keyboard.IsDown(KeyConstant.W))
            {
                g.ViewY -= 5;
            }
            if (Keyboard.IsDown(KeyConstant.Down) || Keyboard.IsDown(KeyConstant.S))
            {
                g.ViewY += 5;
            }
            if (Keyboard.IsDown(KeyConstant.Left) || Keyboard.IsDown(KeyConstant.A))
            {
                g.ViewX -= 5;
            }
            if (Keyboard.IsDown(KeyConstant.Right) || Keyboard.IsDown(KeyConstant.D))
            {
                g.ViewX += 5;
            }

            //if (Keyboard.IsDown(KeyConstant.Up) || Keyboard.IsDown(KeyConstant.Down) || Keyboard.IsDown(KeyConstant.Left) || Keyboard.IsDown(KeyConstant.Right)
            //     || Keyboard.IsDown(KeyConstant.W) || Keyboard.IsDown(KeyConstant.S) || Keyboard.IsDown(KeyConstant.D) || Keyboard.IsDown(KeyConstant.A))
            //{
            //    g.Terrain.UpdateTerrain();
            //}

            g.MouseX = Mouse.GetPosition().X;
            g.MouseY = Mouse.GetPosition().Y;

            g.LocalX = Round(g.Iso.ScreenToIsoX(g.MouseX + g.ViewX, g.MouseY + g.ViewY), 0);
            g.LocalY = Round(g.Iso.ScreenToIsoY(g.MouseX + g.ViewX, g.MouseY + g.ViewY), 0);
        }

        public override void WheelMoved(int x, int y)
        {
            base.WheelMoved(x, y);
            if (y > 0 && g.ScaleX < 1)
            {
                g.ScaleX += 0.05f;
                g.ScaleY += 0.5f;
            }
            if (y < 0 && g.ScaleY > 0.2)
            {
                g.ScaleX -= 0.05f;
                g.ScaleY -= 0.05f;
            }
        }

        private float Round(double n, int deci)
        {
            deci = (int)Math.Pow(10, deci);
            return (float)(Math.Floor(n * deci + 0.5) / deci);
        }
    }
}