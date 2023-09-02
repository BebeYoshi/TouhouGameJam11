using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    [SerializeField] private GameObject player;

    public static Vector2 checkPoint = Vector2.zero;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Respawn")
        {
            checkPoint = col.gameObject.transform.position;
            col.gameObject.SetActive(false);
        }
    }
    

    public void Reincarnate()
    {
        player.transform.position = checkPoint;
    }

}