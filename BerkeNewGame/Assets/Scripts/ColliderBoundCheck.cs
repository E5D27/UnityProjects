using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBoundCheck : MonoBehaviour {


    PolygonCollider2D boxCollider;

    GameObject playerPos;

    //public GameObject player;

    void Start () {

        boxCollider = GetComponent<PolygonCollider2D>();
        

        //Debug.Log(boxCollider.bounds);
        //Debug.Log(boxCollider.bounds.size);

        playerPos = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {


        if (playerPos != null && boxCollider.bounds.Contains(playerPos.transform.position) == false && Camera.main.backgroundColor == Color.black)
        {
            //Debug.Log("Bounds DOES NOT contain the point : " + playerPos.transform.position);

            Debug.Log("YESSSSSSSSSSS");

            Destroy(playerPos);
        }


        //if (boxCollider.bounds.Contains(playerPos.transform.position))
        //{
        //    Debug.Log("Bounds contain the point : " + playerPos.transform.position);
        //}
        //else
        //{
        //    Debug.Log("Bounds DOES NOT contain the point : " + playerPos.transform.position);
        //}



    }
}
