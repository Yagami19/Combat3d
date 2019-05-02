using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpponentMove : MonoBehaviour {
    private Rigidbody rb;
    public static int speed;
    float currentspeed;
    float maxspeed;
    public GameObject projectile;
    public GameObject spawner;
    public GameObject projectileClone = null;





    //setting score of player
    public Text P1Score;
    public int P1ScoreValue;

    public Transform target;







    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            P1ScoreValue++;
            P1Score.text = " " + P1ScoreValue;


        }



    }

   






    // Use this for initialization
    void Start () {
 




    }

    // targeting player

















    public float cooldownTime = 1;
    private float nextFireTime = 0;
  

   private float nextRotationTime = 0;
    private float nextRotationTimeSetup = 0;




    // Update is called once per frame
    void Update () {

        // jezeli obecny czas < czasu potrzebnego na rotacje to rotuj

        
        


        if (Time.time == nextRotationTimeSetup)
            nextRotationTime = Time.time + 2.5f;

        int x = Random.Range(-1, 1);
        {
            if (Time.time < nextRotationTime)


            {
                transform.Rotate(2.5f*x, 0.0f, 0.0f);
                
                

            }

            nextRotationTimeSetup = Time.time + 2.5f;
        }



        //defining ray 
        RaycastHit hit;
               Vector3 forward = transform.TransformDirection(Vector3.forward);

        





            //add cooldown, add randomizer rotation

            Ray collisionRay = new Ray(this.transform.position, forward);

        if (Physics.Raycast(collisionRay, out hit, 30))
        {
            
            if(hit.collider.tag == "wall")
            {

               

                transform.Rotate(0.0f, 2.5f, 0.0f);

              //  Debug.Log("hit");
            }
        }


        if (Physics.Raycast(collisionRay, out hit, 250))
        {

            if (hit.collider.tag == "PlayerBody")
            {
                if (Time.time > nextFireTime)

                {

                    nextFireTime = Time.time + cooldownTime;

                    projectileClone = Instantiate(projectile, spawner.transform.position, spawner.transform.rotation);
                    projectileClone.GetComponent<Rigidbody>().AddForce(spawner.transform.forward * 5000);
                    Destroy(projectileClone, 5.0f);




                }
            }

        }



        transform.position += transform.forward * Time.deltaTime * 15;





    }

    void OnTriggerStay(Collider other)

    {

        if (other.gameObject.tag == "PlayerBox" && Time.time > nextFireTime)
        {
            transform.LookAt(target);


        }





    }



}
