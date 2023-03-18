using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnpoint1;
    public Transform spawnpoint2;
    public GameObject flash;

    public float bulletSpawnTime = 1f;
    public AudioSource AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {

       

        

    }
    void fire()
    {

        Instantiate(playerBullet, spawnpoint1.position, Quaternion.identity);
        Instantiate(playerBullet, spawnpoint2.position, Quaternion.identity);

    }
    IEnumerator shoot()
    {

        while (true)
        {
           
            yield return new WaitForSeconds(bulletSpawnTime);
            fire();
            AudioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            flash.SetActive(false);


        }
    }
}
