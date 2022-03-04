using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOpponents : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject FlyingSaucer;

    public Transform[] Spawner;

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5);
        if(Random.Range(1,100) > 10)
        {
            GameObject _asteroid = Instantiate(Asteroid, Spawner[Random.Range(0, Spawner.Length)]);
            _asteroid.GetComponent<Rigidbody2D>().AddForce(-_asteroid.transform.position * Random.Range(20, 30));
        }
        else
        {
            GameObject _flyingSaucer = Instantiate(FlyingSaucer, Spawner[Random.Range(0, Spawner.Length)]);
        }
              
        StartCoroutine(Spawn());
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }
}
