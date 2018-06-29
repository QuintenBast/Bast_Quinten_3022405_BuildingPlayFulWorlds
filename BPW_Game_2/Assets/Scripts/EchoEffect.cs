using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{

    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    private PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.moveInput != 0)
        {
            if (timeBtwSpawns <= 0)
            {
                //spawn echo game object
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 8f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }

    }
}