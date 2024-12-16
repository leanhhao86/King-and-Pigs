using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grounded : MonoBehaviour
{
    private GameObject player;
    private string GROUND_TAG = "Ground";
    private string[] Surfaces = {"Ground", "Platform", "Obstacle", "Enemy"};
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Surfaces.Contains(collider.gameObject.tag))
        {
            player.GetComponent<Player>().onGround = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Surfaces.Contains(collider.gameObject.tag))
        {
            player.GetComponent<Player>().onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (Surfaces.Contains(collider.gameObject.tag))
        {
            player.GetComponent<Player>().onGround = false;
        }
    }
}
