using System;

namespace NoteTaking.Common.Wrappers
{
	public class GuidWrapper : IGuidWrapper
	{
		public Guid NewGuid()
		{
			return Guid.NewGuid();
		}
	}
}