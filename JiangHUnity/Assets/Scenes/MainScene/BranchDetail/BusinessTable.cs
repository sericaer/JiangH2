using JiangH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class BusinessTable : MonoBehaviour
{
    public class BussinessInfo
    {
        public string name => data.name;
        public double efficent => 100 + data.efficientDetail.Sum(x => x.value);

        public string product => string.Join(", ", data.productsCurr.Select(x => $"{x.type}:{x.value}"));

        public readonly IBusiness data;

        public Action<IBusiness> ActionDetail;

        public void OnDetail()
        {
            ActionDetail(data);
        }

        public BussinessInfo(IBusiness data)
        {
            this.data = data;
        }
    }

    public IEnumerable<BussinessInfo> businessInfos => _businessInfos;

    public IEnumerable<IBusiness> gmData { get; set; }

    public GameObject prefabPanelBussinessDetail;

    private List<BussinessInfo> _businessInfos = new List<BussinessInfo>();

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

        for(int i=0; i< _businessInfos.Count(); i++)
        {
            if (!gmData.Contains(_businessInfos[i].data))
            {
                _businessInfos.RemoveAt(i);
            }
        }

        foreach(var elem in gmData)
        {
            if(!_businessInfos.Any(x=>x.data == elem))
            {
                var info = new BussinessInfo(elem);
                info.ActionDetail = (business) =>
                {
                    var gmObj = Instantiate(prefabPanelBussinessDetail, this.transform.root.GetComponentInChildren<Canvas>().transform);
                    gmObj.GetComponent<BusinessDetail>().gmData = business;
                };

                _businessInfos.Add(info);
            }
        }
        
    }
}
