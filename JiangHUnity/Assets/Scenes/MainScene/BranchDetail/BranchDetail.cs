using JiangH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BranchDetail : MonoBehaviour
{
    public IBranch gmData { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if(gmData !=  null)
        {
            //GetComponentInChildren<PersonTable>().gmData = gmData.persons;
            GetComponentInChildren<BusinessTable>().gmData = gmData.businesses;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClose()
    {
        Destroy(this.gameObject);
    }

    //public void OnCreateBranch()
    //{
    //    string rslt;
    //    var branch = Facade.CreateBranch(DateTime.Now.ToString(), out rslt);

    //    Facade.system.relationBranchSociety.AddRelation(branch, gmData);
    //}
}
