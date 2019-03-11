using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public float speed;
    public float Height;
    public int count;
    private int life;
    public Text countText;
    public Text winText;
    public Text LifeText;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        count = 0;
        life = 3;
        winText.text = "";
        SetLifeText();
        SetCountText();
        MusicSource.clip = MusicClip;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
     if(collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, Height), ForceMode2D.Impulse);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            life = life - 1;
            SetLifeText();
        }

        if (other.gameObject.CompareTag("PickUp")) {


            other.gameObject.SetActive(false);


            count = count + 1;


            SetCountText();
        }

    }
    void SetCountText()
    {
  
        countText.text = "Count: " + count.ToString();


        if (count == 4)
        {

            Vector2 position = new Vector2(41.6f, 4.5f);
            rb2d.position = position;
        }

        if (count == 8)
        {
            winText.text = "You collected all the coins!";
            MusicSource.Play();
            rb2d.gameObject.SetActive(false);
        }
    }
    void SetLifeText()
    {
        LifeText.text = "Lives: " + life.ToString();
        if (life == 0)
        {

            winText.text = "You lost all your lives!";

            rb2d.gameObject.SetActive(false);
        }
    }
}






