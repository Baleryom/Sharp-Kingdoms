namespace Sharp_Kingdoms
{
    public class Isometric
    {
        Global g = Global.Instance;

        public float ScreenToIsoX(float globalX, float globalY)
        {
            return (((globalX - g.IsoX) / (g.TileWidth / 2)) + ((globalY - g.IsoY) / (g.TileHeight / 2))) / 2;
        }

        public float ScreenToIsoY(float globalX, float globalY)
        {
            return (((globalY - g.IsoY) / (g.TileHeight / 2)) - ((globalX - g.IsoX) / (g.TileWidth / 2))) / 2;
        }

        public float IsoToScreenX(float x, float y)
        {
            return g.IsoX + ((x - y) * g.TileWidth / 2);
        }

        public float IsoToScreenY(float x, float y)
        {
            return g.IsoY + ((x + y) * g.TileHeight / 2);
        }

        public float OgIsoToScreenX(float x, float y)
        {
            return ((x - y) * g.TileWidth / 2);
        }

        public float OgIsoToScreenY(float x, float y)
        {
            return ((x + y) * g.TileHeight / 2);
        }
    }
}
