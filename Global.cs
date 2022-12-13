using Love;

namespace Sharp_Kingdoms
{
    public class Global
    {
        // The private static instance of the singleton class
        private static Global _instance;


        // The private constructor
        private Global()
        {
            // Initialize the instance
        }

        // The public static property that provides access to the instance
        public static Global Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Global();
                }
                return _instance;
            }
        }

        // Public global fields
        public float ViewX { get; set; }
        public float ViewY { get; set; }
        public float MouseX { get; set; }
        public float MouseY { get; set; }
        public float LocalX { get; set; }
        public float LocalY { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        // Tiles
        public int TileWidth { get; set; } = 30;
        public int TileHeight { get; set; } = 16;
        public int IsoX { get; set; } = 400;
        public int IsoY { get; set; } = 100;
        public int ChunkWidth { get; set; }
        public int ChunkHeight { get; set; }
        // Images
        public Image TerrainImage { get; set; }
        // Classes
        public Isometric Iso { get; set; }
        public Terrain Terrain { get; set; }
        public Objects Objects { get; set; }
    }
}
