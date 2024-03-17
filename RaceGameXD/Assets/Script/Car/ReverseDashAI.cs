using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseDashAI : MonoBehaviour
{
    private CarMoveSystem carMoveSystem;

    public Transform TargetPoint;
    public int WayIndex;

    private void Start()
    {
        carMoveSystem = GetComponent<CarMoveSystem>();
        TargetPoint = GameManager.Instance.WayPoints.GetChild(WayIndex);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FoundWayPoint();
        MovedAI();
    }

    public void MovedAI()
    {
        Vector3 wayPointDistance = transform.InverseTransformPoint(TargetPoint.position);
        wayPointDistance = wayPointDistance.normalized;

        carMoveSystem.MovedCar(1, wayPointDistance.x, false);
    }

    public void FoundWayPoint()
    {
        if (Vector3.Distance(TargetPoint.position, transform.position) <= 30)
        {
            FoundPlayer();
            WayIndex--;
            if (WayIndex < 0)
            {
                WayIndex = GameManager.Instance.WayPoints.childCount - 1;
            }

            TargetPoint = GameManager.Instance.WayPoints.GetChild(WayIndex);
        }
    }

    public void FoundPlayer()
    {
        if(Vector3.Distance(GameManager.Instance.Player().transform.position, transform.position) <= 20)
        {   
            Vector3 playerPos = new Vector3(GameManager.Instance.Player().transform.position.x, transform.position.y, GameManager.Instance.Player().transform.position.z);
            
            transform.LookAt(playerPos);
        }
    }
}
