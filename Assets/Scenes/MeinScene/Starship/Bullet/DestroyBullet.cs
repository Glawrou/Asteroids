using System.Collections;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public bool invulnerability = false;
    void Start()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (invulnerability == false)
        {
            Destroy(gameObject);
        }
    }
}
