// "Живая" реакция на изменения в файловой системе

using System;
using System.IO;
using System.Reactive.Linq;

namespace LivingSystemWatcher
{
   internal static class Program
   {
      private const string WatchingFolder = @"d:\CSharpAnalyzerTester";

      private static void Main()
      {
         var watcher = new FileSystemWatcher(WatchingFolder) { EnableRaisingEvents = true };

         var fileCreated = Observable.FromEventPattern<FileSystemEventArgs>(watcher, "Created").Select(eventPattern =>
         {
            var args = eventPattern.EventArgs;
            var fileInfo = new FileInfo(args.FullPath);
            return new
            {
               args.FullPath,
               Created = args.ChangeType,
               args.Name,
               fileInfo.DirectoryName
            };
         });

         var fileChanged =
            Observable.FromEventPattern<FileSystemEventArgs>(watcher, "Changed").Select(eventPattern => new
            {
               eventPattern.EventArgs.FullPath,
               eventPattern.EventArgs.ChangeType
            });

         var fileRenamed = Observable.FromEventPattern<RenamedEventArgs>(watcher, "Renamed").Select(eventPattern => new
         {
            eventPattern.EventArgs.OldFullPath,
            NewPath = eventPattern.EventArgs.FullPath,
            eventPattern.EventArgs.ChangeType
         });

         fileCreated.Subscribe(obj => Console.WriteLine("Created: {0}", obj));
         fileChanged.Subscribe(obj => Console.WriteLine("Changed: {0}", obj));
         fileRenamed.Subscribe(obj => Console.WriteLine("Renamed: {0}", obj));

         Console.ReadLine();
      }
   }
}