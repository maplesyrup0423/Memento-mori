using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {
    public Transform[] wayPoint;

    [HideInInspector]
    public int pointNum = 0;
    [SerializeField]
    private float move_Speed = 3f;

    private void FixedUpdate() {
        ToMove();
    }

    public void ToMove() {

        transform.position = Vector3.MoveTowards
            (transform.position, wayPoint[pointNum].transform.position, move_Speed * Time.deltaTime);

        ChangeNextMovePoint();
    }

    public void ChangeNextMovePoint() {

        if (transform.position == wayPoint[pointNum].transform.position)
            pointNum++;

        if (pointNum == wayPoint.Length)
            pointNum = 0;

    }
}