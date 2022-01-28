using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;

namespace CustomBackplane
{

    // File: FilesystemMessageBus.cs
    public class FileSystemMessageBus : ScaleoutMessageBus
    {
        // Uses the folder %temp%/backplane
        private readonly string BasePath =
                        Path.Combine(Path.GetTempPath(), "Backplane");
        private FileSystemWatcher _watcher;

        public FileSystemMessageBus(IDependencyResolver resolver,
                                    ScaleoutConfiguration configuration)
            : base(resolver, configuration)
        {
            Open(0); // Use only one stream
            if (Directory.Exists(BasePath))
            {
                var files = new DirectoryInfo(BasePath).GetFiles();
                foreach (var file in files)
                {
                    file.Delete();
                }
            }
            else Directory.CreateDirectory(BasePath);

            _watcher = new FileSystemWatcher(BasePath, "*.txt")
            {
                IncludeSubdirectories = false,
                EnableRaisingEvents = true
            };
            _watcher.Created += FileCreated;
        }

        // Process messages sent from the backplane to the server
        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            byte[] bytes;
            while (true)
            {
                try
                {
                    bytes = File.ReadAllBytes(e.FullPath);
                    break;
                }
                catch                 // The file is still in use
                {
                    Thread.Sleep(10); // Let's wait for a short while
                }                     // and try again
            }
            var scaleoutMessage = ScaleoutMessage.FromBytes(bytes);
            ulong id;
            string fileName = Path.GetFileNameWithoutExtension(e.Name);
            ulong.TryParse(fileName, out id);
            foreach (var message in scaleoutMessage.Messages)
            {
                OnReceived(0, id,
                      new ScaleoutMessage(new[] { message }));
            }
        }

        // Send messages from the server to the backplane
        protected override Task Send(int streamIndex,
                                        IList<Message> messages)
        {
            return Task.Factory.StartNew(() =>
            {
                var bytes = new ScaleoutMessage(messages).ToBytes();
                var filePath = BasePath + "\\" +
                               DateTime.Now.Ticks + ".txt";

                File.WriteAllBytes(filePath, bytes);
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _watcher.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}