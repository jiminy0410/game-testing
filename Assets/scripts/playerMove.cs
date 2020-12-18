using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed;
    public float speedMax = 20;
    public int PresentLane = 2;
    public bool forward;
    public bool jump;
    public float jumphight;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            if (PresentLane > 1)
            {
                PresentLane--;
            }
        }
        if (Input.GetKeyDown("d"))
        {
            if (PresentLane < 3)
            {
                PresentLane++;
            }
        }
        if (Input.GetKey("w"))
        {
            if (speed < speedMax)
            {
                forward = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // lane control 
        switch (PresentLane)
        {
            case 1:
                transform.position = new Vector3(-1, transform.position.y, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
                break;
        }
        // speed
        if (forward)
        {
            speed += 0.1f;
        }
        forward = false;
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, speed);
        // jump
        if(jump)
        {
            GetComponent<Rigidbody>().AddForce(0, jumphight, 0,ForceMode.Impulse);
        }
        jump = false;
    }
}
