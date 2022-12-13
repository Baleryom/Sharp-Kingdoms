using Love;
using static System.Net.Mime.MediaTypeNames;

namespace Sharp_Kingdoms
{
    public class Terrain
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
        protected static int ChunkHeight = 80;
        protected static int ChunkWidth = 80;
        protected int ChunkSize = ChunkHeight * ChunkWidth;

        // Rows and Columns
        static int Cols = ChunkWidth;
        static int Rows = ChunkHeight;

        // Chunk 2D array
        public int[,] TerrainChunk = new int[Cols, Rows];

        // Tile Quads
        Quad[] TileQuads = new Quad[10];
        int[] TileOffsets = new int[10];

        // Terrain Batch
        SpriteBatch TerrainBatch;

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
    }
}
