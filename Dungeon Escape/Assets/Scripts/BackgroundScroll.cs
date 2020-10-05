using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = .1f;
    public bool stop;
    void Start()
    {
        stop = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed,0f);
        }   
    }
    public void stopScroll()
    {
        stop = true;
    }
}
