using Love;

namespace Sharp_Kingdoms
{
    public class Terrain : Scene
    {
        Global g = Global.Instance;
        public Terrain()
        {
            GenerateTerrainChunk();
            SpriteBatch();
            // Load global variables
            g.ChunkHeight = ChunkHeight;
            g.ChunkWidth = ChunkWidth;
        }
        protected int TileVariations = 1;

        // Chunks
        protected static int ChunkHeight = 64;
        protected static int ChunkWidth = 64;
        protected int ChunkSize = ChunkHeight * ChunkWidth;

        // Rows and Columns
        static int Cols = ChunkWidth;
        static int Rows = ChunkHeight;

        // Chunk 2D array
        public int[,] TerrainChunk = new int[Cols, Rows];

        // Tile Quads
        Quad[] TileQuads = new Quad[13];
        int[] TileOffsets = new int[13];

        // Terrain Batch
        SpriteBatch TerrainBatch;
        public int FirstLocationX, FirstLocationY, LastLocationX, LastLocationY = 0;
        public float LocationDistance { get; set; } = 0;
        public float Angle { get; set; } = 0;

        public int GetTerrainChunk(int x, int y)
        {
            try
            {
                return TerrainChunk[x, y];
            }
            catch
            {
                return -1;
            }
        }

        public void GenerateTerrainChunk()
        {
            for (int y = 0; y < Cols; y++)
            {
                for (int x = 0; x < Rows; x++)
                {
                    TerrainChunk[y, x] = new Random().Next(0, 9);
                }
            }
        }

        public void GenerateWallPiece()
        {
            for (int i = 0; i < LocationDistance; i++)
            {
                TerrainChunk[FirstLocationX + 1, FirstLocationY] = 10;
            }
        }

        public override void MousePressed(float x, float y, int button, bool isTouch)
        {
            base.MouseReleased(x, y, button, isTouch);
            if (button == 1 && g.LocalX >= 0 && g.LocalY >= 0 && g.LocalX < ChunkWidth && g.LocalY < ChunkWidth)
            {
                Utils.GetMousePositions();
                g.LocalX = Utils.Round(g.Iso.ScreenToIsoX(g.MouseX - 16 + g.ViewX, g.MouseY - 8 + g.ViewY), 0);
                g.LocalY = Utils.Round(g.Iso.ScreenToIsoY(g.MouseX - 16 + g.ViewX, g.MouseY - 8 + g.ViewY), 0);
                FirstLocationX = (int)g.LocalX;
                FirstLocationY = (int)g.LocalY;
            }
        }

        public override void MouseReleased(float x, float y, int button, bool isTouch)
        {
            base.MouseReleased(x, y, button, isTouch);
            if (button == 1 && g.LocalX >= 0 && g.LocalY >= 0 && g.LocalX < ChunkWidth && g.LocalY < ChunkHeight)
            {
                Utils.GetMousePositions();
                LastLocationX = (int)g.LocalX;
                LastLocationY = (int)g.LocalY;
                LocationDistance = ((LastLocationX - FirstLocationX) + (LastLocationY - FirstLocationY)) / 2;
                Angle = (float)Math.Atan2(LastLocationY - FirstLocationY, LastLocationX - FirstLocationX);
                Angle = (float)((Angle * 180) / Math.PI);
                Angle = Utils.Round(Angle, 0);
                if (Angle < 0)
                {
                    Angle += 360;
                }
                GenerateWallPiece();
            }
        }

