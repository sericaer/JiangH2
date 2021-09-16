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

    public Text Name;
    public Text Businesses;
    public Text Money;

    public GameObject prefabPanelBussiness;

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

        Name.text = gmData.name;
        Businesses.text = $"{gmData.businesses.Count()}/{gmData.owner.maxBusinessCount}";

        var money = gmData.products.SingleOrDefault(x => x.type == ProductType.Money);
        Money.text = money == null ? "0" : money.value.ToString();
    }

    public void OnBusinessClick()
    {
        var gmObj = Instantiate(prefabPanelBussiness, this.transform.root.GetComponentInChildren<Canvas>().transform);
        if (_gmData != null)
        {
            gmObj.GetComponent<BusinessTable>().gmData = _gmData.businesses;
        }
    }
}