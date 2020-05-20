// EvenOddTemplateSelector.cs
//
// Author: Saimel Saez ssaez@magaya.com
//
// 5/19/2020
//
//

using System.Collections;
using Xamarin.Forms;

namespace ListViewTemplate
{
    public class EvenOddTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }

        public DataTemplate OddTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var itemsView = (ListView)container;
            return ((IList)itemsView.ItemsSource).IndexOf(item) % 2 == 0 ? EvenTemplate : OddTemplate;
        }
    }
}
