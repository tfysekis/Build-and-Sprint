using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;
    public AudioSource jump;
    public AudioSource crawl;
    public AudioSource coinSound;
    private Animator playerAnim;
    public ParticleSystem partExplosion;
    RigidbodyConstraints rigidbodyConstraints;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = gameObject.GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        rigidbodyConstraints = playerRb.constraints;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            jump.Play();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isOnGround && gameOver == false)
        {
            //playerRb.AddForce(Vector3.fwd * jumpForce, ForceMode.Impulse);
            // isOnGround = true;
            StartCoroutine(PosFix());
            playerAnim.SetTrigger("crawl");
            crawl.Play();
        }
        gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    IEnumerator PosFix()
    {
        playerRb.constraints = RigidbodyConstraints.FreezeAll;
        gameObject.GetComponent<BoxCollider>().center = new Vector3(0,0,0);
        isOnGround = true;
        yield return new WaitForSeconds(1f);
        playerRb.constraints = rigidbodyConstraints;
        isOnGround = true;
        gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 1.5f, 0);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
            coinSound.Play();
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerRb.constraints = rigidbodyConstraints;
            gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 1.5f, 0);
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int",1);
            partExplosion.Play();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        
    }
}
