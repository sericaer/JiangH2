using JiangH;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PersonDetail : MonoBehaviour
{
    public IPerson gmData { get; internal set; }

    //public Dropdown branch;
    //public Text effecient;

    //public void OnClose()
    //{
    //    Destroy(this.gameObject);
    //}

    //public void OnChangedOwnerBranch(string branchName)
    //{
    //    var branch = Facade.branchs.Single(x => x.name == branchName);

    //    Facade.system.relationBranchBusiness.AddRelation(branch, gmData);
    //}

    //// Use this for initialization
    //void Start()
    //{
    //    branch.onValueChanged.AddListener((index) =>
    //    {
    //        var select = branch.options[index];
    //        OnChangedOwnerBranch(select.text);
    //    });

    //    //effecient.GetComponent<TooltipTrigger>().OnShowTooltip = (trigger) =>
    //    //{
    //    //    trigger.tooltip = string.Join("\n", gmData.efficientDetail.Select(x => $"{x.value} {x.desc}"));
    //    //};
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (gmData == null)
    //    {
    //        return;
    //    }

    //    UpdateBranch();
    //    UpdateEfficent();
    //}

    //private void UpdateEfficent()
    //{
    //    effecient.text = (100 + gmData.efficientDetail.Sum(x => x.value)).ToString();
    //}

    //private void UpdateBranch()
    //{
    //    foreach (var branch in Facade.branchs)
    //    {
    //        if (!this.branch.options.Any(x => x.text == branch.name))
    //        {
    //            this.branch.options.Add(new Dropdown.OptionData(branch.name));
    //        }
    //    }

    //    foreach (var option in branch.options)
    //    {
    //        if (Facade.branchs.All(x => x.name != option.text))
    //        {
    //            branch.options.Remove(option);
    //        }
    //    }

    //    var index = branch.options.FindIndex(x => x.text == gmData.branch.name);
    //    branch.SetValueWithoutNotify(index);
    //    branch.RefreshShownValue();
    //}
}