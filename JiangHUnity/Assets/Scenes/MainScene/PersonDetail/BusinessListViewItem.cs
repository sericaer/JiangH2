using JiangH;
using UIWidgets;
using UnityEngine;

internal class BusinessListViewItem : ListViewItem, IViewData<IBusiness>
{
    [SerializeField]
    public TextAdapter Text;

    internal IBusiness gmData;

    public void SetData(IBusiness item)
    {
        gmData = item;
        Text.Value = item.name;
    }
}