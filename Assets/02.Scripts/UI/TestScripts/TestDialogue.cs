using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{

    [SerializeField]
    public Dialogue dialogue;

    private TextWindow theDM;


    // Use this for initialization
    void Start()
    {
        theDM = FindObjectOfType<TextWindow>();
    }

    private void OnMouseDown() {
        if (gameObject.CompareTag("DialogObj") && !theDM.talking)
            theDM.ShowDialogue(dialogue);
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.gameObject.name == "Player")        // && theDoor.ButtonPress == true
    //    {
    //        theDM.ShowDialogue(dialogue);
    //        //theDoor.ButtonPress = false;
    //    }

    //}

}
