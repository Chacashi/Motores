using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class bulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float direction;
    Rigidbody2D _compRigidbody2D;


    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(speed * direction, _compRigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.tag=="Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision != null && collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject, 5);
        }

    }
}
