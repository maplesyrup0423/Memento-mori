using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlashLight : MonoBehaviour
{
    Transform flashLight;

    private void Start()
    {
        flashLight = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        UpdateMousePosition();
    }

    //flashlight(Light)가 마우스 커서를 따라다니게 하는 메소드
    void UpdateMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));
        flashLight.position = pos;
    }

}