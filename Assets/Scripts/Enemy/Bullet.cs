using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player")){
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);
            Debug.Log("Trung");
        }
        Destroy(gameObject);
    }
}
