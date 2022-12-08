using System;
namespace Day07
{
	public class ElfFile
	{
		private string name { get; set; }
		private int size { get; set;}

		public ElfFile(string name, int size)
		{
			this.name = name;
			this.size = size;
		}

		public int GetSize()
		{
			return size;
		}
	}
}

