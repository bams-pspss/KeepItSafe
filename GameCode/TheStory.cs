using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TheStory : MonoBehaviour
{
    public string level;
    void OnEnable()
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
