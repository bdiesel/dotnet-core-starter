using System.Collections.Generic;
using TestApp.Entities;

namespace TestApp.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<DataEntity> DataEntites { get; set; }
    }
}
