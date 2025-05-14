using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Diagnostics;

public class PlayerMovement : MonoBehaviour
{
    public GameManager manager;
    public bool gameOver = false;
    public float playerSpeed = 8;
    public float jumpForce = 10;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    private Animator playerAnim;
    public new AudioManager audio;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.x > 1 || transform.position.x < -1)
        {
            transform.position = Utils.ChangeX(transform.position, 0);
        }
        //Foward Movement
        if (gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        }
        else
        {
            transform.position = transform.position;
        }
        //Jump Movement
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && gameOver == false)
        {
            if (isJumping == false)
            {
                isJumping = true;
                playerAnim.SetTrigger("Jump_trig");
                StartCoroutine(JumpSequence());

            }
        }

        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpForce, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.down * Time.deltaTime * jumpForce, Space.World);
            }
        }
    }
    public static class Utils
    {
        public static Vector3 ChangeX(Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        public static Vector3 ChangeY(Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        public static Vector3 ChangeZ(Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        comingDown = false;
        isJumping = false;
        transform.position = Utils.ChangeY(transform.position, 0.5f);
        //playerObject.GetComponent<Animator>().Play("Run");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            manager.GameOver();
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audio.stopMusic();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            manager.Congratulations();
            Debug.Log("Congratulations");
            gameOver = true;
            playerObject.GetComponent<Animator>().Play("Idle");
            playerObject.GetComponent<Animator>().speed = 0;
        }
    }
}
