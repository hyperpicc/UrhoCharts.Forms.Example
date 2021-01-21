using System;
using System.Threading;
using BitMiracle.LibJpeg;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UrhoCharts.Forms.Example.Models
{
    public class ChartSamples
    {
        public SurfaceChart Sample1 { get; set; }
        public SurfaceChart Sample2 { get; set; }

        public ChartSamples()
        {
            // Sample 1
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var streamImageSource = ImageSource.FromResource("UrhoCharts.Forms.Example.Resources.sample1.jpg") as StreamImageSource;
                using (var imageStream = await streamImageSource.Stream(CancellationToken.None))
                {
                    var jpegImage = new JpegImage(imageStream);
                    var imageData = new byte[jpegImage.Width * jpegImage.Height];
                    for (var i = 0; i < jpegImage.Height; i++)
                    {
                        var row = jpegImage.GetRow(i);
                        Buffer.BlockCopy(src      : row.ToBytes(),
                                         srcOffset: 0,
                                         dst      : imageData,
                                         dstOffset: (i * jpegImage.Width),
                                         count    : jpegImage.Width);
                    }

                    Sample1 = new SurfaceChart
                    {
                        XSize = jpegImage.Width,
                        YSize = jpegImage.Height,
                        ZData = imageData,
                    };
                }
            });

            // Sample 2
            Sample2 = new SurfaceChart
            {
                XSize = 100,
                YSize = 100,
            };

            Sample2.ZData = new byte[Sample2.XSize * Sample2.YSize];
            for (var x = 0; x < Sample2.XSize; x++)
            {
                for (var y = 0; y < Sample2.YSize; y++)
                {
                    Sample2.ZData[x * Sample2.XSize + y]
                        = (byte) (240 * ((Math.Sin(x * Math.PI / Sample2.XSize) * Math.Cos(y * Math.PI / Sample2.YSize) + 1) / 2) + 8);
                }
            }
        }
    }
}