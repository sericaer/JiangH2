using JiangH;
using System;
using UnityEngine;

internal class PersonInteractiveUI : MonoBehaviour
{
    public InteractiveUI gmData;

    public object context;

    public Action<object> OnConfirm;
}

internal class SelectListUI : PersonInteractiveUI
{
    void Start()
    {

    }
}