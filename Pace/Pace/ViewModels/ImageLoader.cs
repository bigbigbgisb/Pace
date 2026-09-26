using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pace.ViewModels
{
    public class ImageLoader
    {
        public async Task<Bitmap[]?> GetImagesAsync(string? rootPath)
        {
            List<Bitmap> bitmaps = [];
            if (string.IsNullOrEmpty(rootPath)) return null;
            var folderUri = new Uri($"avares://Pace/Assets/{rootPath}");
            var assets = AssetLoader.GetAssets(folderUri, null).OrderBy(x => x.ToString()).ToList();
            if (assets.Count == 0) return null;
            await Task.Run(() =>
            {
                foreach (var uri in assets)
                {
                    using var stream = AssetLoader.Open(uri);
                    if (stream is not null) bitmaps.Add(new Bitmap(stream));
                }
            });
            return [..bitmaps];

        }
    }
}
