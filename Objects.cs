using Love;

namespace Sharp_Kingdoms
{
    public class Objects
    {
        Global g = Global.Instance;
        Canvas canvas { get; set; }
        int Cols { get; set; }
        int Rows { get; set; }
        int ogX { get; set; }
        int ogY { get; set; }
        Image[,] ObjectChunk { get; set; }
        Image[] ObjectImage { get; set; } = new Image[2];

        public Objects()
        {
            SetupObjects();
        }
        private void InitializeFields()
        {
            canvas = Graphics.NewCanvas(1680, 1050);
            Cols = g.ChunkWidth;
            Rows = g.ChunkHeight;
            ogX = 700;
            ogY = 500;
            ObjectChunk = new Image[Cols, Rows];

        }
        public void SetupObjects()
        {
            InitializeFields();
            Image imageData = Graphics.NewImage(Image.NewImageData(1, 1));
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    ObjectChunk[i, j] = imageData;
                }
            }
            ObjectImage[1] = Graphics.NewImage(@"..\..\..\Assets\Trees\0_0img0.png");
            UpdateObjects();
        }

        void UpdateObjects()
        {
            ObjectChunk[0, 0] = ObjectImage[1];
            for (int i = 0; i < g.ChunkWidth - 1; i++)
            {
                for (int o = 0; o < g.ChunkHeight - 1; o++)
                {
                    if (new Random().Next(0, 100) == 1)
                    {
                        ObjectChunk[i, o] = ObjectImage[1];
                    }
                }
            }
            Graphics.SetCanvas(canvas);
            Graphics.Clear();
            Graphics.SetBlendMode(BlendMode.Alpha);
            for(int i=0; i < g.ChunkWidth; i++)
            {
                for(int j=0;j< g.ChunkHeight; j++)
                {
                    Graphics.Draw(ObjectChunk[i, j], ogX + g.Iso.OgIsoToScreenX(i, j) - 77 + 16, ogY + g.Iso.OgIsoToScreenY(i, j) - 138 + 8);
                }
            }
            Graphics.SetCanvas();
        }

        public void DrawObjects()
        {
            Graphics.SetColor(255, 255, 255, 255);
            Graphics.SetBlendMode(BlendMode.Alpha, BlendAlphaMode.PreMultiplied);
            Graphics.Draw(canvas, -g.ViewX - ogX, -g.ViewY - ogY);
            Graphics.SetBlendMode(BlendMode.Alpha);
        }

    }
}
