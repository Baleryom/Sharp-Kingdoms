namespace Sharp_Kingdoms
{
    public class Isometric : Terrain
    {
        Global g = Global.Instance;

        public float ScreenToIsoX(float globalX, float globalY)
        {
            return (((globalX - g.IsoX) / (TileWidth / 2)) + ((globalY - g.IsoY) / (TileHeight / 2))) / 2;
        }

        public float ScreenToIsoY(float globalX, float globalY)
        {
            return (((globalY - g.IsoY) / (TileHeight / 2)) - ((globalX - g.IsoX) / (TileWidth / 2))) / 2;
        }

        public float IsoToScreenX(float x, float y)
        {
            return g.IsoX + ((x - y) * TileWidth / 2);
        }

        public float IsoToScreenY(float x, float y)
        {
            return g.IsoY + ((x + y) * TileHeight / 2);
        }
    }
}
