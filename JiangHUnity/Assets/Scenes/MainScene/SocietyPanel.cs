﻿using JiangH;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SocietyPanel : MonoBehaviour
{
    public ISociety gmData { get; internal set; }

    public Text Name;
    public Text Business;

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
        Business.text = gmData.businesses.Count().ToString();
    }
}