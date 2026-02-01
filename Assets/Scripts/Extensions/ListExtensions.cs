using System.Collections.Generic;

namespace StudyProject.Extensions
{
	public static class ListExtensions
	{
		public static List<T> Clone<T>(this List<T> list)
		{
			List<T> newList = new();
			
			foreach (var element in list)
			{
				newList.Add(element);
			}
			
			return newList;
		}

		public static T Pick<T>(this List<T> list, int index)
		{
			T element = list[index];
			list.RemoveAt(index);
			return element;
		}
	}
}