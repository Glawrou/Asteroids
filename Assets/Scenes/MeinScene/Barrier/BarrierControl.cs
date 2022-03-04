using UnityEngine;
using System.Collections;

public class BarrierControl : MonoBehaviour
{
    public float xBarrier = 1.382f;
    public float yBarrier = 1.061f;

    private bool reloading = false;
    private void FixedUpdate()
    {
        if(reloading == false)
        {
            if (transform.position.x > xBarrier || transform.position.x < -xBarrier) 
                transform.position = new Vector2(-transform.position.x, transform.position.y); StartCoroutine(Reloading());
            if (transform.position.y > yBarrier || transform.position.y < -yBarrier) 
                transform.position = new Vector2(transform.position.x, -transform.position.y); StartCoroutine(Reloading());
        }
    }

    private IEnumerator Reloading()
    {
        reloading = true;
        yield return new WaitForSeconds(0.2f);
        reloading = false;
    }
}
