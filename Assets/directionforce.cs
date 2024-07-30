using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionforce : MonoBehaviour
{
    public int force = 800;
    public Transform hitPoint;
    private Rigidbody inRb;
    public BoxCollider col;
    private Vector3 contactPOint;
    // Start is called before the first frame update
    void Start()
    {
        inRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            contactPOint = collision.transform.position;
            direction.y = 0;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            GameManage.instance.PlayClubHitBallSound();
            rb.AddForce(-direction * force * inRb.velocity.sqrMagnitude, ForceMode.Force);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, contactPOint);
    //}
}
