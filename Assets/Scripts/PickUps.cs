using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public GameObject pickUpPrefab;
    private int countSpawn = 1;
    public float respawnTime;
    private float timing;
    
    void Start ()
    {
        StartCoroutine(spawning());
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); // makes it rotate. Stayed the same.
    }

    private void spawnPickUps()
    {
        if ((countSpawn >= 0) && (countSpawn < 10)) //TODO: add a real max val instead of 10k to account for people going more than the 10k count
    {
            for (int i = 0; i < 10; ++i)
            {
                GameObject codes = Instantiate(pickUpPrefab) as GameObject;
                codes.transform.position = new Vector3(Random.Range(-50, 50), 0.5f, Random.Range(-50, 50));
                countSpawn++;
                timing = (float)(15 * (countSpawn * 0.20));
                /*randX = Random.Range(0,50);
                y = 0.50f;
                randZ = Random.Range(0,50);
                GameObject pickUpObjs = Instantiate(pickUpPrefab) as GameObject;
                countSpawn++;
                pickUpObjs.transform.position = new Vector3(randX, y, randZ);*/

                // WaitForSeconds(15 * (countSpawn * 0.20)); //sleeps for an increasing time span while maintaining challenge.
            }
        }
    }

    IEnumerator spawning()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPickUps();
        }
    }
}
