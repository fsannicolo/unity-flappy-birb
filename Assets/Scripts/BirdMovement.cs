using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapSpeed = 10;
    private bool isAlive = true;
    public LogicManager logicManager;

    public Animator animator;

    public AudioSource flapSound;

    // Start is called before the first frame update
    void Start()
    {
        //logicManager = GameObject.FindGameObjectWithTag("LogicController").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive) {
            rb.velocity = Vector2.up * flapSpeed;
            flapSound.PlayOneShot(flapSound.clip);
            animator.SetBool("flapping", true);
        }
            //rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        if (Input.GetKeyUp(KeyCode.Space) && isAlive)
            animator.SetBool("flapping", false);
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        logicManager.gameOver();
        isAlive = false;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject != null && collision.gameObject.layer == 6)
        {
            logicManager.gameOver();
            isAlive = false;
        }
    }
}
