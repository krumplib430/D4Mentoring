using System;

namespace NoteTaking.Common.Wrappers
{
	public class DateTimeWrapper : IDateTimeWrapper
	{
		public DateTime UtcNow()
		{
			return DateTime.UtcNow;
		}
	}
}