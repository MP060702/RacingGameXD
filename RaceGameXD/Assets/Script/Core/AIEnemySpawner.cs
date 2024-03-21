using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemySpawner : MonoBehaviour
{
    public GameObject ReverseDashEnemy;
    public GameObject FowardDashEnemy;

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);

        int enemyCount = UnityEngine.Random.Range(1, 3);
        for (int i = 0; i < enemyCount; i++)
        {
            int enemyType = UnityEngine.Random.Range(0, 2);
            switch (enemyType)
            {
                case 0:
                    SpawnFowardDashAI();
                    break;
                case 1:
                    SpawnReverseDashAI();
                    break;
            }
        }

        yield return new WaitForSeconds(5f);
    }

    public void SpawnReverseDashAI()
    {   
        
        int SpawnIndex = GameManager.Instance.Player().WayIndex + UnityEngine.Random.Range(2, 3);

        if (SpawnIndex >= GameManager.Instance.WayPoints.childCount)
        {
            SpawnIndex %= GameManager.Instance.WayPoints.childCount;
        }

        GameObject spawnedEnemy = Instantiate(ReverseDashEnemy, GameManager.Instance.Player().WayPoints.GetChild(SpawnIndex).position, Quaternion.identity);

        ReverseDashAI reverseDashAiInfo = spawnedEnemy.GetComponent<ReverseDashAI>();
        reverseDashAiInfo.WayIndex = SpawnIndex;
    }

    public void SpawnFowardDashAI()
    {
        int SpawnIndex = GameManager.Instance.Player().WayIndex - 1;

        if(SpawnIndex <= 0)
        {
            SpawnIndex = GameManager.Instance.WayPoints.childCount;
        }
        
        GameObject spawnedEnemy = Instantiate(FowardDashEnemy, GameManager.Instance.Player().WayPoints.GetChild(SpawnIndex).position, Quaternion.identity);

        ForwardDashAI fowardDashAiInfo = spawnedEnemy.GetComponent<ForwardDashAI>();
        fowardDashAiInfo.WayIndex = SpawnIndex;
    }
}