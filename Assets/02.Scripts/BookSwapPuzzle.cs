using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookSwapPuzzle : MonoBehaviour
{
    public Button[] buttons;
    private Image[] btnImgs = new Image[6];
    public Sprite[] books;
    [SerializeField]
    private Sprite[] anwser;
    public GameObject SetActiveF;
    public GameObject SetActiveT;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            btnImgs[i] = buttons[i].image;
            btnImgs[i].sprite = books[i];
        }
    }

    public void ChangeBook(int index)
    {
        //index : 해당 책의 위치
        //터치한 책을 바로 오른쪽의 책과 교환하는 메소드
        SortBookArray(index);
        SetButtonImgFromBooks();
        CheckBookSetting();
    } 

    void SortBookArray(int i)
    {
        if (i < (buttons.Length - 1))
        {
            Sprite temp = books[i];
            books[i] = books[i + 1];
            books[i + 1] = temp;
        }
    }

    void SetButtonImgFromBooks()
    {
        for(int i = 0; i < btnImgs.Length; i++)
        {
            btnImgs[i].sprite = books[i];
        }
    }

    void CheckBookSetting()
    {
        bool state = true;
        for (int i = 0; i < books.Length; i++)
        {
            if(books[i] != anwser[i])
            {
                state = false;
            }
        }

        if (state) // 정답이 맞다면
        {
            print("정답입니다!");
            PuzzleSoundManager.instance.SoundPlay();
            //뭔가 떨어지는 사운드
            //책 이동 막기
            //I-4 배경 변경
            SetActiveT.SetActive(true);
            SetActiveF.SetActive(false);
        }
        else
        { print("정답X"); }
    }
}
