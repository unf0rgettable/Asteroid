using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        //rb.AddForce(new Vector2(0,1 * speed), ForceMode2D.Impulse);
        //rb.velocity = transform.forward * speed;
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D othe)
    {
        if (othe.gameObject != gameObject && othe.transform.tag != "Player")
        {
            othe.transform.gameObject.SetActive(false);
            //GameObject.Find("GameManager").transform.GetComponent<Score>().updt_scr();
            gameObject.SetActive(false);
        }
    }
}
