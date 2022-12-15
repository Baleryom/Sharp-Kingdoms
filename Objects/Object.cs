namespace Sharp_Kingdoms.Objects
{
    public class Object
    {
        public int Cx { get; set; }
        public int Cy { get; set; }
        public int I { get; set; }
        public int O { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Type { get; set; }
        public Object(int cx, int cy, int i, int o, int x, int y, int type)
        {
            this.Cx = cx;
            this.Cy = cy;
            this.I = i;
            this.O = o;
            this.X = x;
            this.Y = y;
            this.Type = type;
        }
    }
}
