using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hole : MonoBehaviour
{

    private void OnEnable()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Destroy(collision.gameObject, 1);
            GameManage.instance.UpdateScore();
            GameManage.instance.UpdateBall();
            GameManage.instance.PlayClubHitBallSound(); 
        }
    }
}
