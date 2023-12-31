using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health;
    [SerializeField] private float maxHealth = 20;
    //[SerializeField] private float gunDamage;
    private Renderer gameObject1;
    private bool isDead = false;

    private float gunDamage = Gun.damage;

    public AudioSource enemyDeathAudio;
    public AudioSource bulletImpactAudio;
    public float minPitch = 0.25f;
    public float maxPitch = 1.75f;


    private void Start(){
        gameObject1 = gameObject.GetComponent<Renderer>();
        health = maxHealth;
    }

    private void OnDestroy()
    {
        GameManager.instance.ChangeScore(1);
    }


      void OnTriggerEnter(Collider other)
    {
        if (isDead == false)
        {
            if (other.CompareTag("Bullet"))
            {
                
                health -= gunDamage;

                if (bulletImpactAudio != null && bulletImpactAudio.clip != null)
                {
                    float randomPitch = Random.Range(minPitch + 0.25f, maxPitch - 0.5f);
                    bulletImpactAudio.pitch = randomPitch;
                    bulletImpactAudio.Play();
                }



                if (health <= 0)
                {
                    //GameManager.instance.ChangeScore(1);
                    Destroy(gameObject1);
                    gameObject.GetComponent<ParticleSystem>().Play();
                    GetComponent<AudioSource>().Play();
                    Destroy(gameObject, 1);
                    isDead = true;

                    //float randomPitch = Random.Range(minPitch, maxPitch);
                    //enemyDeathAudio.pitch = randomPitch;
                    if (enemyDeathAudio != null && enemyDeathAudio.clip != null)
                    {
                        enemyDeathAudio.Play();
                    }

                }
                
                Destroy(other.gameObject);
            }
            

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (isDead == false)
        {
            if (other.CompareTag("Wall"))
            {
                Destroy(gameObject, 1);

            }


        }


    }




}
