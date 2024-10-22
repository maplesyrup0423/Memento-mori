using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWindow : MonoBehaviour
{
    public bool nextCheck = false;

    public static TextWindow instance;

    #region Singleton
    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        DontDestroyOnLoad(this.gameObject);
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    #endregion Singleton

    public Text text;

    public GameObject dialog;

    public Button nextBtn;

    private List<string> listSentences;


    private int count; //대화 진행상황 카운트


    public bool talking = false;
    private bool KeyActivated = false;
    private bool onlyText = false;

    // Use this for initialization
    void Start()
    {
        count = 0;
        text.text = "";
        listSentences = new List<string>();

        nextBtn.onClick.AddListener(NextButtonCick);
    }

    public void ShowText(string[] _sentences)
    {
        talking = true;
        onlyText = true;

        for (int i = 0; i < _sentences.Length; i++)
        {
            listSentences.Add(_sentences[i]);
            //listName.Add(_sentences[i]);
        }

        StartCoroutine(StartTextCoroutine());
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        dialog.SetActive(true);
        talking = true;
        onlyText = false;

        ShowText(dialogue.sentences);

        StartCoroutine(StartDialogueCoroutine());
    }

    public void ExitDialogue()
    {
        text.text = "";
        count = 0;
        listSentences.Clear();
        dialog.SetActive(false);
        talking = false;
    }

    IEnumerator StartTextCoroutine()
    {

        KeyActivated = true;
        //nameText.text = listName[count];
        for (int i = 0; i < listSentences[count].Length; i++)
        {
            text.text += listSentences[count][i]; // 한 글자씩 출력
            if (i % 7 == 1)
            {
                //theAudio.Play(typeSound);
            }
            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator StartDialogueCoroutine() {
        if (count > 0) {
            KeyActivated = true;
            //nameText.text = listName[count];
            for (int i = 0; i < listSentences[count].Length; i++) {
                text.text += listSentences[count][i]; // 한 글자씩 출력
                if (i % 7 == 1) {
                    // theAudio.Play(typeSound);
                }
                yield return new WaitForSeconds(0.01f);
            }

        }
    }

    // Update is called once per frame
    void Update() {
        if (talking && KeyActivated) {
            if (nextCheck == true) {
                KeyActivated = false;
                count++;
                text.text = "";
                if (count == listSentences.Count) {
                    StopAllCoroutines();
                    ExitDialogue();
                } else {
                    StopAllCoroutines();
                    if (onlyText) {
                        StartCoroutine(StartTextCoroutine());
                    } else
                        StartCoroutine(StartDialogueCoroutine());
                }
            }
            nextCheck = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
            NextButtonCick();
    }

    public void NextButtonCick() {
        nextCheck = true;
    }
}
