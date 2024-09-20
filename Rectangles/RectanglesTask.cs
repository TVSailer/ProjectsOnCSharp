using System;

namespace Rectangles;

public static class RectanglesTask
{
    // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        if (Are(r1, r2)) return true;
        else if (Are(r2, r1)) return true;
        return false;
    }

    public static bool Are(Rectangle r1, Rectangle r2)
    {
        bool a = r2.Left >= r1.Right && r2.Left <= r1.Left;
        bool b = r2.Top <= r1.Top && r2.Top >= r1.Bottom;
        bool c = r2.Bottom >= r1.Bottom && r2.Bottom <= r1.Top;
        bool d = r2.Right >= r1.Right && r2.Right <= r1.Left;

        if (a && b || a && c || d && b || d && c)
            return true;

        return false;
    }
    // Площадь пересечения прямоугольников
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        return 0;
    }

    // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
    // Иначе вернуть -1
    // Если прямоугольники совпадают, можно вернуть номер любого из них.
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        if (CheckInnerRect(r1, r2))
            return 1;
        else if (CheckInnerRect(r2, r1))
            return 0;

        return -1;
    }
   
    public static bool CheckInnerRect(Rectangle r1, Rectangle r2)
    {
        return r1.Left <= r2.Left && r1.Right >= r2.Right && r1.Top <= r2.Top && r1.Bottom >= r2.Bottom;
    }
}