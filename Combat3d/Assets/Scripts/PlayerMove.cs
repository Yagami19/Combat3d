using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
    // private Rigidbody rb;
    public static int speed;
    float currentspeed;
    float maxspeed;
    public GameObject projectile;
    public GameObject spawner;
    public GameObject projectileClone = null;


    //setting score of opponent
    public Text P2Score;
    public int P2ScoreValue;



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Opponent")
        {
            P2ScoreValue++;
            P2Score.text = " " + P2ScoreValue;


        }
    }



    // Use this for initialization
    void Start () {
        // speed = 1600;

        float speed = 0.05f;
        maxspeed = 20;
        currentspeed = 0f;
       // maxspeed = 4500f;
      //  rb = GetComponent<Rigidbody>();
        




    }


    public float cooldownTime = 0.5f;
    private float nextFireTime = 0;
    // Update is called once per frame
    void Update () {




        
        //shooting



        if (Input.GetButtonUp("Fire1"))
        {

            if (Time.time > nextFireTime)
            {
                projectileClone = Instantiate(projectile, spawner.transform.position, spawner.transform.rotation);
                projectileClone.GetComponent<Rigidbody>().AddForce(spawner.transform.forward * 5000);
                Destroy(projectileClone, 5.0f);
                nextFireTime = Time.time + cooldownTime;



            }
        }



        //













        //

        transform.position += transform.forward * Time.deltaTime * currentspeed;
        
        //

        if (currentspeed > 0)
        {
          
            currentspeed -= 10 *Time.deltaTime;
        }

        if (currentspeed < 0)
        {

            currentspeed += 10 * Time.deltaTime;
        }


        transform.Rotate(-Input.GetAxis("Mouse Y")*5.0f, Input.GetAxis("Mouse X")*5.0f, 0.1f);
        if (Input.GetButton("Left"))
        {
            transform.Rotate(0.0f, 0.0f, 2.5f);
        }

        if (Input.GetButton("Right"))
        {
            transform.Rotate(0.0f, 0.0f, -2.5f);
        }


        if (Input.GetButton("Forward"))
        {
            if (currentspeed <= maxspeed && currentspeed >= (maxspeed * -1))
            {
               // transform.position += transform.forward * Time.deltaTime* currentspeed;
                    currentspeed = currentspeed + (1f * Time.deltaTime * speed);


                //rb.AddForce(transform.forward * Time.deltaTime * speed);
            }
            else;
            {
                currentspeed = maxspeed;
            }

        }


        if (Input.GetButton("Backward"))
        {
            if (currentspeed <= maxspeed && currentspeed >= (maxspeed * -1))
            {

               // rb.AddForce(transform.forward * Time.deltaTime * speed * -1);
                currentspeed = currentspeed + (1f * Time.deltaTime * speed * -1);
            }
            else;
            {
                currentspeed = -1 * maxspeed;
            }
        }





    }



}
