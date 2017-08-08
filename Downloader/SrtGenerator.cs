﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Downloader.Helpers.Subtitels;

namespace Downloader
{
    public class SrtGenerator
    {
        public string RawString { get; }
        public List<SubtitleItem> Items { get; }
        public bool HardOfHearing { get; }
        private string DownloadString(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return null;

            using (var webClient = new WebClient { Encoding = Encoding.UTF8 })
                return webClient.DownloadString(uri);

        }
        public SrtGenerator(Uri url)
        {
            HardOfHearing = url.ToString().Contains("HardOfHearing");
            RawString = DownloadString(url.ToString());
            Items = new List<SubtitleItem>();
            Parse();
        }

        private void Parse()
        {

            var tasks = new List<Task>();

            List<SubtitleItem> Action(object obj) => new SrtParser().Parse(DownloadString((string)obj));

            var urls = RawString.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Where(e => e.StartsWith("http://www.dr.dk/mu-online/"));

            foreach (var line in urls)
                tasks.Add(Task.Factory.StartNew(Action, line)
                    .ContinueWith(elements => Items.AddRange(elements.Result)));

            Task.WaitAll(tasks.ToArray());
        }

        public void SaveToFile(string fileName)
        {
            if (HardOfHearing)
            {
                var extention = Path.GetExtension(fileName) ?? ".srt";
                fileName = fileName.Replace(extention, "_DKSubs" + extention);
            }

            var count = 1;
            if (Items.Any())
                File.WriteAllLines(fileName, Items.OrderBy(e => e.StartTime).Select(element => count++ + Environment.NewLine + element));
        }
    }
}
