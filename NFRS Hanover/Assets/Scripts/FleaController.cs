using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleaController : MonoBehaviour
{
    private System.Random rnd;
    [SerializeField] private int seed = 0;
    private bool walking = true;
    private Animator animator;
    private float waitTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        this.rnd = new System.Random(seed);
        this.animator = this.gameObject.GetComponent<Animator>();
        this.waitTime = 2;
        this.timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.walking)
        {
            var pos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector3(pos.x - 0.02F, pos.y, pos.z);
        }
        this.timer += Time.deltaTime;
        if(this.timer >= this.waitTime)
        {
            this.timer = 0;
            var idle = rnd.Next(0,10);
            Debug.Log(idle);
            if(idle <= 8)
            {
                animator.SetBool("Walking", true);
                Debug.Log("walking");
                this.walking = true;
            }
            else
            {
                animator.SetBool("Walking", false);
                Debug.Log("Idling");
                this.walking = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var health = collision.gameObject.GetComponentInChildren<Health>();
            health.TakeDamage(10);
        }
    }
}