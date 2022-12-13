namespace SharpKingdoms
{
    using Love;
    using Sharp_Kingdoms;
    using System;
    using System.Numerics;

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
            //g.Objects.DrawObjects();

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
            nextTime = Timer.GetTime();
            WindowSettings settings = new WindowSettings();
            settings.vsync = true;
            // in full screen if it crashes the screen is blocked needs to restart pc
            // settings.fullscreenType = FullscreenType.DeskTop;
            //  settings.Fullscreen = true;
            Love.Window.SetMode(1680, 1050, settings);
            minDt = 1 / 60;
            Window.SetTitle("Sharp Empires");
            g.TerrainImage = Graphics.NewImage(@"..\..\..\Assets\Tiles\collection148.png");
            g.ViewX = 0;
            g.ViewY = 0;
            g.MouseX = 0;
            g.MouseY = 0;
            g.ScaleX = 1;
            g.ScaleY = 1;

            g.Iso = new Isometric();
            g.Terrain = new Terrain();
            g.Objects = new Objects();
        }

        public override void MousePressed(float x, float y, int button, bool isTouch)
        {
            base.MousePressed(x, y, button, isTouch);
            g.Terrain.MousePressed(x, y, button, isTouch);
        }

        public override void MouseReleased(float x, float y, int button, bool isTouch)
        {
            base.MouseReleased(x, y, button, isTouch);
            g.Terrain.MouseReleased(x, y, button, isTouch);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            nextTime += minDt;
            Utils.GetMousePositions();
            g.LocalX = Utils.Round(g.Iso.ScreenToIsoX(g.MouseX + g.ViewX, g.MouseY + g.ViewY), 0);
            g.LocalY = Utils.Round(g.Iso.ScreenToIsoY(g.MouseX + g.ViewX, g.MouseY + g.ViewY), 0);
            g.Iso.Update();
            g.Terrain.Update();
        }

        public override void WheelMoved(int x, int y)
        {
            base.WheelMoved(x, y);
            g.Iso.Scale(y);
        }
    }
}