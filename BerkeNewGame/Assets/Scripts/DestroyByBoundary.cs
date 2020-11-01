using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{

    //BoxCollider2D boxCollider;

    void Start()
    {
        

        //boxCollider = GetComponent<BoxCollider2D>();
        //playerCollider = player.GetComponent<CircleCollider2D>();
        //playerPosition = GetComponent<PlayerController>();

        //Debug.Log(boxCollider.bounds);
        //Debug.Log(boxCollider.bounds.size);
    }


    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

}
