using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{

    public Transform Player;
    public GameObject TopPipe;
    public GameObject BottomPipe;
    public GameObject Coin;
    private float pipeLength = 5f;
    private int pairNumber = 1;

    void Start()
    {
        InvokeRepeating("GeneratePair", 3f, 3f);
    }

    void GeneratePair()
    {
        if (GameManager.instance.start)
        {
            float pairPositionX = Random.Range(8f, 12f);
            float pairPositionY = Random.Range(1.8f, 7f);

            float pairX = Player.position.x + pairPositionX + GameManager.instance.playerSpeed;
            float bottomPipeY = pairPositionY - pipeLength * 2;
            float coinY = pairPositionY - pipeLength;

            var topPipe = Instantiate(TopPipe, new Vector3(pairX, pairPositionY, -5), new Quaternion());
            var bottomPipe = Instantiate(BottomPipe, new Vector3(pairX, bottomPipeY, -5), new Quaternion());
            var coin = Instantiate(Coin, new Vector3(pairX, coinY, -5), new Quaternion());

            topPipe.name = "generatedTopPipe_" + pairNumber.ToString();
            bottomPipe.name = "generatedBottomPipe_" + pairNumber.ToString();
            coin.name = "coin_" + pairNumber.ToString();
            pairNumber += 1;
        }
    }
}
