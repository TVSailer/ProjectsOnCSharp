using Avalonia.Media;
using RefactorMe.Common;
using System;
using Brushes = Avalonia.Media.Brushes;
using Pen = Avalonia.Media.Pen;

namespace RefactorMe
{
    class Risovatel
    {
        static float x, y;
        static IGraphics Grafika;

        public static void Initialization(IGraphics novayaGrafika)
        {
            Grafika = novayaGrafika;
            //Grafika.SmoothingMode = SmoothingMode.None;
            Grafika.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void MakeIt(Pen ruchka, double dlina, double ugol)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + dlina * Math.Cos(ugol));
            var y1 = (float)(y + dlina * Math.Sin(ugol));
            Grafika.DrawLine(ruchka, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double dlina, double ugol)
        {
            x = (float)(x + dlina * Math.Cos(ugol));
            y = (float)(y + dlina * Math.Sin(ugol));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int shirina, int visota, double ugolPovorota, IGraphics grafika)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Risovatel.Initialization(grafika);

            var sz = Math.Min(shirina, visota);
            var width1 = sz * 0.375f;
            var width2 = sz * 0.04f;

            var diagonal_length = Math.Sqrt(2) * (width1 + width2) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + shirina / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + visota / 2f;

            Risovatel.SetPosition(x0, y0);

            RisovateSide(width1, width2, 0);
            RisovateSide(width1, width2, -Math.PI / 2);
            RisovateSide(width1, width2, Math.PI);
            RisovateSide(width1, width2, Math.PI / 2);
        }

        private static void RisovateSide(float width1, float width2, double mathPi)
        {
            Risovatel.MakeIt(new Pen(Brushes.Yellow), width1, mathPi);
            Risovatel.MakeIt(new Pen(Brushes.Yellow), width2 * Math.Sqrt(2), mathPi + Math.PI / 4);
            Risovatel.MakeIt(new Pen(Brushes.Yellow), width1, mathPi + Math.PI);
            Risovatel.MakeIt(new Pen(Brushes.Yellow), width1 - width2, mathPi + Math.PI / 2);

            Risovatel.Change(width2, mathPi - Math.PI);
            Risovatel.Change(width2 * Math.Sqrt(2), mathPi + 3 * Math.PI / 4);

            
        }
    }
}