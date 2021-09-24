using JiangH;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIWidgets;

class SelectBusiness : ListViewCustom<SelectBusinessElement, IBusiness>
{
    public Button btnConfirm;

    internal IEnumerable<IBusiness> businesses;

    internal Action<IEnumerable<IBusiness>> OnConfirmSelect;

    public void OnCancel()
    {
        Destroy(this.transform.parent.gameObject);
    }

    public void OnConfirm()
    {
        OnConfirmSelect?.Invoke(SelectedItems);
        Destroy(this.transform.parent.gameObject);
    }

    protected override void Update() 
    {
        base.Update();
        btnConfirm.interactable = SelectedItems.Any();
    }
}