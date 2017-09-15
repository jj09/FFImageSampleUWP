using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FFImageSample.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var svgString = @"<svg x='0px' y='0px' width='160px' height='155px' viewBox='0 0 160 155' enable-background='new 0 0 160 155'><g><polygon fill='#E9EBED' points='59.3,56.4 80.5,4 101.5,56.2 157.3,59.8 114.5,96.4 128.3,150.8 80.3,120.8 32.3,151 46.1,96 2.7,59.8'/><polygon fill='#E3E6E8' points='109.405,56.71 157.3,59.8 114.5,96.4 128.3,150.8 80.3,120.8 32.3,151 42.753,109.339   '/></g></svg>";

            ImageService.Instance
                           //.LoadUrl(svgString)
                           .LoadStream(ct => Task.FromResult<Stream>(new MemoryStream(Encoding.UTF8.GetBytes(svgString))))
                           .WithCustomDataResolver(new SvgDataResolver(100, 0, true))
                           .WithCustomLoadingPlaceholderDataResolver(new SvgDataResolver(100, 0, true))
                           .Into(MyImg);
        }
    }
}
