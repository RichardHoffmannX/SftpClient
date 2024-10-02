// See https://aka.ms/new-console-template for more information
using Renci.SshNet;
using System.Text;

Console.WriteLine("Hello, SFTP Uploader");

// 1. Add NuGet package "Renci SSH.NET"
//   a. Visial Studio: Right click on project name "SFTPUploader" and select "Manage NuGet Packages..."
//   b. Search and install "SSH.NET"

// 2. Load file
string fileToUploadPath = "C:\\test.txt";

string fileName = Path.GetFileName(fileToUploadPath);
string fileContents = File.ReadAllText(fileToUploadPath);
byte[] fileData = Encoding.ASCII.GetBytes(fileContents);

// 3. Upload file

using(var client = new SftpClient(
    // Option 1: Decrypted
    // ConfigService.sFtpHost.Decrypt(),
    // ConfigService.sFtpPort,
    // ConfigService.sFtpUsername.Decrypt(),
    // ConfigService.sFtpPassword.Decrypt()

    // Option 2: Plain
    ConfigService.sFtpHost,
    ConfigService.sFtpPort,
    ConfigService.sFtpUsername,
    ConfigService.sFtpPassword
    ))
{
    client.Connect();
    if (client.IsConnected)
    {
        client.ChangeDirectory($"{ConfigService.sFtpPath}");
        using (var fileStream = new MemoryStream(fileData))
        {
            client.UploadFile(fileStream, fileName);
        }
        Console.WriteLine($"{fileName} uploded successfully! You are awesome!");
    }
    else
    {
        Console.WriteLine($"Wait! What?");
    }
}
