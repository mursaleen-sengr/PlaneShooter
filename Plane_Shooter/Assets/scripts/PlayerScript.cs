using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 15f;
    float maxX;
    float minX;
    float maxY;
    float minY;
    public float padding = 0.8f;
    public GameObject Explosion;
    public float Health = 20f;
    float Barfillamount = 1f;
    float damage = 0;
    public PlayerHealthBarScript PlayerHealthBar;
    public GameObject damageEffect;
    public coincount coincountscript;
    public GameController GameController;
    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;



    // Start is called before the first frame update
    void Start()
    {
        FindBoundaries();
        damage = Barfillamount / Health;

    }

    void FindBoundaries()
    {
        Camera gameCamera= Camera.main;
        minX= gameCamera.ViewportToWorldPoint( new Vector3(0,0,0)).x+padding;
        maxX= gameCamera.ViewportToWorldPoint( new Vector3(1,0,0)).x-padding;
         minY= gameCamera.ViewportToWorldPoint( new Vector3(0,0,0)).y+padding;
        maxY= gameCamera.ViewportToWorldPoint( new Vector3(0,1,0)).y-padding;


    }



    // Update is called once per frame
    void Update()
    {
        float X= Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float Xpos = Mathf.Clamp(transform.position.x + X,minX,maxX);
        
        float Y=Input.GetAxis("Vertical")*Time.deltaTime* speed;
        float Ypos= Mathf.Clamp(transform.position.y + Y,minY,maxY);
        transform.position = new Vector2(Xpos,Ypos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(damageSound,0.5f);
            DamagePlayerHealthBar();
            Destroy(collision.gameObject);
            GameObject damageVfx= Instantiate(damageEffect,collision.transform.position,Quaternion.identity);
            Destroy(damageVfx, 0.02f);
            if(Health<=0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Destroy(gameObject);
                GameObject blast = Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(blast, 2f);
                GameController.gameOver();
            }
        }
        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound,0.5f);
            Destroy(collision.gameObject);
            coincountscript.AddCount();


        }
    }
    void DamagePlayerHealthBar()
    {
        if (Health > 0)
        {
            Health -= 1;
            Barfillamount = Barfillamount - damage;
            PlayerHealthBar.SetAmount(Barfillamount);
        }
    }
}
