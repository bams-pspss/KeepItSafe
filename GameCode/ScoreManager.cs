using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score;
    public TextMeshProUGUI countingScore;
   private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Collectibles"))
        {
           score += 1;
           print(score);
           Destroy(collision.gameObject);
        }
    }
}
