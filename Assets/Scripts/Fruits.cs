using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject fruitPrefab;


    public void CreateSlice()
    {
        GameObject g = (GameObject)Instantiate(fruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rb = g.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in rb)
        {
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5);
            r.transform.rotation = Random.rotation;
        }

        FindObjectOfType<GameManager>().increaseScore();

        Destroy(g, 5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if(!b)
        {
            return;
        }

        else
        {
            CreateSlice();
        }
    }
}
