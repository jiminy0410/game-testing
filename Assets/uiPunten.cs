using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiPunten : MonoBehaviour
{
    public int live = 3;
    public float dist;
    public float score;
    public int coins;

    public GameObject LivesText;
    public GameObject ScoreText;
    public GameObject CoinsText;
    public GameObject DistText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.GetComponent<Text>().text = "lives :" + live;
        ScoreText.GetComponent<Text>().text = "score :" + score;
        CoinsText.GetComponent<Text>().text = "coins :" + coins;
        DistText.GetComponent<Text>().text = "didst :" + (int)dist;
    }
}
