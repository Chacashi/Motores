using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class buttomController : MonoBehaviour
{
    public GameObject player;
    Button myButton;

    void Awake()
    {
        myButton = GetComponent<Button>();  
        
    }
    
    private void FixedUpdate()
    {
        
           
        myButton.onClick.AddListener(OnClick);
        
    }


    void OnClick()
    {
        if (player.GetComponent<playerController>().GetIsStayObstacule() == false) { 
        if (myButton.gameObject.tag == "Red") 
        {
            
        player.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (myButton.gameObject.tag == "Blue")
        {
            player.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if (myButton.gameObject.tag == "Yellow")
        {
            player.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        }
    }
}
