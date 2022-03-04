using UnityEngine;

public class FlyingSaucer : MonoBehaviour
{
    private Transform Starship;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        Starship = GameObject.FindObjectOfType<StarshipController>().transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rigidbody2D.AddForce(((Vector2)Starship.position - (Vector2)transform.position) * 30 * Time.deltaTime);
    }

    public void myDestroy()
    {
        GameObject.FindObjectOfType<UIMein>().AddScore(500);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            myDestroy();
        }
    }
}
