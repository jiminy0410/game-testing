using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public float speed;
    public float speedMax = 40;
    public int PresentLane = 2;
    public bool forward;
    public bool jump;
    public float jumphight;
    public int live = 3;
    public bool grounded;
    public float dist;
    public float score;
    public int coins;
    public bool die;
    public int deadTimer;

    public GameObject LivesText;
    public GameObject ScoreText;
    public GameObject CoinsText;
    public GameObject DistText;

    public GameObject hitObject;
    public Collider coin;

    // Start is called before the first frame update
    void Start()
    {
        //dead();
        LivesText = GameObject.Find("lives");
        Physics.gravity = new Vector3(0, Physics.gravity.y * 2, 0);
        deadTimer = 180;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        GameObject.Find("lives").GetComponent<Text>().text = "lives :" + live;
        ScoreText.GetComponent<Text>().text = "score :" + score;
        CoinsText.GetComponent<Text>().text = "coins :" + coins;
        DistText.GetComponent<Text>().text = "didst :" + (int)dist;
        */

        if (Input.GetKeyDown("a"))
        {
            if (PresentLane > 1 && live > 0)
            {
                PresentLane--;
            }
        }
        if (Input.GetKeyDown("d"))
        {
            if (PresentLane < 3 && live > 0)
            {
                PresentLane++;
            }
        }
        if (Input.GetKeyDown("w"))
        {
            if (live > 0)
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
        if (transform.position.z >195)
        {
            live--;
        }

        die = false;

        if (live < 1)
        {
            deadTimer--;
            if (deadTimer < 1)
            {
                die = true;
            }
            speed = 0;
        }

        if (die)
        {
            dead();
        }

        dist += speed / 10;

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
        if (speed < speedMax && live > 0)
            {
                speed += 0.02f;
            }

        // forward
        GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, this.GetComponent<Rigidbody>().velocity.y, speed);

        // jump
        if (jump && grounded && live > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(0, jumphight, 0, ForceMode.Impulse);
            grounded = false;
        }
        jump = false;
        score = (int)(coins * 50 + dist);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("meen"))
        {
            hitObject = collision.gameObject;
            live--;
            speed = speed / 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            coin = other;
            coins++;
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

    public void dead()
    {
        live = 3;
        transform.position = new Vector3(0, 0, 0);
        PresentLane = 2;
        score = 0;
        coins = 0;
        dist = 0;
        hitObject = null;
        coin = null;
        speed = 10;
        deadTimer = 180;
        forward = false;
    }
}
