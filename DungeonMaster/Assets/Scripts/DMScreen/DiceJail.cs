using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceJail : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("dice1"))
        {
            Destroy(other.gameObject);
        }
    }
}
