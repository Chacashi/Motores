using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D _compRigidbody2D;

    [Header("Movement")]
    [SerializeField] private float direction;
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float distanceRay;
    [SerializeField] private int numberJumpsExtra;
    public GameObject bullet;
    SpriteRenderer _compSpriteRenderer;
    [SerializeField] private bool  isGround;
    int auxJumps=0;
    private bool isStayObstacule;
    RaycastHit2D hit;

    [SerializeField] private float life;
    [SerializeField] private float maxLife;
    [SerializeField] private GameManagerController lifeBar;


    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        life = maxLife;
        lifeBar.SetLifeBar(life);
    }

    public void DecrementLife(float damage)
    {
        life -= damage;
        lifeBar.ChangueCurrentLife(life);
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet,new Vector2(this.transform.position.x, this.transform.position.y), this.transform.localRotation);
        }
        direction = Input.GetAxisRaw("Horizontal");
        hit = Physics2D.Raycast(transform.position, Vector2.down, distanceRay, groundLayer);
        if (hit.collider !=null)
        {
            isGround = true;
            auxJumps = 0;
        }
        else
        {
            isGround = false;
        }
        
        isGround = hit.collider != null;
        if (isGround && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space) && (numberJumpsExtra > auxJumps))
        {
            
            _compRigidbody2D.AddForce(new Vector2(0f,forceJump), ForceMode2D.Impulse);
            auxJumps++;
            
        }

    }
    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(direction * speed,_compRigidbody2D.velocity.y);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distanceRay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.tag == "Enemy") 
            {

            DecrementLife(lifeBar.GetComponent<GameManagerController>().GetDamageEnemys());

        }
        if(collision !=null && collision.gameObject.tag == "Red")
        {
            isStayObstacule = true;
            if (_compSpriteRenderer.color != Color.red)
            {
                DecrementLife(lifeBar.GetComponent<GameManagerController>().GetDamageEnemys());
            }
            
        }

        if (collision != null && collision.gameObject.tag == "Blue")
        {
            isStayObstacule = true;
            if (_compSpriteRenderer.color != Color.blue)
            {
                DecrementLife(lifeBar.GetComponent<GameManagerController>().GetDamageEnemys());
            }

        }

        if (collision != null && collision.gameObject.tag == "Yellow")
        {
            isStayObstacule = true;
            if (_compSpriteRenderer.color != Color.yellow)
            {
                DecrementLife(lifeBar.GetComponent<GameManagerController>().GetDamageEnemys());
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision!= null && collision.gameObject.layer == 6)
        {
            isStayObstacule = false;
            
            
        }
        
    }

     public bool GetIsStayObstacule() 
    { return isStayObstacule; }

}
