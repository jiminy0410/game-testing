using UnityEngine;

public class scriptCoin : MonoBehaviour
{
    playerMove scr;
    public Vector3 tempPos;
    private void Awake()
    {
        scr = GameObject.Find("player").GetComponent<playerMove>();
        tempPos = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 10, this.transform.position.z);
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
    }
}
