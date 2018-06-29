using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public ParticleSystem deathParticle;

    public float rotationSpeed;
    public float distance;
    public Gradient redColor;
    public Gradient greenColor;

    public LineRenderer lineOfSight;

    public AudioSource deathSound;




    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        deathSound = GetComponent<AudioSource>();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColor;

            if (hitInfo.collider.CompareTag("Player"))
            {
                Instantiate(deathParticle, GameObject.FindWithTag("Player").transform.position, GameObject.FindWithTag("Player").transform.rotation);
                deathSound.Play();
                Destroy(hitInfo.collider.gameObject);
            }

        } else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            lineOfSight.colorGradient = greenColor;
        }

        lineOfSight.SetPosition(0, transform.position);

    }




}
