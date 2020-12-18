using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMeanGirl : MonoBehaviour
{
    public float speed;
    playerMove scr;
    public Vector3 tempPos;
    public float oriSpeed;
    // Update is called once per frame

    private void Awake()
    {
        scr = GameObject.Find("player").GetComponent<playerMove>();
        tempPos = this.transform.position;
        oriSpeed = speed;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x+speed, transform.position.y, transform.position.z);
        if(transform.position.x < -1.5 || transform.position.x > 1.5)
        {
            speed *= -1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 10, this.transform.position.z);
        }
    }
    void Update()
    {
        if (scr.live < 1)
        {
            dead();
        }
    }
    void dead()
    {
        this.transform.position = tempPos;
        speed = oriSpeed;
    }
}
