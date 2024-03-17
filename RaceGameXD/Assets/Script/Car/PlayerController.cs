using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] 
    public Rigidbody _rigidBody;
    private CarMoveSystem _carMoveSystem;

    public Transform WayPoints;
    public int WayIndex;
    [HideInInspector] public float DefaultMaxMotor;

    [HideInInspector] 
    public Transform TargetPoint;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _carMoveSystem = GetComponent<CarMoveSystem>();
        DefaultMaxMotor = _carMoveSystem.MaxMotor;

        TargetPoint = WayPoints.GetChild(WayIndex);
    }

    private void FixedUpdate()
    {
        MoveInputSystem();

        if (Vector3.Distance(TargetPoint.position, transform.position) <= 30)
        {   
            if (WayPoints.childCount > WayIndex)
            {
                WayIndex++;
            }    

            if (WayIndex == WayPoints.childCount)
            {
                WayIndex = 0;
            }

            TargetPoint = WayPoints.GetChild(WayIndex);
        }
    }

    void MoveInputSystem()
    {
        float motorTorque = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");
        bool b_break = Input.GetKey(KeyCode.Space);

        _carMoveSystem.MovedCar(motorTorque, steering, b_break);
    }

    public void SetMotorSpeed(float motorSpeed)
    {
        _carMoveSystem.MaxMotor = motorSpeed;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<BaseItem>())
        {
            BaseItem item = collision.gameObject.GetComponent<BaseItem>();
            Debug.Log(collision.gameObject.name);
            item.OnGetItem(this);
            Destroy(collision.gameObject);
        }
    }
}