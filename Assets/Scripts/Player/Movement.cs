using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private float thrust = 5.0f;
    private float flySpeed = 0f;

    void Fail()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        GameManager.instance.failed = true;
        GameManager.instance.start = false;
        Debug.Log(GameManager.instance.failed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.StartsWith("generated"))
        {
            Fail();
        }
    }

    void Start()
    {
        flySpeed = GameManager.instance.playerSpeed;
    }

    void Update()
    {
        if (GameManager.instance.start && !GameManager.instance.failed)
        {
            rigidbody.gravityScale = 1f;
            transform.Translate(transform.right * flySpeed * Time.deltaTime);
        }
        if (transform.position.y > 5 || transform.position.y < -5)
        {
            Fail();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.instance.failed)
        {
            GameManager.instance.start = true;
            rigidbody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }

        if (!GameManager.instance.start && GameManager.instance.failed && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
