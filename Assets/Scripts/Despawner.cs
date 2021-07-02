using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{

    public GameObject Boulder;

    public static Despawner instance;

      private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //StartDespawn();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   void OnCollisionEnter2D(Collision2D collision)
   {
       if(collision.gameObject.tag == "Ground")
       {
           Destroy(gameObject, 8f);
       }
   }


}


