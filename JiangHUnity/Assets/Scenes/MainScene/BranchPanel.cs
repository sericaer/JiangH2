﻿using System.Collections;
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

        //Name.text = gmData.name;
        //Businesses.text = $"{gmData.businesses.Count()}/{gmData.owner.maxBusinessCount}";
    }
}