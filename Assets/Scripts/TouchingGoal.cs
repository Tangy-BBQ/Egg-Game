using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchingGoal : MonoBehaviour
{
    public GameObject goal;
    public bool touchingGoal;
    public GameObject panel;

    void Start()
    {
        touchingGoal = false;
        panel.SetActive(false);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Toast")
        {
            touchingGoal = true;
            panel.SetActive(true);
        }
    }
}
