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
                var next_spawn = Random.Range(0,2);
                if(next_spawn == 0)
                {
                    if(Random.value <= 0.5)
                    {
                        var flea = Instantiate(this.Flea, new Vector3(Random.Range(20,100) + this.Player.transform.position.x, 9, 0), Quaternion.identity);
                        flea.transform.Rotate(0, 180, 180);
                        Debug.Log("FLEA1");
                    }
                    else
                    {
                        Instantiate(this.Flea, new Vector3(Random.Range(20,100) + this.Player.transform.position.x, -1, 0), Quaternion.identity);
                        Debug.Log("FLEA2");
                    }
                } else if(next_spawn == 1)
                {
                    Instantiate(this.Laser, new Vector3(Random.Range(20,100) + this.Player.transform.position.x, 7, 0), Quaternion.identity);
                    Debug.Log("LASER");
                }
                this.time = 0;
            }
        }
    }
}
