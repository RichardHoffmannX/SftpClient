// See https://aka.ms/new-console-template for more information
public static class ConfigService
{
    static ConfigService() {}

    public static string sFtpHost { get; set; } = "ftp.com.org";
    public static string sFtpPath { get; set; } = "/data/folder";
    public static string sFtpUsername { get; set; } = "Username";
    public static string sFtpPassword { get; set; } = "Password";

    public static int sFtpPort { get; set; } = 22;
}