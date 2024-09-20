namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
		int[] n = new int[] { 2, 3, 4 };
		// Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
		if (count % 10 == 1 && count % 100 != 11)
			return "рубль";
		else if (n.Contains(count % 10) && count % 100 != (count % 10) + 10)
			return "рубля";
		return "рублей";
	}
}