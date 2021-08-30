using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
   public void Destroy()
   {
      
      print("Destroy");
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.GetComponent<MovementCharacter>() != null)
      {
         Destroy(gameObject);
      }
   }
}
