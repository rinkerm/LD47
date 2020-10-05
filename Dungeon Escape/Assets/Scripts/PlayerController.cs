using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    [SerializeField] float jumpforce;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetInteger("State") == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetInteger("State",1);
                jump();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetInteger("State", 2);
            }
        }
        else
        {
            if (!AnimatorIsPlaying() && !(anim.GetInteger("State")==3))
            {
                anim.SetInteger("State", 0);
            }
        }
    }
    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
    void jump()
    {
        rb.velocity = new Vector2(0, jumpforce);
    }
    public void death()
    {
        anim.SetInteger("State", 3);
    }
}
