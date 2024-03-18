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
    public GameObject[] CoinItems;

    public void StartItemSpawn()
    {
        SpawnCoinItems();

        return;

        foreach (Transform spawnPoint in GameManager.Instance.WayPoints.transform)
        {
            GameObject spawnObject = null;
            if (Random.Range(0, 3) == 0)
                spawnObject = SpeedUPItems[Random.Range(0, 3)];
            else
                SpawnCoinItems();
        }

    }

    private void SpawnSpeedUpItems()
    {

    }

    private void SpawnItem(GameObject prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }

    private void SpawnCoinItems()
    {
        //Transform Waypoints = GameManager.Instance.WayPoints;
        //for (int i = 0; i < Waypoints.childCount; i++)
        //{
        //    for (int j = 0; j < 4; j++)
        //    {
        //        int nextIndex = i + 1;

        //        if (i == Waypoints.childCount - 1)
        //            nextIndex = 0;

        //        Vector3 dir =
        //            Waypoints.GetChild(nextIndex).transform.position - Waypoints.GetChild(i).transform.position;
        //        dir.Normalize();

        //        Vector3 currentPosition = Waypoints.GetChild(i).transform.position;
        //        Vector3 spawnPosition = dir * j * 4;
        //        dir.y = 0;

        //        SpawnItem(Cointems[0], currentPosition + spawnPosition);

        //    }
        //}

        Transform Waypoints = GameManager.Instance.WayPoints;// WayPoint에 게임매니저에 Waypoints값을 넣는다
        for (int i = 0; i < Waypoints.childCount; i++) // 반복문 i의 값을 0으로 해주고, WayPoints의 자식개수보다 적다면 i에 1을 더한다
        {
            for (int j = 0; j < 4; j++)
            {
                int nextIndex = i + 1;

                if (i == Waypoints.childCount - 1)
                {
                    nextIndex = 0;
                }

                Vector3 dir = Waypoints.GetChild(nextIndex).transform.position - Waypoints.GetChild(i).transform.position;
                dir.Normalize();

                Vector3 currentPosition = Waypoints.GetChild(i).transform.position;
                Vector3 spawnPosition = dir * j * 4;

                SpawnItem(CoinItems[0], currentPosition + spawnPosition);
            }
        }


    }
}