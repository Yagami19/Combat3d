using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour {


    public GameObject Weapon;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);

        }


        if (Input.GetButtonDown("Fire1"))
        {

            if (Weapon.activeSelf == true)
            {
                Weapon.SetActive(false);
               
            }


            else if (!Weapon.activeSelf)
            {
                Weapon.SetActive(true);
            }

        }



    }






}
