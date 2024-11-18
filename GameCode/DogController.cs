using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            print("The Dawg");
            animator.SetBool("Cat", true);
        }
    }
     public void OnCollisionExit2D(Collision2D collision){
        animator.SetBool("Cat", false);
        print("No Dawgh");
        
    }
}
