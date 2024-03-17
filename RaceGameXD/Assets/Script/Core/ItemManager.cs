using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public virtual void OnGetItem(PlayerController player)
    {

    }
}

public class ItemManager : MonoBehaviour
{   
    public GameObject[] SpeedUPItems;
    public GameObject[] Cointems;

    public void SpawnItem()
    {
        foreach(Transform spawnPoint in GameManager.Instance.WayPoints.transform)
        {
            if(Random.Range(0, 3) == 0)
            {
                Instantiate(SpeedUPItems[Random.Range(0, SpeedUPItems.Length)], spawnPoint.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
            }
                Instantiate(Cointems[Random.Range(0, Cointems.Length)], spawnPoint.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
        }
    }

    
}
