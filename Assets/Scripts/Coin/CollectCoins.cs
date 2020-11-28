using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bird" && this.gameObject.name != "Coin")
        {
            GameManager.instance.score += 1;
            Destroy(this.gameObject);
            Debug.Log(GameManager.instance.score);
        }
    }
}
