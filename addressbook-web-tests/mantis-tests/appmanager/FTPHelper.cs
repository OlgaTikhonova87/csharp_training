﻿using System;
using System.IO;
using System.Net.FtpClient;

namespace mantis_tests
{
    public class FTPHelper : HelperBase
    {
        private FtpClient client;

        public FTPHelper(mApplicationManager manager) : base(manager) 
        {
            client = new FtpClient();
            client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            client.Host = "localhost";
            client.Connect();
        }
        public void BackupFile (string path)
        {
            String backupPath = path + ".bak";
            if (client.FileExists(backupPath))
            {
                return;
            }

            //client.Rename(path, backupPath);
            
        }
        public void RestoreBackupFile(string path)
        {

            String backupPath = path + ".bak";
            if (!client.FileExists(backupPath))
            {
                return;
            }
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            client.Rename(backupPath,path);
        }
        public void Upload(string path, Stream localFile)
        {
            if (client.FileExists(path))
            {
                client.DeleteFile(path);
            }
            using(Stream ftpStream = client.OpenWrite(path))
            {
                byte[] buffer = new byte[8 * 1024];
               int count =  localFile.Read(buffer, 0, buffer.Length);
                while (count>0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
