using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    [HideInInspector]
    public bool CanTouchFinishLine = false;

    public GameObject Danger;

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
                CanTouchFinishLine = true;
            }

            TargetPoint = WayPoints.GetChild(WayIndex);
        }
    }

    private void Update()
    {

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

    public void AddParts()
    {
        for(int i = 0; i < GameInstance.Instance.Parts.Count; i++)
        {
            if (GameInstance.Instance.Parts[i] != null)
            {   
                GameObject partObj = Instantiate(GameInstance.Instance.Parts[i], transform.position, transform.rotation);
                partObj.transform.parent = transform;
            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<BaseItem>())
        {
            BaseItem item = collision.gameObject.GetComponent<BaseItem>();
            string itemObjName = collision.gameObject.name.Substring(0, collision.gameObject.name.Length - 7);
            GameManager.Instance._UIManager.MarkItems(itemObjName);
            item.OnGetItem(this);
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.name == "FinishLine" && CanTouchFinishLine == true)
        {
            GameManager.Instance._UIManager.PlayerLaps += 1;
        }
    }
   
}