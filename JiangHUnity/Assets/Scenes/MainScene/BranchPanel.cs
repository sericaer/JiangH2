using System.Collections;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

using JiangH;

public class BranchPanel : MonoBehaviour
{
    public IBranch gmData
    {
        get
        {
            return _gmData;
        }
        set
        {
            _gmData = value;
        }
    }

    public Text Businesses;
    public Text Person;
    public Text Money;

    public GameObject prefabPanelDetail;
    //public GameObject prefabPanelPersons;

    private IBranch _gmData;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gmData == null)
        {
            return;
        }

        Businesses.text = $"{gmData.businesses.Count()}/{gmData.owner.maxBusinessCount}";

        var money = gmData.products.SingleOrDefault(x => x.type == ProductType.Money);
        Money.text = money == null ? "0" : money.value.ToString();

        Person.text = gmData.persons.Count().ToString();
    }

    public void OnClickDetail()
    {
        var gmObj = Instantiate(prefabPanelDetail, this.transform.root.GetComponentInChildren<Canvas>().transform);
        if (gmData != null)
        {
            gmObj.GetComponent<BranchDetail>().gmData = gmData;
        }
    }
    //public void OnBusinessClick()
    //{
    //    var gmObj = Instantiate(prefabPanelBussiness, this.transform.root.GetComponentInChildren<Canvas>().transform);
    //    if (_gmData != null)
    //    {
    //        gmObj.GetComponent<BusinessTable>().gmData = _gmData.businesses;
    //    }
    //}

    //public void OnPersonClick()
    //{
    //    var gmObj = Instantiate(prefabPanelPersons, this.transform.root.GetComponentInChildren<Canvas>().transform);
    //    if (_gmData != null)
    //    {
    //        gmObj.GetComponent<PersonTable>().gmData = _gmData.persons;
    //    }
    //}
}