using Love;

namespace Sharp_Kingdoms
{
    public class Isometric
    {
        Global g = Global.Instance;

        public float ScreenToIsoX(float globalX, float globalY)
        {
            return (((globalX - g.IsoX) / (g.TileWidth / 2)) + ((globalY - g.IsoY) / (g.TileHeight / 2))) / 2;
        }

        public float ScreenToIsoY(float globalX, float globalY)
        {
            return (((globalY - g.IsoY) / (g.TileHeight / 2)) - ((globalX - g.IsoX) / (g.TileWidth / 2))) / 2;
        }

        public float IsoToScreenX(float x, float y)
        {
            return g.IsoX + ((x - y) * g.TileWidth / 2);
        }

        public float IsoToScreenY(float x, float y)
        {
            return g.IsoY + ((x + y) * g.TileHeight / 2);
        }

        public float OgIsoToScreenX(float x, float y)
        {
            return ((x - y) * g.TileWidth / 2);
        }

        public float OgIsoToScreenY(float x, float y)
        {
            return ((x + y) * g.TileHeight / 2);
        }

        public void Update()
        {
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
            if (Keyboard.IsDown(KeyConstant.Escape))
            {
                Event.Quit();
            }
        }

        public void Scale(int y)
        {
            if (y > 0 && g.ScaleX < 1)
            {
                g.ScaleX += 0.1f;
                g.ScaleY += 0.1f;
            }
            if (y < 0 && g.ScaleY > 0.3)
            {
                g.ScaleX -= 0.1f;
                g.ScaleY -= 0.1f;
            }
        }
    }
}
