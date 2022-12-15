namespace Sharp_Kingdoms.Objects.Units
{
    public class Unit : Object
    {
        public int Gx { get; set; }
        public int Gy { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int Fx { get; set; }
        public int Fy { get; set; }
        public int PrevCx { get; set; }
        public int PrevCy { get; set; }
        public int WaypointX { get; set; }
        public int WaypointY { get; set; }
        public int StraightWallSpeed { get; set; }
        public int DiagonalWallSpeed { get; set; }
        public int OriginalX { get; set; }
        public int OriginalY { get; set; }
        public List<int> Nd { get; set; }
        public int Path { get; set; }
        public string PathState { get; set; }
        public string MoveDir { get; set; }
        public bool UpdatedDir { get; set; }
        public string PrevDir { get; set; }
        public bool Animated { get; set; }
        public string NoPathState { get; set; }
        public int lrcx, lrcy, lrx, lry = 0;

        Global g = Global.Instance;
        public Unit(int cx, int cy, int i, int o, int x, int y, int type, int no_path_state) : base(cx, cy, i, o, x, y, type)
        {
            Gx = g.ChunkWidth * Cx + I;
            Gy = g.ChunkHeight * Cy + O;
            EndX = 0;
            EndY = 0;
            Fx = Gx * 1000;
            Fy = Gy * 1000;
            PrevCx = cx;
            PrevCy = cy;
            WaypointX = 0;
            WaypointY = 0;
            StraightWallSpeed = 42;
            DiagonalWallSpeed = 25;
            OriginalX = Gx;
            OriginalY = Gy;
            Nd = new List<int>();
            Path = 0;
            PathState = "None";
            MoveDir = "None";
            UpdatedDir = true;
            PrevDir = "None";
            Animated = true;
            NoPathState = "No Path";
        }
    }
}
