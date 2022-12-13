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
    }
}
