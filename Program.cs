using file_compression_zipfile.Services;

var directoryFilesToCompress = "FilesToCompress";

ZipService zipService = new();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Create Zip");
Console.WriteLine("----------");

var createdZipFile = "FilesCompressed/ZipFile.zip";
zipService.CreateZip(directoryFilesToCompress, createdZipFile);

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Arquivo Zip criado com sucesso!");
Console.WriteLine();


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Add File To Zip");
Console.WriteLine("---------------");

var fileToAdd = "FileToAdd/MaryJane.txt";
zipService.AddFileToZip(createdZipFile, fileToAdd);

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Arquivo adicionado ao arquivo Zip com sucesso!");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Remove File From Zip");
Console.WriteLine("--------------------");

var fileToRemove = "BenParker.txt";
zipService.RemoveFileFromZip(createdZipFile, fileToRemove);

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Arquivo removido do arquivo Zip com sucesso!");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Extract Zip");
Console.WriteLine("-----------");

var extractPath = "FilesDecompressed";
zipService.ExtractZip(createdZipFile, extractPath);

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Arquivos extraídos com sucesso!");