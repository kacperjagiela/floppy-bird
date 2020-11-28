using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPipes : MonoBehaviour
{

    public Transform Player;
    public Transform Pipe;

    void Update()
    {
        if (Pipe.position.x < Player.position.x - 10f)
        {
            Destruction();
        }
    }

    void Destruction()
    {
        if (this.gameObject.name != "PipeTop" && this.gameObject.name != "PipeBottom")
        {
            Destroy(this.gameObject);
        }
    }
}
