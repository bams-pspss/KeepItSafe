using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string theScene;
    public bool end;
   public void OnCollisionEnter2D(Collision2D collision) 
   {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("Change Scene");
            SceneManager.LoadSceneAsync(this.theScene);
        }

   }
}
