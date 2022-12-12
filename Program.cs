namespace SharpKingdoms
{
    using Love;
    using Sharp_Kingdoms;
    using System;

    public class Program : Scene
    {
        Global g = Global.Instance;
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
        }

        public override void Load()
        {
            double version = 0.001;
            Window.SetTitle("Sharp Empires " + "v" + version.ToString());
            g.TerrainImage = Graphics.NewImage(@"..\..\..\Assets\Tiles\collection148.png");
            g.ViewX = 0;
            g.ViewY = 0;
            g.MouseX = 0;
            g.MouseY = 0;

            g.Iso = new Isometric();
            // It will generate the terrain
            g.Terrain = new Terrain();

        }

        public override void Update(float dt)
        {
            base.Update(dt);
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

        private float Round(double n, int deci)
        {
            deci = (int)Math.Pow(10, deci);
            return (float)(Math.Floor(n * deci + 0.5) / deci);
        }
    }
}