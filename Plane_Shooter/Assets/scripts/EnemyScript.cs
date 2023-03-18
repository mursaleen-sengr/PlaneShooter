using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject enemyBullet;
    public Transform []gunpoint;
    public GameObject enemyflash;
    public GameObject enemyExplosion;
    public float speed = 1f;
    public GameObject damageEffect;
    public float health = 10f;
    float barSize = 1f;
    float damage = 0;
    public HealthBar healthbar;
    public float bulletSpawnTime = 1f;
    public GameObject coinPrefab;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;

    public AudioSource audioSource;


    

    // Start is called before the first frame update
    void Start()
    {
       
        enemyflash.SetActive(false);
        StartCoroutine(shoot());
        damage = barSize/health;
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector2.down*speed*Time.deltaTime);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="PlayerBullet")
        {
            audioSource.PlayOneShot(damageSound);
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject damageVfx= Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageVfx, 0.05f);
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Instantiate(coinPrefab,transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameObject expolision = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                Destroy(expolision, 0.3f);
            }
          
          
        }
    }
    void DamageHealthBar()
    {
        if (health > 0)
        {

            health -= 1;
            barSize=barSize - damage;
            healthbar.Setsize(barSize);

        }
    }
    void fire()
    {
        for(int i=0; i<gunpoint.Length; i++)
        {
            Instantiate(enemyBullet, gunpoint[i].position, Quaternion.identity);
            

        }

    }
    IEnumerator shoot()
    {

        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            fire();
            audioSource.PlayOneShot(bulletSound,0.5f);
            enemyflash.SetActive(true);
            yield return new WaitForSeconds(0.02f);
            enemyflash.SetActive(false);


        }
    }
}
