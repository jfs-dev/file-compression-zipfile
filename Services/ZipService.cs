using System.IO.Compression;

namespace file_compression_zipfile.Services;

public class ZipService
{
    public void CreateZip(string directoryFilesToCompress, string createdZipFile)
    {
        if (!Directory.Exists(directoryFilesToCompress)) throw new InvalidOperationException("Favor informar um diretório válido!");
        if (!Directory.EnumerateFiles(directoryFilesToCompress).Any()) throw new InvalidOperationException("Não existem arquivos no diretório!");
        
        if (File.Exists(createdZipFile)) File.Delete(createdZipFile);

        ZipFile.CreateFromDirectory(directoryFilesToCompress, createdZipFile);
    }

    public void AddFileToZip(string existingZipFile, string fileToAdd)
    {
        if (!File.Exists(existingZipFile)) throw new InvalidOperationException("Favor informar um arquivo válido!");
        if (!File.Exists(fileToAdd)) throw new InvalidOperationException("Favor informar um arquivo válido!");

        using ZipArchive zip = ZipFile.Open(existingZipFile, ZipArchiveMode.Update);
        
        zip.CreateEntryFromFile(fileToAdd, Path.GetFileName(fileToAdd));
    }

    public void RemoveFileFromZip(string existingZipFile, string fileToRemove)
    {
        if (!File.Exists(existingZipFile)) throw new InvalidOperationException("Favor informar um arquivo válido!");

        string tempPath = "Temp";
        string tempFileName = Path.Combine(tempPath, "temp.zip");

        if (!Directory.Exists(tempPath)) throw new InvalidOperationException("Favor criar um diretório Temp na raiz do projeto!");

        if (Directory.EnumerateFiles(tempPath).Any())
        {
            string[] files = Directory.GetFiles(tempPath);

            foreach (string file in files)
                File.Delete(file);
        }

        using (ZipArchive zip = ZipFile.Open(existingZipFile, ZipArchiveMode.Read))
        {
            using ZipArchive tempZip = ZipFile.Open(tempFileName, ZipArchiveMode.Create);
            
            foreach (ZipArchiveEntry entry in zip.Entries)
                if (entry.FullName != fileToRemove)
                {
                    entry.ExtractToFile(Path.Combine(tempPath, entry.FullName));
                    tempZip.CreateEntryFromFile(Path.Combine(tempPath, entry.FullName), entry.FullName);
                }
        }

        File.Delete(existingZipFile);
        File.Move(tempFileName, existingZipFile);
    }

    public void ExtractZip(string existingZipFile, string extractPath)
    {
        if (!File.Exists(existingZipFile)) throw new InvalidOperationException("Favor informar um arquivo válido!");
        if (!Directory.Exists(extractPath)) throw new InvalidOperationException("Favor informar um diretório válido!");
 
        if (Directory.EnumerateFiles(extractPath).Any())
        {
            string[] files = Directory.GetFiles(extractPath);

            foreach (string file in files)
                File.Delete(file);
        }

        ZipFile.ExtractToDirectory(existingZipFile, extractPath);
    }    
}