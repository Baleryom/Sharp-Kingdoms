using Love;

namespace Sharp_Kingdoms
{
    public static class Utils
    {
        static Global g = Global.Instance;
        public static float Round(double n, int deci)
        {
            deci = (int)Math.Pow(10, deci);
            return (float)(Math.Floor(n * deci + 0.5) / deci);
        }

        public static void GetMousePositions()
        {
            g.MouseX = Mouse.GetPosition().X;
            g.MouseY = Mouse.GetPosition().Y;
        }

        public static void BrenDrawLine(int x0, int y0, int x1, int y1, int obj)
        {
            var t = g.Terrain;
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            int err = dx - dy;

            while (true)
            {
                t.TerrainChunk[x0 + 1, y0] = obj;

                if (x0 == x1 && y0 == y1)
                {
                    break;
                }

                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }

                if (x0 == x1 && y0 == y1)
                {
                    t.TerrainChunk[x0 + 1, y0] = obj;
                    break;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }
    }
}
