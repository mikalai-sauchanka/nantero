using System;

namespace Pactas.SDK.DTO
{
    public class BackupSettingsDTO
    {
        public bool EnableBackup { get; set; }
        public string Password { get; set; }
        public string S3Host { get; set; }
        public string AccessKey { get; set; }
        public string SecretAccessKey { get; set; }
        public string BucketName { get; set; }
    }

    public class BackupSettingsReadDTO : BackupSettingsDTO
    {
        public bool SettingsValid { get; set; }
        public DateTime LastSuccessfulBackup { get; set; }
    }
}
