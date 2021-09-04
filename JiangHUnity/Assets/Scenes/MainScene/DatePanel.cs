using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using JiangH;

public class DatePanel : MonoBehaviour
{
    public IDate gmData
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

    public Text text;

    private IDate _gmData;

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

        text.text = $"{gmData.value.y}-{gmData.value.m}-{gmData.value.d}";
    }
}