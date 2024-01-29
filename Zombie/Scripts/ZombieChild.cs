using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChild : MonoBehaviour
{


    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            transform.parent.GetComponent<ZombieAttack>().CollisionDetected(this, collision);
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
            transform.parent.GetComponent<ZombieAttack>().CollisionStayed(this, collision);
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            transform.parent.GetComponent<ZombieAttack>().CollisionExited(this, collision);
    }

}