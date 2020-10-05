using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject controller;
    private float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameObject Controller");
        rb = GetComponent<Rigidbody2D>();
        speed = controller.GetComponent<FireballController>().getSpeed();
        rb.velocity = new Vector2(-speed, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fireball Despawner")
        {
            
            controller.GetComponent<FireballController>().isDestroyed();
            rb.velocity = new Vector2(0, 0);


        }
        else if(col.gameObject.tag == "Player")
        {
            controller.GetComponent<FireballController>().gameOver();
            rb.velocity = new Vector2(0, 0);
            end();
        }
    }
    public void reset (Vector3 pos)
    {
        this.gameObject.transform.position = pos;
        speed = controller.GetComponent<FireballController>().getSpeed();
        rb.velocity = new Vector2(-speed, 0);
    }
    public void end()
    {
        this.gameObject.transform.position = new Vector3(-20, 20, -10);
    }
}
