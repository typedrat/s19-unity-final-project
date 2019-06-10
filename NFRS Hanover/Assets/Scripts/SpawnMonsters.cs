using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Flea;
    [SerializeField] private GameObject Robot;
    [SerializeField] private GameObject Laser;

    [SerializeField] private int SpawnRate = 1000;

    private float time = 0;
    private float old_pos;

    void Start()
    {
        this.old_pos = Player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if(this.old_pos + 5 <= Player.transform.position.x)
        {
            this.old_pos = Player.transform.position.x;


            if(this.time >= SpawnRate){
                //var next_spawn = Random.Range(0,3);
                var next_spawn = 2;
                if(next_spawn == 0)
                {
                    Instantiate(this.Flea, this.Player.transform.position + new Vector3(Random.Range(20,100), 0, 0), Quaternion.identity);
                    Debug.Log("FLEA");
                } else if(next_spawn == 1)
                {
                    Instantiate(this.Robot, this.Player.transform.position + new Vector3(Random.Range(20,100), 0, 0), Quaternion.identity);
                    Debug.Log("ROBOT");
                } else
                {
                    Instantiate(this.Laser, new Vector3(Random.Range(20,100) + this.Player.transform.position.x, 7, 0), Quaternion.identity);
                    Debug.Log("LASER");
                }
                this.time = 0;
            }
        }
    }
}
