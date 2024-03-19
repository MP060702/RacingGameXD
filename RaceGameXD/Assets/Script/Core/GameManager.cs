using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    public GameObject PlayerObj;

    public Transform WayPoints;

    public AIEnemySpawner _AIEnemySpawner;
    public ItemManager _ItemManager;
    public UIManager _UIManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _AIEnemySpawner = GetComponent<AIEnemySpawner>();
        _ItemManager = GetComponent<ItemManager>();
        _UIManager = GetComponent<UIManager>();
        RaceStart();
    }

    private void Update()
    {
        _UIManager.MoveNeedle();
    }

    public PlayerController Player() { return PlayerObj.GetComponent<PlayerController>(); }

    public void RaceStart()
    {
        _ItemManager.StartItemSpawn();
    }

}
