using System;
namespace Day07
{
	public class ElfDirectory
	{
		string name;
		List<ElfDirectory> directories;
		List<ElfFile> files;
		ElfDirectory? parentDirectory;
		private int aSize { get; set; }
		

		public ElfDirectory(string name, ElfDirectory currentDirectory)
		{
			this.name = name;
			directories = new List<ElfDirectory>();
			files = new List<ElfFile>();
			parentDirectory = currentDirectory;
		}

		public ElfDirectory(string name)
		{
            this.name = name;
            directories = new List<ElfDirectory>();
            files = new List<ElfFile>();
            parentDirectory = null;
        }

		public string GetName()
		{
			return name;
		}

		public int GetSize()
		{
			CalculateSize();
			return aSize;
		}


		public List<ElfDirectory> GetDirectories()
		{
			return directories;
		}

		public ElfDirectory GetParentDirectory()
		{
			return parentDirectory;
		}

		public void AddChildDirectory(ElfDirectory directory)
		{
			directories.Add(directory);
        }

        public void AddFile(ElfFile file)
		{
			files.Add(file);
		}

		public void CalculateSize()
		{
			int tempSize = 0;

			foreach(ElfDirectory directory in directories)
			{
				tempSize += directory.GetSize();
			};

			foreach(ElfFile file in files)
			{
				tempSize += file.GetSize();
			}

			aSize = tempSize;
		}

		public int GetSizeUnder100000()
		{
			int total = 0;

			foreach (ElfDirectory directory in directories)
			{
				int directorySize = directory.GetSize();

				if (directorySize < 100000)
				{
					total += directorySize;
				}
			}

			return total;
		}
	}
}

