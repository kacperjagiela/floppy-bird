using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Camera;
    public Transform Player;
    // Update is called once per frame
    void Update()
    {
        Camera.position = new Vector3(Player.position.x + 4f, 0, -10f);
    }
}
