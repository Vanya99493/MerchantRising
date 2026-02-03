using System.Collections.Generic;
using UnityEngine;

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

		public static List<T> GetRandomAmount<T>(this List<T> list, int amount)
		{
			List<T> newList = new();
			int elementsLeft = amount;
			int currentIndex = 0;
			foreach (var element in list)
			{
				if (Random.Range(0, list.Count - currentIndex) < elementsLeft)
				{
					newList.Add(element);
					elementsLeft--;
				}
				
				currentIndex++;
			}

			return newList;
		}
	}
}