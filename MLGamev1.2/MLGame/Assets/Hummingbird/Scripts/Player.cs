using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f; //Player Speed
    public Rigidbody player;
    public float lookSensitivity;

    private static GameManager gameManager; //access to the game manager script
    private static SoundManagerScript soundManager;





    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>(); //populates the game manager var
        }

        if (soundManager == null)
        {
            soundManager = FindObjectOfType<SoundManagerScript>(); //populates the game manager var
        }
    }


    public void FixedUpdate()
    {
        Move();
    }

    public void Move() //basic player movement
    {
        player.MoveRotation(player.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * lookSensitivity, 0)));
        player.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * speed) + (transform.right * Input.GetAxis("Horizontal") * speed));
    }
   
}
