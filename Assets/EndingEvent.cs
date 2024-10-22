using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingEvent : MonoBehaviour
{
    public GameObject mainUI;
    public AudioSource audioSource;

    [SerializeField]
    public Dialogue dialogue1;

    [SerializeField]
    public Dialogue dialogue2;

    [SerializeField]
    public Dialogue dialogue3;

    private TextWindow theDM;


    // Use this for initialization
    void Start()
    {
        theDM = FindObjectOfType<TextWindow>();

    }

    private void OnEnable()
    {
        StartCoroutine("Ending");
    }

    IEnumerator Ending()
    {
        mainUI.SetActive(false);
        audioSource.Play();
        yield return new WaitForSeconds(3.0f);
        audioSource.Stop();
        theDM.text.color = Color.green;
        theDM.ShowDialogue(dialogue1);
        yield return new WaitForSeconds(20.0f);
        theDM.ShowDialogue(dialogue2);
        yield return new WaitForSeconds(20.0f);
        theDM.text.color = Color.red;
        theDM.ShowDialogue(dialogue3);
    }
}
