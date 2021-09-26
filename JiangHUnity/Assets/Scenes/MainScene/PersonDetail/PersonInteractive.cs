using JiangH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIWidgets;
using UnityEngine;

public class PersonInteractive : MonoBehaviour
{
    public IPerson gmData { get; internal set; }

    public ListViewString listView;
    public GameObject OperationContent;

    public GameObject prefabBusinessSelect;

    Dictionary<string, InteractiveOperation> dict = new Dictionary<string, InteractiveOperation>();

    public void OnOperationSelected()
    {
        foreach (Transform child in OperationContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        var interactive = gmData.def.interactives.Single(x => x.title == listView.SelectedItem);
        if(interactive.ui == null)
        {
            interactive.Do(null);
            return;
        }

        var gmObj = Instantiate(Resources.Load(interactive.ui.uiName), OperationContent.transform) as GameObject;

        var interactiveUI = gmObj.GetComponentInChildren<PersonInteractiveUI>();
        interactiveUI.OnConfirm = (context)=>
        {
            interactive.Do(context);
            return;
        };
    }

    // Use this for initialization
    void Start()
    {
        foreach(var elem in gmData.def.interactives)
        {
            elem.Init(Facade.player, gmData);
            if(!elem.isTrigger(null))
            {
                continue;
            }

            listView.DataSource.Add(elem.title);
        }

        //dict["分配产业"] = new InteractiveOperation(
        //    isValid: () => gmData != Facade.player,
        //    Do: () =>
        //    {
        //        var gmObj = Instantiate(prefabBusinessSelect, OperationContent.transform);

        //        var selectBusiness = gmObj.GetComponentInChildren<SelectBusiness>();
        //        selectBusiness.gmData = Facade.player.businesses;

        //        selectBusiness.OnConfirmAction = (businesses) =>
        //        {
        //            foreach(var business in businesses)
        //            {
        //                Facade.system.relationPersonBusiness.RemoveRelation(Facade.player, business);
        //                Facade.system.relationPersonBusiness.AddRelation(gmData, business);
        //            }
        //        };
        //    }
        //);

        //dict["收回产业"] = new InteractiveOperation(
        //    isValid: () => gmData != Facade.player,
        //    Do: () =>
        //    {
        //        var gmObj = Instantiate(prefabBusinessSelect, OperationContent.transform);

        //        var selectBusiness = gmObj.GetComponentInChildren<SelectBusiness>();
        //        selectBusiness.gmData = gmData.businesses;

        //        selectBusiness.OnConfirmAction = (businesses) =>
        //        {
        //            foreach (var business in businesses)
        //            {
        //                Facade.system.relationPersonBusiness.RemoveRelation(gmData, business);
        //                Facade.system.relationPersonBusiness.AddRelation(Facade.player, business);
        //            }
        //        };
        //    }
        //);

        //listView.DataSource.AddRange(dict.Keys.Where(x => dict[x].isValid()));
    }

    class InteractiveOperation
    {
        public Func<bool> isValid;
        public Action Do;

        public InteractiveOperation(Func<bool> isValid, Action Do)
        {
            this.isValid = isValid;
            this.Do = Do;
        }
    }
}

