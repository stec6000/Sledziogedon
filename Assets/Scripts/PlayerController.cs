using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Transform cameraTransform;
    private Vector2 cameraHalfWidthHeight;

    private float life = 100f;
    private int jumpCounter;

    private bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    private int moveAble = 0;

    public bool facingRight = true;
    public float speed = 10f;
    public float jumpForce = 700f;

    private Rigidbody2D rig;
    public Slider healthSlider;
    private Animator anim;

    private SwimBuff swimBuff = null;
    private int swimDirection = 0;

    private Score score;

    void Start () {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        cameraHalfWidthHeight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        cameraHalfWidthHeight -= new Vector2(cameraTransform.position.x, cameraTransform.position.y);

        score = GameObject.FindGameObjectWithTag("score").GetComponent<Score>();
    }
	
	void Update () {
        if (life > 0)
        {
            if (swimBuff == null)
            {
                if ((grounded || jumpCounter == 1) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    anim.SetBool("Grounded", false);
                    jumpCounter++;
                    rig.velocity = new Vector2(rig.velocity.x, 9);
                }
                if (jumpCounter == 2) jumpCounter = 0;
            }
            else
            {
                swimDirection = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    swimDirection = 1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    swimDirection = -1;
                }
            }

            if (gameObject.GetComponent<HealBuff>() != null)
            {
                life += 0.1f;
                if (life > 100)
                    life = 100;
                healthSlider.value = life;
            }
        }
            OutOfCamera();
    }

    void FixedUpdate()
    {
        if (life > 0)
        {
            swimBuff = gameObject.GetComponent<SwimBuff>();
            if (swimBuff != null)
            {
                if (swimDirection > 0)
                {
                    if (transform.position.y < 62)
                        rig.AddForce(transform.up * 30);
                }
                else if (swimDirection < 0)
                {
                    rig.AddForce(transform.up * -30);
                }
            }

            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("Grounded", grounded);

            float move = Input.GetAxis("Horizontal");
            if (move != 0) anim.SetBool("Move", true);
            else anim.SetBool("Move", false);

            if (move > 0)
            {
                gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
                //rig.AddForce(transform.right * 40);
            }
            else if (move < 0)
            {
                gameObject.transform.position -= Vector3.right * Time.deltaTime * speed;
                //rig.AddForce(transform.right * -40);
            }
            else if (grounded)
            {
                rig.velocity = new Vector2(0, rig.velocity.y);
            }

            if (Mathf.Abs(rig.velocity.x) > 4.5f || Mathf.Abs(rig.velocity.y) > 10f)
            {
                rig.velocity = new Vector2((rig.velocity.normalized * 4.5f).x, rig.velocity.y);
            }
            if (rig.velocity.y < -8f)
            {
                rig.velocity = new Vector2(rig.velocity.x, (rig.velocity.normalized * 8f).y);
            }
            if (swimBuff != null && Mathf.Abs(rig.velocity.y) > 6f)
            {
                rig.velocity = new Vector2(rig.velocity.x, (rig.velocity.normalized * 6f).y);
            }

            if (move > 0 && !facingRight) Flip();
            else if (move < 0 && facingRight) Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "fish")
        {
            ShieldBuff shieldBuff = gameObject.GetComponent<ShieldBuff>();
            if (shieldBuff == null)
            {
                if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
                {
                    foreach (GameObject fish in GameObject.FindGameObjectsWithTag("fish"))
                    {
                        fish.GetComponent<singleFish>().animationDestroy();
                    }
                    Destroy_();
                }
                else
                {
                    col.gameObject.GetComponent<singleFish>().animationDestroy();
                    life -= 4;
                    healthSlider.value = life;
                    if (life <= 0)
                    {
                        Destroy_();
                        GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>().setActiveCanvas("Canvas");
                    }
                }
            }
        }

        if (col.gameObject.tag == "star")
        {
            score.addPoints(1);
            Destroy(col.gameObject);
        }
    }

    void Destroy_()
    {
        swimBuff = gameObject.GetComponent<SwimBuff>();
        if (swimBuff != null)
            Utils.FindObjectInChildWithTag(gameObject, "fishSwimmer").GetComponent<fishSwimmer>().animationDestroy();
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        gameObject.GetComponent<Animator>().SetBool("dead", true);
        gameObject.AddComponent<AnimationAutoDestroy>();
        gameObject.transform.tag = "Untagged";
        Destroy(gameObject.GetComponent<PlayerController>());
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OutOfCamera()
    {
        if (cameraTransform.position.x - cameraHalfWidthHeight.x > transform.position.x + 0.5f)
        {
            Destroy(gameObject);
        }
        else if (cameraTransform.position.y - cameraHalfWidthHeight.x > transform.position.y + 0.5f)
        {
            Destroy(gameObject);
        }
    }

    public void setMoveable(int set)
    {
        moveAble = set;
    }
}
