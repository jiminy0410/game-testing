using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed;
    public float speedMax = 20;
    public int PresentLane = 2;
    public bool forward;
    public bool jump;
    public float jumphight;
    public int live = 3;
    public bool grounded;
    public float score;
    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        dead();
        Physics.gravity = new Vector3(0, Physics.gravity.y * 2, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (live < 1)
        { dead(); }

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
        score++;
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
        if (jump && grounded)
        {
            GetComponent<Rigidbody>().AddForce(0, jumphight, 0, ForceMode.Impulse);
            grounded = false;
        }
        jump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("meen"))
        {
            live--;
            speed = speed / 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            score += 50;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    void dead()
    {
        live = 3;
        transform.position = new Vector3(0, 0, 0);
        speed = 10;
        PresentLane = 2;
        score = 0;
        coins = 0;
    }
}
