using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject Needle;
    public float playerVelo;
    public Image[] BuyPartsIcons;
    public Sprite[] BuyPartsSprites;
    public GameObject WarningObj;
    public GameObject ShopUI;


    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Laps;
    public TextMeshProUGUI GainItem;

    public int PlayerLaps;
    public int AILaps;

    public void MoveNeedle()
    {
        playerVelo = GameManager.Instance.Player()._rigidBody.velocity.magnitude * 3.6f ;
        float needleRotation = playerVelo * (-2.0f);

        Needle.transform.eulerAngles = new Vector3(0, 0, needleRotation);
    }

    private void Update()
    {
        TimeText();
        CountLaps();
    }

    public void AddPartsIcon()
    {
        int partIconIndex = 0;

        string[] buyPartsName = { "DesertWheel", "MountainWheel", "CityWheel", "SixCylinder", "EightCylinder" };
        for (int i = 0; i < buyPartsName.Length; i++)
        {
            //List<string> a = new List<string>();
            //a.Find(x => x.Contains("DesertWheel"));
            GameObject buyPart = GameObject.Find(buyPartsName[i] + "(Clone)");

            if (buyPart != null)
            {   
                BuyPartsIcons[partIconIndex].gameObject.SetActive(true);
                Debug.Log("ADDImage" +  buyPart);
                BuyPartsIcons[partIconIndex].sprite = BuyPartsSprites[i];

                if(partIconIndex < BuyPartsSprites.Length - 1)
                    partIconIndex++;
            }
        }
    }

    public void MarkItems(string item)
    {
        GainItem.text = "x " + item;
    }

    public void TimeText()
    {
        Timer.text = GameManager.Instance._startTime.ToString("F2") + " sec";
    }

    public void CountLaps()
    {
        Laps.text = PlayerLaps.ToString() + "/3";
    }

    public void WarningMark(bool isON)
    {
        WarningObj.SetActive(isON);
    }
    public void GoShop()
    {
        ShopUI.gameObject.SetActive(true);
    }

    public void GetOUtShop()
    {
        ShopUI.gameObject.SetActive(false);
        GameManager.Instance.Player().AddParts();
        AddPartsIcon();
    }
}
