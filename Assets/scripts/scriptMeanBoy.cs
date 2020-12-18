using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMeanBoy : MonoBehaviour
{
    playerMove scr;
    public Vector3 tempPos;
    private void Awake()
    {
        scr = GameObject.Find("player").GetComponent<playerMove>();
        tempPos = this.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 10, this.transform.position.z);
        }
    }
    void Update()
    {
        if(scr.die)
        {
            dead();
        }
    }
    void dead()
    {
        this.transform.position = tempPos;
    }
}
