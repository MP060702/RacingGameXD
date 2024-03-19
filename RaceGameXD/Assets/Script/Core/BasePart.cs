using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;

public class BasePart : MonoBehaviour
{
    public virtual void GetPart(int needMoney)
    {
       GameObject part = this.gameObject;
        if (GameInstance.Instance.Money >= needMoney)
        {
            if (GameInstance.Instance.Parts.Contains(part) == false)
            {
                GameInstance.Instance.Money -= needMoney;
                Debug.Log(GameInstance.Instance.Money);
                GameInstance.Instance.Parts.Add(part);
                Debug.Log("Add : " + part);
            }
        }
    }
}
