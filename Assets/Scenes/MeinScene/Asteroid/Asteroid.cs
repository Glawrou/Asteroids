using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] bigAsteroid;
    public GameObject asteroid;
    public GameObject wreckage;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bigAsteroid[Random.Range(0, bigAsteroid.Length)];    
    }

    public void myDestroy()
    {
        if(transform.localScale.x == 1)
        {
            for (int i = 0; i < 3; i++)
            {              
               GameObject _asteroid = Instantiate(asteroid, transform.position + randomVector(), Quaternion.identity);
                _asteroid.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                _asteroid.GetComponent<Rigidbody2D>().AddForce(randomVector() * 500);
            }       
        }
        else if(transform.localScale.x == 0.5)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject _asteroid = Instantiate(asteroid, transform.position + randomVector(), Quaternion.identity);
                _asteroid.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                _asteroid.GetComponent<Rigidbody2D>().AddForce(randomVector() * 300);
            }
        }

        Instantiate(wreckage, transform.position, Quaternion.identity);

        GameObject.FindObjectOfType<UIMein>().AddScore(100);

        Destroy(gameObject);
    }

    private Vector3 randomVector()
    {
        Vector3 _randomVector = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        return _randomVector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            myDestroy();
        }
    }
}
