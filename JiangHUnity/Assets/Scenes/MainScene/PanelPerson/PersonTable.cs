using JiangH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PersonTable : MonoBehaviour
{
    public GameObject prefabPanelPersonDetail;

    public class PersonInfo
    {
        public string name => data.fullName;

        public string branch => data.branch != null ? data.branch.name : "--";


        public readonly IPerson data;

        public Action<IPerson> ActionDetail;

        public void OnDetail()
        {
            ActionDetail(data);
        }

        public PersonInfo(IPerson data)
        {
            this.data = data;
        }
    }

    public IEnumerable<PersonInfo> personInfos => _personInfos;

    public IEnumerable<IPerson> gmData { get; set; }


    private List<PersonInfo> _personInfos = new List<PersonInfo>();

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

        for(int i=0; i< _personInfos.Count(); i++)
        {
            if (!gmData.Contains(_personInfos[i].data))
            {
                _personInfos.RemoveAt(i);
            }
        }

        foreach(var elem in gmData)
        {
            if(!_personInfos.Any(x=>x.data == elem))
            {
                var info = new PersonInfo(elem);
                info.ActionDetail = (person) =>
                {
                    var gmObj = Instantiate(prefabPanelPersonDetail, this.transform.root.GetComponentInChildren<Canvas>().transform);
                    gmObj.GetComponent<PersonDetail>().gmData = person;
                };

                _personInfos.Add(info);
            }
        }
        
    }
}
