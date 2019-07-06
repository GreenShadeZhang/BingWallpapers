using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewAndGridView.Models
{
    public class RootDataModel
    {
        public string stat { get; set; }
        public string msg { get; set; }
        public SonData data { get; set; }
    }

    public class SonData
    {
        public Info info { get; set; }
        public ObservableCollection<Son> datas { get; set; }
        public object[] promotions { get; set; }
    }

    public class Info
    {
        public string update_date { get; set; }
    }

    public class Son
    {
        public string pk { get; set; }
        public string title { get; set; }
        public string stitle { get; set; }
        public string pics { get; set; }
        public string is_end { get; set; }
        public string list_icon { get; set; }
        public string list_stitle { get; set; }
        public string father_id { get; set; }
        public string p_pk { get; set; }
        public ObservableCollection<Son> sons { get; set; }
        public string skey { get; set; }
        public string token { get; set; }
        public string api_url { get; set; }
        public string block_bg_color { get; set; }
        public string data_type { get; set; }
        public string require_web { get; set; }
        public string pic { get; set; }
    }
}
