using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ColorableTileEffect : MonoBehaviour
{
    public int currentColorBox = 0;
    public Transform lightColor;
    public Transform player;
    public bool playerEntered;

    // Update is called once per frame
    void Update()
    {
        if(playerEntered){
            currentColorBox = player.GetComponent<PlayerController>().currentColor;
            switch (currentColorBox)
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
        }
    }
    //void OnTriggerStay2D(Collider2D other) {
    //    currentColorBox = other.gameObject.GetComponent<PlayerController>().currentColor;
    //}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")playerEntered = true;
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player")playerEntered = false;
    }
}
