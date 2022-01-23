using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.ViewModels.Statitics
{
    public class ThongKeVM<T>
    {
        public List<T> Items { get; set; }
        public string UrlDownload { get; set; }
        public int TongDoanhThu { get; set; }
    }
}
