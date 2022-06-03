using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Update()
    {


       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                StartCoroutine(x());
                return;

            }



    }
   
 

 
    IEnumerator x()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("OYUN");
    }

}
