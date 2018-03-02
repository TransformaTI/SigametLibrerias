using System;
using System.IO;
using System.Collections;

namespace EDFUIImportacion
{
	/// <summary>
	/// Summary description for FileExplorer.
	/// </summary>
	public class FileItem
	{
		string _fileName;
		string _fullPath;

		public string FileName
		{
			get
			{
				return _fileName;
			}
		}

		public string FullPath
		{
			get
			{
				return _fullPath;
			}
		}

		public FileItem (string FileName, string FullPath)
		{
			this._fileName = FileName;
			this._fullPath =  FullPath;
		}

		public void MoveFile(string TargetFolder)
		{
			File.Move(FullPath, TargetFolder + FileName + ".xml");
		}
	}

	public class FileExplorer
	{
		public FileExplorer()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public ArrayList GetFiles(string Path)
		{
			ArrayList fileList = new ArrayList();

			foreach (string file in Directory.GetFiles(Path))
			{
				fileList.Add(new FileItem(file.Replace(Path, string.Empty).Replace(".xml", string.Empty), file));
			}

			return fileList;
		}
	}
}