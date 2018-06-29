using UnityEngine.SceneManagement;
using UnityEngine;


public class Restarter : MonoBehaviour {

    //Animation youranimation = GetComponent<Animation>();

    public ParticleSystem deathParticle;
    public AudioSource deathSound;


    void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if(other.tag == "Player")
            {
                Instantiate(deathParticle, GameObject.FindWithTag("Player").transform.position, GameObject.FindWithTag("Player").transform.rotation);
                Destroy(GameObject.FindWithTag("Player"));
                deathSound.Play();
            }
        }
    }
}
