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
    public List<GameObject> Items;

    public void SpawnItem()
    {
        foreach(Transform spawnPoint in GameManager.Instance.WayPoints.transform)
        {
            if(Random.Range(0, 3) == 0)
            {
                Instantiate(Items[Random.Range(0, Items.Count)], spawnPoint.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
            }
        }
    }

    
}
