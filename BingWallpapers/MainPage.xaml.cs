using BingWallpapers.Models;
using BingWallpapers.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace BingWallpapers
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //此集合为GridView的source
            ObservableCollection<WallpapersDetail> picModels = new ObservableCollection<WallpapersDetail>();
            //json文件的url
            //Uri uri = new Uri("ms-appx:///Assets/file.json");
            //var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            ////读取的json文本
            //string text = await Windows.Storage.FileIO.ReadTextAsync(file);
            ////然后反序列化成类
            //WallpapersData wallPaperModel = Newtonsoft.Json.JsonConvert.DeserializeObject<WallpapersData>(text);

            WallpaperService wallpaperService = new WallpaperService();
            WallpapersData wallPaperModel = await wallpaperService.GetWallparper(1, 8);
            //通过重新组装成集合给GridView
            foreach (var item in wallPaperModel.images)
            {
                picModels.Add(new WallpapersDetail()
                {
                    Title = item.copyright,
                    Source = "https://www.bing.com" + item.url
                });
            }
            GV.ItemsSource = picModels;
        }
        /// <summary>
        /// 要保存的图片对象
        /// </summary>
        private WallpapersDetail wallpapers;
        private void MenuFlyout_Opening(object sender, object e)
        {
            var menuFlyout = sender as MenuFlyout;
            var gridViewItem = menuFlyout.Target as GridViewItem;
            wallpapers = gridViewItem.Content as WallpapersDetail;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Uri uri2 = new Uri(wallpapers.Source);
            var httpClientPicData = new HttpClient();
            var resBuffer = await httpClientPicData.GetBufferAsync(uri2);
            StorageFolder destinationFolder = await KnownFolders.PicturesLibrary.CreateFolderAsync("BingWallpapers", CreationCollisionOption.OpenIfExists);
            var destinationFile = await destinationFolder.CreateFileAsync("BingWallparpers"+DateTime.Now.Ticks + ".jpg", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBufferAsync(destinationFile, resBuffer);
        }
    }
}
