using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject Needle;
    public float playerVelo;
    public Image[] BuyPartsIcons;
    public Sprite[] BuyPartsSprites;

    public int PlayerLaps;
    public int AILaps;

    public void MoveNeedle()
    {
        playerVelo = GameManager.Instance.Player()._rigidBody.velocity.magnitude * 3.6f ;
        float needleRotation = playerVelo * (-2.0f);

        Needle.transform.eulerAngles = new Vector3(0, 0, needleRotation);
    }

    public void AddPartsIcon()
    {
        int partIconIndex = 0;

        string[] buyPartsName = { "DesertWheel", "MountainWheel", "CityWheel", "SixCylinder", "EightCylinder" };
        for (int i = 0; i < buyPartsName.Length; i++)
        {   
            string newPartName = buyPartsName[i].Substring(0, buyPartsName[i].Length - 7);
            GameObject buyPart = GameObject.Find(newPartName);

            if (buyPart != null)
            {
                BuyPartsIcons[partIconIndex].gameObject.SetActive(true);
                BuyPartsIcons[partIconIndex].sprite = BuyPartsSprites[i];

                if(partIconIndex < BuyPartsSprites.Length - 1)
                    partIconIndex++;
            }
        }
    }


}
