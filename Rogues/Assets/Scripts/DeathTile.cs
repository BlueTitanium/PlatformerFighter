using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DeathTile : MonoBehaviour
{
    public Transform startPoint;
    public int currentColorBox = 0;
    public int currentColor;
    public Transform lightColor;
    public Transform player;
    public bool playerEntered;
    // Start is called before the first frame update
    void Update()
    {
        switch (currentColor)
        {
            case 0:
                lightColor.GetComponent<Light2D>().color = Color.white;
                break;
            case 1:
                lightColor.GetComponent<Light2D>().color = Color.red;
                break;
            case 2:
                lightColor.GetComponent<Light2D>().color = Color.green;
                break;
            case 3:
                lightColor.GetComponent<Light2D>().color = Color.blue;
                break;
            default: 
                lightColor.GetComponent<Light2D>().color = Color.white;
                break;
        }
        if(playerEntered){
            currentColorBox = player.GetComponent<PlayerController>().currentColor;
            if(currentColor != currentColorBox){
                player.position = startPoint.position;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")playerEntered = true;
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")playerEntered = false;
    }
}
