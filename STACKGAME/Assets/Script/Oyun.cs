using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oyun : MonoBehaviour
{
    public GameObject CurrentCube;
    public GameObject LastCube;

    public Text Text;
   
    public int Level;
    public bool Done;
    public int sayac;
   

   
    void Start()
    {
     
       
        newBlock();
       
           

        
    }
    private void newBlock()
    {
        if (LastCube!=null)
        {
            CurrentCube.transform.position = new Vector3(Mathf.Round(CurrentCube.transform.position.x),
                CurrentCube.transform.position.y,
                Mathf.Round(CurrentCube.transform.position.z));
            CurrentCube.transform.localScale = new Vector3(LastCube.transform.localScale.x - Mathf.Abs(CurrentCube.transform.position.x - LastCube.transform.position.x),
                                                           LastCube.transform.localScale.y,
                                                           LastCube.transform.localScale.z - Mathf.Abs(CurrentCube.transform.position.z - LastCube.transform.position.z));
            CurrentCube.transform.position = Vector3.Lerp(CurrentCube.transform.position,LastCube.transform.position,0.5f)+Vector3.up *5f;
            if (CurrentCube.transform.localScale.x<=0f || CurrentCube.transform.localScale.z <= 0f)
            {
             
                Done = true;
                StartCoroutine(x());
                Text.gameObject.SetActive(true);
                Text.text = "Your Score: " + Level;

                return;

            }
            else
            {
                if(Input.GetMouseButtonDown(0))
                {
                    sayac++;

                }
                Text.text = sayac.ToString();
            }
            
        }
        LastCube = CurrentCube;
        CurrentCube = Instantiate(LastCube);
        CurrentCube.name = Level + "";
        CurrentCube.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.HSVToRGB((Level/50f)%1f,1f,1f));
       
        Level++;
        Camera.main.transform.position = CurrentCube.transform.position + new Vector3(200 , 200   , 200);
        Camera.main.transform.LookAt(CurrentCube.transform.position);



    }
    
    void Update()
    {

        if (Done)
            return;
        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);
        var pos1 = LastCube.transform.position + Vector3.up * 10f;
        var pos2 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;
        if (Level % 2 == 0)
            CurrentCube.transform.position = Vector3.Lerp(pos2, pos1, time);
        else
            CurrentCube.transform.position = Vector3.Lerp(pos1, pos2, time);

        if (Input.GetMouseButtonDown(0))
            newBlock();
    }
    IEnumerator x()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("RESTART");
      
    }

}
