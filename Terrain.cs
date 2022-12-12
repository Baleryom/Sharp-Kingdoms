using Love;

namespace Sharp_Kingdoms
{
    public class Terrain
    {
        Global g = Global.Instance;
        public Terrain()
        {
            GenerateTerrainChunk();
            SpriteBatch();
        }
        // Tiles
        protected int TileWidth = 32;
        protected int TileHeight = 16;
        protected int TileVariations = 1;

        // Chunks
        protected static int ChunkHeight = 32;
        protected static int ChunkWidth = 32;
        protected int ChunkSize = ChunkHeight * ChunkWidth;

        // Rows and Columns
        static int Cols = ChunkWidth;
        static int Rows = ChunkHeight;

        // Chunk 2D array
        int[,] TerrainChunk = new int[Cols, Rows];

        // Tile Quads
        Quad[] TileQuads = new Quad[8];

        // Terrain Batch
        SpriteBatch TerrainBatch;

        public void GenerateTerrainChunk()
        {
            for (int y = 0; y < Cols; y++)
            {
                for (int x = 0; x < Rows; x++)
                {
                    TerrainChunk[y, x] = new Random().Next(0, 8);
                }
            }
        }

        public void SpriteBatch()
        {
            var terrainImage = Graphics.NewImage(@"..\..\..\Assets\Tiles\terrain_strip2.png");
            TileQuads[0] = Graphics.NewQuad(0 * TileWidth, 0 * TileHeight, TileWidth - 2, TileHeight, terrainImage.GetWidth(), terrainImage.GetHeight());
            TileQuads[1] = Graphics.NewQuad(1 * (TileWidth - 2), 0 * TileHeight, TileWidth - 2, TileHeight, terrainImage.GetWidth(), terrainImage.GetHeight());
            TileQuads[2] = Graphics.NewQuad(2 * (TileWidth - 2), 0 * TileHeight, TileWidth - 2, TileHeight, terrainImage.GetWidth(), terrainImage.GetHeight());
            TileQuads[3] = Graphics.NewQuad(3 * (TileWidth - 2), 0 * TileHeight, TileWidth - 2, TileHeight, terrainImage.GetWidth(), terrainImage.GetHeight());
            TileQuads[4] = Graphics.NewQuad(4 * (TileWidth - 2), 0 * TileHeight, TileWidth - 2, TileHeight, terrainImage.GetWidth(), terrainImage.GetHeight());
            TileQuads[5] = Graphics.NewQuad(5 * (TileWidth - 2), 0 * TileHeight, TileWidth - 2, TileHeight, terrainImage.GetWidth(), terrainImage.GetHeight());
            TileQuads[6] = Graphics.NewQuad(6 * (TileWidth - 2), 0 * TileHeight, TileWidth - 2, TileHeight, terrainImage.GetWidth(), terrainImage.GetHeight());
            TileQuads[7] = Graphics.NewQuad(7 * (TileWidth - 2), 0 * TileHeight, TileWidth - 2, TileHeight, terrainImage.GetWidth(), terrainImage.GetHeight());
            TerrainBatch = Graphics.NewSpriteBatch(terrainImage, ChunkWidth * ChunkHeight, SpriteBatchUsage.Static);
            UpdateTerrain();
        }

        public void UpdateTerrain()
        {
            TerrainBatch.Clear();
            for (int i = ChunkWidth - 1; i >= 0; i--)
            {
                for (int o = ChunkHeight - 1; o >= 0; o--)
                {
                    TerrainBatch.Add(
                        TileQuads[TerrainChunk[i, o]],
                        (-g.ViewX) + g.IsoX + (i - o) * TileWidth * 0.5f,
                        (-g.ViewY) + g.IsoY + (i + o) * TileHeight * 0.5f
                        );
                }
            }
            TerrainBatch.Flush();
        }

        public void DrawTerrain()
        {
            Graphics.Draw(TerrainBatch, 0, 0, 0, 1, 1);
        }
    }
}
