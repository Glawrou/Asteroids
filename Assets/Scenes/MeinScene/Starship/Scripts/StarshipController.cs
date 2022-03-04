using UnityEngine;

public class StarshipController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private AudioSource audio;
    public GameObject bullet;
    public GameObject laser;
    public Transform gunLaser;
    public Transform gun;
    public AudioClip[] sound;

    private float rotate = 0;
    private Vector2 position;
    private Vector2 instantaneousSpeed;
    private float speedMove = 50;
    private float speedRotate = 200;
    private int life = 9;

    private int charges = 3;
    private float recharge = 0;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rotationStarship(x);
        muveStarship(y);
        animationControl(y);
        reloadlaser();

        if (Input.GetKeyDown(KeyCode.Z)) fire();
        if (Input.GetKeyDown(KeyCode.X)) fireLaser();
    }

    private void fire()
    {
        GameObject _bullet = Instantiate(bullet, gun.transform.position, gun.rotation);
        _bullet.GetComponent<Rigidbody2D>().AddForce(_bullet.transform.up * 100);
        audio.PlayOneShot(sound[0]);
    }

    private void fireLaser()
    {
        if(charges > 0 )
        {
            GameObject _laser = Instantiate(laser, gunLaser.transform.position, gunLaser.rotation);
            charges--;
            audio.PlayOneShot(sound[1]);
        }       
    }

    private void reloadlaser()
    {
        if (charges < 3)
        {
            recharge += 10 * Time.deltaTime;

            if (recharge > 100)
            {
                charges++; 
                recharge = 0;
            }               
        }
    }

    private void muveStarship(float y)
    {
        position = transform.position;

        Vector3 Forse = transform.up * rounding(y) * speedMove * Time.deltaTime;

        if (y > 0) rigidbody2D.AddForce(Forse);

        instantaneousSpeed = instantaneousSpeed = Forse;
    }

    private void rotationStarship(float x)
    {
        rigidbody2D.rotation = rotate;
        rotate -= rounding(x) * speedRotate * Time.deltaTime;
    }

    private float rounding(float f)
    {
        if (f > 0) f = 1;
        else if (f < 0) f = -1;
        else f = 0;

        return f;
    }

    private void animationControl(float f)
    {
        if (f > 0) animator.SetBool("Motion", true);
        else animator.SetBool("Motion", false);
    }

    public Vector2 GetÑoordinates()
    {
        return position;
    }

    public float GetAngle()
    {
        float Angle = 0;
        Angle = rotate - (((int)rotate / 360) * 360);
        if (Angle > 180) Angle = (Angle - 180) - 180;
        if (Angle < -180) Angle = (Angle + 180) + 180;
        return Angle;
    }

    public int GetCharges()
    {
        return charges;
    }

    public int GetRecharge()
    {
        return (int)recharge;
    }

    public Vector2 GetSpeed()
    {
        return instantaneousSpeed;
    }

    public int GetLife()
    {
        return life;
    }

    public void myDestroy()
    {
        GameObject.FindObjectOfType<UIMein>().GameOver();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<Asteroid>().myDestroy();
            if (life > 0) life--;
            else myDestroy();
        }
        else if (collision.collider.tag == "FlyingSaucer")
        {
            collision.gameObject.GetComponent<FlyingSaucer>().myDestroy();
            if (life > 0) life--;
            else myDestroy();
        }
    }
}
