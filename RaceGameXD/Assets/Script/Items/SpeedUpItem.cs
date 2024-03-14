using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : BaseItem
{   
    public override void OnGetItem(PlayerController player)
    {
        player.StartCoroutine(SpeedUp(player));
    }

    IEnumerator SpeedUp(PlayerController player)
    {   
        player.SetMotorSpeed(1000);
        yield return new WaitForSeconds(5f);
        player.SetMotorSpeed(player.DefaultMaxMotor);

    }

}
