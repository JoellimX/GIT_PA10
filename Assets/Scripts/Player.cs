using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody thisRigidbody = null;
    public float Force = 300;
    private Animation thisAnimation;

    public Text Txt_Score;
    public int Score = 0;


    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            thisRigidbody.AddForce(Vector3.up * Force);
        }
            

        Txt_Score.text = "SCORE : " + Score;
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Obstacle")
        {
            GameManager.thisManager.GameOver();
            SceneManager.LoadScene("GameOver");
        }

        if (Other.tag =="Score")
        {
            Score ++;
        }
    }

}
