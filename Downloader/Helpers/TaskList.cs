using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Downloader.Helpers
{
    public class TaskList : BindingList<string>
    {
        private static TaskList _instance;

        private TaskList()
        {
            Task.Run(() => SaveFfMpeg());
        }

        public static TaskList Instance { get; } = _instance ?? (_instance = new TaskList());

        // ReSharper disable once InconsistentNaming
        public static string FFMPEG_FILENAME => string.Concat(Path.GetTempPath(), "ffmpeg.exe");

        private static bool DeleteFfMpeg()
        {
            if (File.Exists(FFMPEG_FILENAME))
                try
                {
                    File.Delete(FFMPEG_FILENAME);
                    return true;
                }
                catch
                {
                    //
                }
            return false;
        }

        private static void SaveFfMpeg()
        {
            if (!DeleteFfMpeg())
                return;

            using (var fileStream = new FileStream(FFMPEG_FILENAME, FileMode.Create))
            {
                var stream = Assembly.GetCallingAssembly().GetManifestResourceStream("Downloader.ffmpeg.exe");
                stream?.CopyTo(fileStream);
            }
        }

        ~TaskList()
        {
            DeleteFfMpeg();
        }

        private void DoAddtask(string url, string destinationDirectory)
        {
            if (Contains(url))
                return;

            Add(url);
            var ctx = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew(() => new MovieInformation(url).Save(destinationDirectory))
                .ContinueWith(_ => Remove(url), ctx);
        }

        public static void Addtask(string url, string destinationDirectory, Func<string, bool> validate)
        {
            if (validate(url))
                Instance.DoAddtask(url, destinationDirectory);
        }
    }
}