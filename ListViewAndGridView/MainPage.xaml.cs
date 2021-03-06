﻿using ListViewAndGridView.Models;
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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ListViewAndGridView
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
            ObservableCollection<RootDataModel> picModels = new ObservableCollection<RootDataModel>();
            //json文件的url
            Uri uri = new Uri("ms-appx:///Assets/Data.json");
            var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            //读取的json文本
            string text = await Windows.Storage.FileIO.ReadTextAsync(file);
            //然后反序列化成类
            RootDataModel wallPaperModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RootDataModel>(text);
           
            Lv.ItemsSource = wallPaperModel.data.datas;
        }
    }
}
