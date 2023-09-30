using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float color;
    [SerializeField] private float damage;
    private Renderer gameObject1;
    public float temp;
     
     

    private void Start(){
        gameObject1 = gameObject.GetComponent<Renderer>();
        color = .99f;
        maxHealth = 20;
        health = maxHealth;
        
    }

    private void Update()
    {
       
        //sets and changes enemy color based on health
        gameObject1.material.color = Color.Lerp(Color.white,Color.red,color);
        if(color >= health/maxHealth){
            color -= Time.deltaTime / 2;
        }
        
    }

    


      void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Bullet"))
        {
            health -= damage;
            

            if (health <= 0)
            {
                //insert add point here
                //insert explode here
                Destroy(gameObject);

            }
        }
        if (other.CompareTag("Wall"))
        {

        }
        if (other.CompareTag("Player"))
        {

        }


    }




}