using System.Collections.Generic;

namespace Recognizer;

public static class MedianFilterTask
{
	/* 
	 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
	 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
	 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
	 * https://en.wikipedia.org/wiki/Median_filter
	 * 
	 * Используйте окно размером 3х3 для не граничных пикселей,
	 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
	 */
	static int lenghtX = 3;
	static int lenghtY = 3;

    static int[] d = { -1, 0, 1 };

    public static double[,] MedianFilter(double[,] original)
	{
        lenghtX = original.GetLength(0);
        lenghtY = original.GetLength(1);

		double[,] noOriginal = new double[lenghtX, lenghtY];
		
		for (int i = 0; i < lenghtX; i++)
			for (int j = 0; j < lenghtY; j++)
				GetFilter3on3(original, i, j, ref noOriginal);
			
		return noOriginal;
	}

    public static void GetFilter3on3(double[,] original, int x, int y, ref double[,] noOriginal)
    {
        List<double> spomogal = new List<double> { };

        for (int i = 0; i < 3; i++)
			for (int j = 0; j < 3; j++)
			{
				var dx = x + d[i];
				var dy = y + d[j];

				if (dx >= 0 && dy >= 0 && dx < lenghtX && dy < lenghtY)
					spomogal.Add(original[dx, dy]);
			}
		spomogal.Sort();
		if (spomogal.Count % 2 != 0)
			noOriginal[x, y] = spomogal[spomogal.Count / 2];
		else
			noOriginal[x, y] = (spomogal[spomogal.Count / 2] + spomogal[spomogal.Count / 2 - 1]) / 2; 
    }
}
