using JiangH;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIWidgets;

class SelectBusiness : MonoBehaviour
{
    public BusinessListView listView;
    public Text desc;
    public Button btnConfirm;

    public Action<IEnumerable<IBusiness>> OnConfirmAction;

    public IEnumerable<IBusiness> gmData { get; internal set; }

    public void OnConfirm()
    {
        OnConfirmAction?.Invoke(listView.SelectedItems);
    }

    void Update()
    {
        if(gmData == null)
        {
            return;
        }

        var needRemoves = listView.DataSource.Except(gmData);
        foreach(var remove in needRemoves)
        {
            listView.Remove(remove);
        }
        
        var needAdds = gmData.Except(listView.DataSource);
        foreach (var add in needAdds)
        {
            listView.Add(add);
        }

        btnConfirm.interactable = listView.SelectedItems.Any();
    }

}