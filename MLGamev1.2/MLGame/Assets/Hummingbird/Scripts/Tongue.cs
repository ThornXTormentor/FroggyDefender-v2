using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    public string colType; //holds the data of the game object in a collision
    // Start is called before the first frame update
    public string tongueState = "free";

    //public GameObject caught;

    bool isLeftClick = false;
    bool isRightClick = false;

    private float tongueLength = 5f;
    public float outSpeed = .1f;
    public float inSpeed = .2f;
    public float maxTongue = 15f;
    public float minTongue = 3f;

    public GameObject tongueObj;
    private Vector3 tongueScale;

    public GameObject caught;

    private static SoundManagerScript soundManager;
    private static GameManager gameManager;


    void Start()
    {
        if (soundManager == null)
        {
            soundManager = FindObjectOfType<SoundManagerScript>(); //populates the game manager var
        }
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>(); //populates the game manager var
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        colType = col.gameObject.tag; //holds collision data

        if (colType == "dragonfly" && tongueState == "free" && tongueLength > minTongue) //it only runs when colliding with something we care to detect
        {
            tongueState = "catch";
            Destroy(col.gameObject);
        }


    }


    void FixedUpdate()
    {
        isLeftClick = Input.GetMouseButton(0);
        isRightClick = Input.GetMouseButton(1);

        CheckInputs();
        UpdateTongue();

        CheckTongueState();

        if(tongueLength <= minTongue)
        {
            
            if(tongueState == "catch")
            {
                gameManager.SetDragonFly(1);
                soundManager.PlaySound("slurp");
                tongueState = "free";
            }
            
        }
    }

    public void CheckTongueState()
    {
        switch (tongueState)
        {
            case "catch":
                caught.SetActive(true);
                
                break;

            case "free":
                caught.SetActive(false);
                break;

            default:
                caught.SetActive(false);
                break;
        }
    }

    public void CheckInputs()
    {
        if (tongueLength < maxTongue)
        {
            if (isLeftClick && !isRightClick)
            {
                //Debug.Log("Out");
                tongueLength = tongueLength + outSpeed;
            }
        }

        if (tongueLength > minTongue)
        {
            if (isRightClick && !isLeftClick)
            {
                // Debug.Log("In");
                tongueLength = tongueLength - inSpeed;
            }
        }
    }



    public void UpdateTongue()
    {
        tongueScale = new Vector3(1f, 1f, 1f * tongueLength);

        tongueObj.transform.localScale = tongueScale;
        tongueObj.transform.localPosition = Vector3.zero;
        //Debug.Log(tongueLength);
    }
}
