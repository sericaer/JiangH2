using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JiangH;

public class PlayerPanel : MonoBehaviour
{
    public IPerson gmData
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
    public Text Office;

    private IPerson _gmData;

    // Start is called before the first frame update
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

        Name.text = gmData.fullName;
    }
}
