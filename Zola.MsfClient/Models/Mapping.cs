using System;
namespace Zola.MsfClient.Models
{
	public static class Mapping
	{
		public static List<string> DelimitedStringToList(string delimitedString)
		{
            return delimitedString.Split(';').ToList();
        }

		public static string ListToDelimitedString(List<string>? list)
		{
			if (list is null)
			{
				return "";
			}

            return string.Join(';', list);
        }
    }
}

