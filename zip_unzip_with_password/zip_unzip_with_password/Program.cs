using Ionic.Zip;

namespace zip_unzip_with_password
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = @"C:\Users\hyoseong\Desktop\test.zip";
            string zipPath2 = @"C:\Users\hyoseong\Desktop\test2.zip";
            string path = @"C:\Users\hyoseong\Desktop\123.txt";
            string unzipPath = @"C:\Users\hyoseong\Desktop\aa";
            string unzipPath2 = @"C:\Users\hyoseong\Desktop\aa2";
            string password = "test123";

            new Program().Zip(path, zipPath, password);
            new Program().Zip(path, zipPath2);

            new Program().UnZip(zipPath, unzipPath, password);
            new Program().UnZip(zipPath2, unzipPath2);

        }

        public void Zip(string directoryPath, string zipPath, string password = null)
        {
            using (ZipFile zip = new ZipFile(zipPath))
            {
                zip.Password = password;
                zip.AddFile(directoryPath, string.Empty);
                zip.Save(zipPath);
            }
        }

        public void UnZip(string zipFilePath, string unZipPath, string password = null)
        {
            using (ZipFile zip = new ZipFile(zipFilePath))
            {
                zip.Password = password;
                zip.ExtractAll(unZipPath);
            }
        }
    }
}
