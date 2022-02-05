using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 200f;
    public int oofs = 3; 

    bool isDead = false;

    private Rigidbody2D rb;
    private Animator anim;
    private PolygonCollider2D poliCol;
    private SpriteRenderer spriteboi; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        poliCol = GetComponent<PolygonCollider2D>();
        spriteboi = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            if (Input.GetButtonDown("FLAP"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "column")
        {
            oofs--; 
            if(oofs <= 0)
            {
                anim.SetTrigger("Die");
                rb.velocity = Vector2.zero;
                isDead = true;
                GameControl.instance.BirdDied(); 
            }
            else
            {
                poliCol.enabled = false;
                spriteboi.color = new Color(1, 0, 0, 0.5f);
                StartCoroutine(EnableBox(1.0F)); 
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("Die");

            GameControl.instance.BirdDied();
        }
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        poliCol.enabled = true;
        spriteboi.color = new Color(1, 1, 1, 1);
    }
}
