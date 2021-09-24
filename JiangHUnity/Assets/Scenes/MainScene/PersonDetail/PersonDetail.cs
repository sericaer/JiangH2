using JiangH;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PersonDetail : MonoBehaviour
{

    public IPerson gmData { get; internal set; }

    public GameObject prefabPanelSelectBusiness;

    public Text businessCount;

    public Text Name;


    public void OnClose()
    {
        Destroy(this.gameObject);
    }


    void Start()
    {
        GetComponentInChildren<PersonInteractive>().gmData = gmData;
    }

    //public void OnRevokeBusiness()
    //{
    //    var gmObj = Instantiate(prefabPanelSelectBusiness, this.transform.root.GetComponentInChildren<Canvas>().transform);
    //    if (gmObj != null)
    //    {
    //        gmObj.GetComponentInChildren<SelectBusiness>().DataSource.AddRange(gmData.businesses);
    //        gmObj.GetComponentInChildren<SelectBusiness>().OnConfirmSelect = (selectBusiness) =>
    //        {
    //            foreach (var business in selectBusiness)
    //            {
    //                Facade.system.relationPersonBusiness.RemoveRelation(gmData, business);
    //                Facade.system.relationPersonBusiness.AddRelation(Facade.player, business);
    //            }

    //        };
    //    }
    //}

    //public void OnAssignBusiness()
    //{
    //    var gmObj = Instantiate(prefabPanelSelectBusiness, this.transform.root.GetComponentInChildren<Canvas>().transform);
    //    if (gmObj != null)
    //    {
    //        gmObj.GetComponentInChildren<SelectBusiness>().DataSource.AddRange(Facade.player.businesses);
    //        gmObj.GetComponentInChildren<SelectBusiness>().OnConfirmSelect = (selectBusiness) =>
    //        {
    //            foreach (var business in selectBusiness)
    //            {
    //                Facade.system.relationPersonBusiness.RemoveRelation(Facade.player, business);
    //                Facade.system.relationPersonBusiness.AddRelation(gmData, business);
    //            }
    //        };
    //    }
    //}

    //void Update()
    //{
    //    if (gmData == null)
    //    {
    //        return;
    //    }

    //    businessCount.text = gmData.businesses.Count().ToString();
    //    Name.text = gmData.fullName;

    //    if(gmData == Facade.player)
    //    {
    //        btnRevokeBusiness.gameObject.SetActive(false);
    //        btnAssignBusiness.gameObject.SetActive(false);
    //    }
    //}
}