using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject GameScoreGO;
    public GameObject PowerUpGO;
    Rigidbody Player;
    float GameScore = 10.0f;
    float speed = 5.0f;
    int TotalPowerUp;
    int PowerUpPicked;

    // Start is called before the first frame update
    void Start()
    {
        TotalPowerUp = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        GameScoreGO.GetComponent<Text>().text = "Score : " + GameScore.ToString();// printing score
        PowerUpGO.GetComponent<Text>().text = "Power Up Picked : " + PowerUpPicked.ToString(); //printing power up picked

        TotalPowerUp = GameObject.FindGameObjectsWithTag("PowerUp").Length;//Checking a total amount of Powerup based on tag and making an array to count them


        if (Input.GetKeyDown(KeyCode.Space))
        {
            --GameScore;
            if (GameScore == 0)
            {
                Debug.Log("Going OVER to new SCENE NOW!");
                SceneManager.LoadScene("LoseScene");
            }
        }

        if (TotalPowerUp == 0)
        {
            Debug.Log("Going OVER to new SCENE NOW!");
            SceneManager.LoadScene("WinScene");
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            GameScore += 10;
            ++PowerUpPicked;
            Destroy(collision.gameObject);
            
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Going OVER to new SCENE NOW!");
            SceneManager.LoadScene("LoseScene");
        }
    }
}
