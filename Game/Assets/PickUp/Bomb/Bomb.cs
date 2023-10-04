using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLIve : MonoBehaviour
{
    public int value;

    GameMenager Health;

    public float LivePickUp = 1;

    private void Awake()
    {
        Health = FindObjectOfType<GameMenager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameMenager.Health -= 1;
        }
    }
}
