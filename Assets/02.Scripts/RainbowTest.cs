using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RainbowTest : MonoBehaviour
{
    //private GameObject square, circle, dia, hexagon;
    private Text squareText, circleText, diaText, hexagonText;
    private int squareCnt, circleCnt, diaCnt, hexagonCnt;
    private const string ANSWER = "3000";
    private string userAnswer = "";
    // Start is called before the first frame update
    void Start()
    {
        //square = GameObject.Find("Square");
        //circle = GameObject.Find("Circle");
        //dia = GameObject.Find("Dia");
        //hexagon = GameObject.Find("Hexagon");

        squareText = GameObject.Find("SquareText").GetComponent<Text>();
        circleText = GameObject.Find("CircleText").GetComponent<Text>();
        diaText = GameObject.Find("DiaText").GetComponent<Text>();
        hexagonText = GameObject.Find("HexagonText").GetComponent<Text>();

        squareCnt = circleCnt = diaCnt =  hexagonCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                GameObject obj = hit.collider.gameObject;
                switch (obj.name)
                {
                    case "Square":
                        squareText.text = "square : " + ++squareCnt;
                        break;
                    case "Circle":
                        circleText.text = "circle : " + ++circleCnt;
                        break;
                    case "Dia":
                        diaText.text = "dia : " + ++diaCnt;
                        break;
                    case "Hexagon":
                        hexagonText.text = "hexagon : " + ++hexagonCnt;
                        break;
                    case "Submit":
                        userAnswer = string.Format("{0}{1}{2}{3}", squareCnt, circleCnt, diaCnt, hexagonCnt);
                        Debug.Log(userAnswer);
                        if (userAnswer.Equals(ANSWER))
                        {
                            SceneManager.LoadScene("Clock");
                        }
                        else
                        {
                            userAnswer = "";
                            squareCnt = circleCnt = diaCnt = hexagonCnt = 0;
                            squareText.text = "square : " + squareCnt;
                            circleText.text = "circle : " + circleCnt;
                            diaText.text = "dia : " + diaCnt;
                            hexagonText.text = "hexagon : " + hexagonCnt;
                        }
                        break;
                }
            }
        }
    }
}
