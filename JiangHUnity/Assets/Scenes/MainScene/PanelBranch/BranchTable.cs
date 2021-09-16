using JiangH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class BranchTable : MonoBehaviour
{
    public GameObject prefabPanelPersonDetail;

    public class BranchInfo
    {
        public string name => data.name;
        public int business => data.businesses.Count();

        public int person => data.persons.Count();

        public readonly IBranch data;

        public Action<IBranch> ActionDetail;

        public void OnDetail()
        {
            ActionDetail(data);
        }

        public BranchInfo(IBranch data)
        {
            this.data = data;
        }
    }

    public IEnumerable<BranchInfo> branchInfos => _branchInfos;

    public IEnumerable<IBranch> gmData { get; set; }


    private List<BranchInfo> _branchInfos = new List<BranchInfo>();

    public void OnClose()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if(gmData == null)
        {
            return;
        }

        for(int i=0; i< _branchInfos.Count(); i++)
        {
            if (!gmData.Contains(_branchInfos[i].data))
            {
                _branchInfos.RemoveAt(i);
            }
        }

        foreach(var elem in gmData)
        {
            if(!_branchInfos.Any(x=>x.data == elem))
            {
                var info = new BranchInfo(elem);
                info.ActionDetail = (branch) =>
                {
                    var gmObj = Instantiate(prefabPanelPersonDetail, this.transform.root.GetComponentInChildren<Canvas>().transform);
                    gmObj.GetComponent<BranchDetail>().gmData = branch;
                };

                _branchInfos.Add(info);
            }
        }
        
    }
}
