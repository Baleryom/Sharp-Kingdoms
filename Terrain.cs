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
        int TileWidth = 32;
        int TileHeight = 16;
        int TileVariations = 1;

        // Chunks
        static int ChunkHeight = 32;
        static int ChunkWidth = 32;
        int ChunkSize = ChunkHeight * ChunkWidth;
        int IsoX = 400;
        int IsoY = 0;

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
                        (-g.ViewX) + IsoX + (i - o) * TileWidth * 0.5f,
                        (-g.ViewY) + IsoY + (i + o) * TileHeight * 0.5f
                        );
                }
            }
            TerrainBatch.Flush();
        }

        public void DrawTerrain()
        {
            Graphics.Draw(TerrainBatch, 0, 0, 0, 1, 1);
        }

        public float ScreenToIsoX(float globalX, float globalY)
        {
            return (((globalX - IsoX) / (TileWidth / 2)) + ((globalY - IsoY) / (TileHeight / 2))) / 2;
        }

        public float ScreenToIsoY(float globalX, float globalY)
        {
            return (((globalY - IsoY) / (TileHeight / 2)) - ((globalX - IsoX) / (TileWidth / 2))) / 2;
        }

        public float IsoToScreenX(float x, float y)
        {
            return IsoX + ((x - y) * TileWidth / 2);
        }

        public float IsoToScreenY(float x, float y)
        {
            return IsoY + ((x + y) * TileHeight / 2);
        }
    }
}
