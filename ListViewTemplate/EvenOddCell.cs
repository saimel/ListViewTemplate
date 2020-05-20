// EvenOddCell.cs
//
// Author: Saimel Saez ssaez@magaya.com
//
// 5/20/2020
//
//

using System.Collections;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace ListViewTemplate
{
    public class EvenOddCell : ViewCell
    {
        public Color EvenBackgroundColor
        {
            get => (Color)GetValue(EvenBackgroundColorProperty);
            set => SetValue(EvenBackgroundColorProperty, value);
        }

        public Color OddBackgroundColor
        {
            get => (Color)GetValue(OddBackgroundColorProperty);
            set => SetValue(OddBackgroundColorProperty, value);
        }

        public IList ContainerItemsSource
        {
            get => (IList)GetValue(ContainerItemsSourceProperty);
            set => SetValue(ContainerItemsSourceProperty, value);
        }

        public static BindableProperty EvenBackgroundColorProperty = BindableProperty.Create(
            nameof(EvenBackgroundColor), typeof(Color), typeof(EvenOddCell), default(Color));

        public static BindableProperty OddBackgroundColorProperty = BindableProperty.Create(
            nameof(OddBackgroundColor), typeof(Color), typeof(EvenOddCell), default(Color));

        public static BindableProperty ContainerItemsSourceProperty = BindableProperty.Create(
            nameof(ContainerItemsSource), typeof(IList), typeof(EvenOddCell),
            default(IList), propertyChanged: OnContainerItemsSourcePropertyChanged);

        private static void OnContainerItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null && newValue is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)newValue).CollectionChanged += (s, e) =>
                {
                    if (e.Action != NotifyCollectionChangedAction.Add)
                    {
                        ((EvenOddCell)bindable).OnBindingContextChanged();
                    }
                };
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null && ContainerItemsSource is IList)
            {
                var idx = ContainerItemsSource.IndexOf(BindingContext);
                View.BackgroundColor = idx % 2 == 0 ? EvenBackgroundColor : OddBackgroundColor;
            }
        }
    }
}
