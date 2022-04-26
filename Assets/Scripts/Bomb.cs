using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if(!b)
        {
            return;
        }
        else
        {
            FindObjectOfType<GameManager>().BombHit();
        }
    }
}
