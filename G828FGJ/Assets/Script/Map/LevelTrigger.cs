using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{

    [SerializeField] private Transform portalTrans;


    void OnCollisionEnter2D(Collision2D other) 
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("1212");
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");
           
                player.transform.position = portalTrans.transform.position;




        }
    }
  
}
