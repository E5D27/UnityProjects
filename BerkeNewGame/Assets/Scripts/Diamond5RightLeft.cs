using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond5RightLeft : MonoBehaviour {

    Rigidbody2D rigid;
    public float speed;
    IEnumerator co;

  
    void Start ()  //Yanyana 5 tane diamond çıkarıyor ve aşağaı her 1.5 saniyede bir yön değiştiricek şekilde aşağı indiriyor. Bu class'ın objelerini GameController'da spawnDiamond5Stack method'u oluşturuyor.
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        //rigid.angularVelocity = 400.0f;
        co = SwitchDirection();
        StartCoroutine(SwitchDirection());     
    }


    IEnumerator SwitchDirection()
    {
        rigid.velocity = new Vector2(-1, -1) * speed;
        yield return new WaitForSeconds(1.5f);
        rigid.velocity = new Vector2(1, -1) * speed;
        yield return new WaitForSeconds(1.5f);
        rigid.velocity = new Vector2(-1, -1) * speed;
        yield return new WaitForSeconds(1.5f);
        rigid.velocity = new Vector2(1, -1) * speed;
        yield return new WaitForSeconds(1.5f);
        rigid.velocity = new Vector2(-1, -1) * speed;
        yield return new WaitForSeconds(1.5f);
        rigid.velocity = new Vector2(1, -1) * speed;
        yield return new WaitForSeconds(1.5f);
        rigid.velocity = new Vector2(-1, -1) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("abc");  //Player'i öldür 

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        else
        {
            StopCoroutine(co);
            //print("LOLLLLLLLLLLLLLLLLLLLL");
        }
    }

}
