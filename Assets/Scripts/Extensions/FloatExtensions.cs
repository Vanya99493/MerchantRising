using System;

namespace StudyProject.Extensions
{
	public static class FloatExtensions
	{
		public static float Round(this float value, int decimalPlaces)
		{
			return (float)Math.Round((decimal)value, decimalPlaces);
		}
	}
}