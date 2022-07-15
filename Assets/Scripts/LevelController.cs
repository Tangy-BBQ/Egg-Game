using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -10)
        {
            player.transform.position = new Vector2(-11, 1);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.GetComponent<Rigidbody2D>().rotation = 0;
        }
    }
}
