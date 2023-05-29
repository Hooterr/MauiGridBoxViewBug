using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGridBug;

public partial class CollectionView : ContentPage
{
    private ObservableCollection<int> _list = new();
    public CollectionView()
    {
        InitializeComponent();
        _list = new ObservableCollection<int>(Enumerable.Range(0, 100));
        coll.ItemsSource = _list;
    }

    private async void Coll_OnRemainingItemsThresholdReached(object sender, EventArgs e)
    {
        await Task.Delay(1000);
        Device.BeginInvokeOnMainThread(() =>
        {
            foreach (var a in Enumerable.Range(0, 50))
            {
                _list.Add(a);
            }
        });
        
    }
}