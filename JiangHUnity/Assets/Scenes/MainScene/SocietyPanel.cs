using JiangH;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SocietyPanel : MonoBehaviour
{
    public ISociety gmData { get; internal set; }

    public Text Name;
    public Text BusinessCount;
    public Text PersonCount;

    public GameObject prefabPanelBranch;
    public GameObject prefabPanelDetail;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gmData == null)
        {
            return;
        }

        Name.text = gmData.name;
        BusinessCount.text = gmData.businesses.Count().ToString();
        PersonCount.text = gmData.persons.Count().ToString();

        //Branch.text = gmData.branches.Count().ToString();
    }

    public void OnClickDetail()
    {
        var gmObj = Instantiate(prefabPanelDetail, this.transform.root.GetComponentInChildren<Canvas>().transform);
        if (gmData != null)
        {
            gmObj.GetComponent<SocietyDetail>().gmData = gmData;
        }
    }
}