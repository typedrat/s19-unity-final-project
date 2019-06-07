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

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        //Debug.Log(time);

        if(time >= SpawnRate){
            var next_spawn = Random.Range(0,3);
            Debug.Log(next_spawn);
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
                Instantiate(this.Laser, this.Player.transform.position + new Vector3(Random.Range(20,100), 0, 0), Quaternion.identity);
                Debug.Log("LASER");
            }
            this.time = 0;
        }

    }
}
