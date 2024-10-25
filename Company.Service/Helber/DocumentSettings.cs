using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helber
{
	public class DocumentSettings
	{
		public static string UploadFile(IFormFile file, string folderName)
		{
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files",folderName); //Get folder path

			var fileName = $"{Guid.NewGuid()}-{file.FileName}"; //Get file name

			var filePath=Path.Combine(folderPath,fileName); //compine file path + folder path

			using var fileStream = new FileStream(filePath , FileMode.Create); //save file

			file.CopyTo(fileStream);

			return filePath;

		}
	}
}