        public void SpriteBatch()
        {
            var terrainImage = Graphics.NewImage(@"..\..\..\Assets\Tiles\image_strip.png");
            var imageW = terrainImage.GetWidth();
            var imageH = terrainImage.GetHeight();
            TileOffsets[0] = 0;
            TileOffsets[1] = 0;
            TileOffsets[2] = 0;
            TileOffsets[3] = 0;
            TileOffsets[4] = 0;
            TileOffsets[5] = 0;
            TileOffsets[6] = 0;
            TileOffsets[7] = 0;
            TileOffsets[8] = 0;
            TileOffsets[9] = 107 - 16;
            TileOffsets[10] = 107 - 16;
            TileQuads[0] = Graphics.NewQuad(0, 1850, 30, 16, imageW, imageH);
            TileQuads[1] = Graphics.NewQuad(30, 1850, 30, 16, imageW, imageH);
            TileQuads[2] = Graphics.NewQuad(0, 1882, 30, 16, imageW, imageH);
            TileQuads[3] = Graphics.NewQuad(30, 1866, 30, 16, imageW, imageH);
            TileQuads[4] = Graphics.NewQuad(0, 1898, 30, 16, imageW, imageH);
            TileQuads[5] = Graphics.NewQuad(60, 1850, 30, 16, imageW, imageH);
            TileQuads[6] = Graphics.NewQuad(30, 1882, 30, 16, imageW, imageH);
            TileQuads[7] = Graphics.NewQuad(0, 1914, 30, 16, imageW, imageH);
            TileQuads[8] = Graphics.NewQuad(60, 1866, 30, 16, imageW, imageH);
            TileQuads[9] = Graphics.NewQuad(420, 1850, 30, 107, imageW, imageH);
            TileQuads[10] = Graphics.NewQuad(450, 1850, 30, 107, imageW, imageH);
            TerrainBatch = Graphics.NewSpriteBatch(terrainImage, ChunkWidth * ChunkHeight, SpriteBatchUsage.Dynamic);
            UpdateTerrain();
        }

        public void UpdateTerrain()
        {
            TerrainBatch.Clear();
            for (int i = 0; i <= ChunkWidth - 1; i++)
            {
                for (int o = 0; o <= ChunkHeight - 1; o++)
                {
                    TerrainBatch.Add(
                        TileQuads[TerrainChunk[i, o]],
                        g.IsoX + (i - o) * g.TileWidth * 0.5f,
                        g.IsoY + (i + o) * g.TileHeight * 0.5f - TileOffsets[TerrainChunk[i, o]]
                        );
                }
            }
            TerrainBatch.Flush();
        }

        public void DrawTerrain()
        {
            Graphics.Draw(TerrainBatch, -g.ViewX, -g.ViewY, 0, g.ScaleX, g.ScaleY);
        }

        public void Update()
        {
            if (Mouse.IsDown(0))
            {
                if (g.LocalX >= 0 && g.LocalY >= 0 && g.LocalX < g.ChunkWidth && g.LocalY < g.ChunkHeight)
                {
                    Utils.GetMousePositions();
                    g.LocalX = Utils.Round(g.Iso.ScreenToIsoX(g.MouseX - 16 + g.ViewX, g.MouseY - 8 + g.ViewY), 0);
                    g.LocalY = Utils.Round(g.Iso.ScreenToIsoY(g.MouseX - 16 + g.ViewX, g.MouseY - 8 + g.ViewY), 0);
                    g.Terrain.LastLocationX = (int)g.LocalX;
                    g.Terrain.LastLocationY = (int)g.LocalY;
                    g.Terrain.LocationDistance = (g.Terrain.LastLocationX - g.Terrain.FirstLocationX) + (g.Terrain.LastLocationY - g.Terrain.FirstLocationY);
                    g.Terrain.Angle = (float)Math.Atan2(g.Terrain.LastLocationY - g.Terrain.FirstLocationY, g.Terrain.LastLocationX - g.Terrain.FirstLocationX);
                    g.Terrain.Angle = (float)((g.Terrain.Angle * 180) / Math.PI);
                    g.Terrain.Angle = Utils.Round(g.Terrain.Angle, 0);
                    if (g.Terrain.Angle < 0)
                    {
                        g.Terrain.Angle += 360;
                    }
                    g.Terrain.GenerateWallPiece();
                    //g.Terrain.TerrainChunk[(int)(Math.Floor(g.LocalX)), (int)(Math.Floor(g.LocalY))] = 9;
                    g.Terrain.UpdateTerrain();
                }
            }
        }
    }
}
