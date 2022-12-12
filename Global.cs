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
        public int IsoX { get; set; } = 400;
        public int IsoY { get; set; } = 0;
        // Images
        public Image TerrainImage { get; set; }
        // Classes
        public Isometric Iso { get; set; }
        
        public Terrain Terrain { get; set; }
    }
}
