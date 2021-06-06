using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoGioco.Gioco2
{
    [ContentProperty(nameof(Source))]
    public class MediaResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;
            var imageSource = ImageSource.FromResource(Source, typeof(MediaResourceExtension).GetTypeInfo().Assembly);
            return imageSource;
        }
        public static Stream GetStream(string fileName)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"ProgettoGioco.Gioco2.sounds.{fileName}");
            return stream;
        }
    }
}
