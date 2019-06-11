using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public ScreenShake c_Shake;
    public float collisionPauseTime = 0.1f;
    private bool isPaused = false;
    private float currentPauseTime = 0f;

    private float startXPos;
    private float maxXPos;
    private float currentXPos;
    public Text scoreText;
    public int score;
    public int distance;
    private float numCheeses = 0;
    
    [SerializeField] private bool isInvul = false;
    [SerializeField] private float invulTime = 2f;
    private float currentInvulTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startXPos = this.transform.position.x;
        maxXPos = startXPos;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -4)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4, gameObject.transform.position.z);
        }

        if(gameObject.transform.position.y >= 11)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 11, gameObject.transform.position.z);
        }

        // Update maxXPos if needed
        currentXPos = this.transform.position.x;
        if (currentXPos > maxXPos) {
            maxXPos = currentXPos;
            distance = Mathf.CeilToInt(maxXPos - startXPos);
        }

        if (isPaused)
        {
            currentPauseTime += Time.unscaledDeltaTime;
            Debug.Log(currentPauseTime);
            if(currentPauseTime >= collisionPauseTime)
            {
                Debug.Log("Done");
                isPaused = false;
                Time.timeScale = 1f;
                currentPauseTime = 0f;
                Color color = this.GetComponent<SpriteRenderer>().color;
                color.a = .4f;
                color.g = 1f;
                color.b = 1f;
                this.GetComponent<SpriteRenderer>().color = color;
            }
        }

        if (isInvul)
        {
            currentInvulTime += Time.deltaTime;
            if(currentInvulTime >= invulTime)
            {
                isInvul = false;
                Color color = this.GetComponent<SpriteRenderer>().color;
                color.a = 1f;
                this.GetComponent<SpriteRenderer>().color = color;
                currentInvulTime = 0f;
            }
        }

        UpdateScoreText();
    }

    void OnCollisionEnter2D(Collision2D col)
    {   
        if (!isInvul)
        {
            this.GetComponent<Health>().TakeDamage(10);
            Debug.Log("OnCollisionEnter2D");
            isInvul = true;
            Color color = this.GetComponent<SpriteRenderer>().color;
            color.g = .4f;
            color.b = .4f;
            this.GetComponent<SpriteRenderer>().color = color;
            c_Shake.Shake(.25f);

            isPaused = true;
            Time.timeScale = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Cheese")
        {
            numCheeses++;
            score += 50;
            Destroy(col.gameObject);
        }
    }

    void UpdateScoreText()
    {
        int newScore = score + distance;
        scoreText.text = "" + newScore;
    }
}
