using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerByInnerBoundary : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }

    


}
