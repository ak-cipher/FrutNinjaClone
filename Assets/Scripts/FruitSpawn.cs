using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public GameObject[] fruitToSpawn;
    public GameObject Bomb;
    public Transform[] spawnPos;

    public float minwait = 0.3f;
    public float maxwait = 1f;
    public float minf = 5;
    public float maxf = 10;


    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }


    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minwait, maxwait));


            Transform t = spawnPos[Random.Range(0, spawnPos.Length)];

            GameObject g = null;
            float p = Random.Range(1, 100);

            if(p<10)
            {
                g = Bomb;
            }
            else if(p>10 && p<30)
            {
                g = fruitToSpawn[0];
            }
            else if (p > 30 && p < 60)
            {
                g = fruitToSpawn[1];
            }
            else
            {
                g = fruitToSpawn[2];
            }

            GameObject fruit = Instantiate(g, t.position, t.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minf, maxf), ForceMode2D.Impulse);
            Destroy(fruit, 5);


        }
    }

}
