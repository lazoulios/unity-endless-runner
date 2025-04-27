using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Diagnostics;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    public float jumpForce = 10;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    void Start()
    {
    }

    void Update()
    {
        //Foward Movement
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        //Jump Movement
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (isJumping == false)
            {
                isJumping = true;
                //playerObject.GetComponent<Animator>().Play("Jump");
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
}
