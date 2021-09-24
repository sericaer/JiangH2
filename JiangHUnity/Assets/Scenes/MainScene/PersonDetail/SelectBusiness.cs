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

    public void OnConfirm()
    {
        OnConfirmAction?.Invoke(listView.SelectedItems);
        Destroy(this.gameObject);
    }

    void Start()
    {
        listView.OnDeselectObject.AddListener((index) =>
        {
            btnConfirm.interactable = listView.SelectedItems.Any();
        });

        listView.OnSelectObject.AddListener((index) =>
        {
            btnConfirm.interactable = listView.SelectedItems.Any();
        });
    }

}