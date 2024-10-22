//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(MoveEvent))]
//public class MoveEventEditor : Editor
//{

//    private MoveEvent moveEvent;

//    private void OnEnable() {
//        moveEvent = target as MoveEvent;
//    }

//    public override void OnInspectorGUI() {

//        moveEvent.moveType = (MoveType)EditorGUILayout.EnumPopup("Type", moveEvent.moveType);

//        EditorGUILayout.Space();

//        if (moveEvent.moveType == MoveType.Other) {
//            moveEvent.roomN = EditorGUILayout.IntField("방번호", moveEvent.roomN);
//            moveEvent.lookN = EditorGUILayout.IntField("시점번호", moveEvent.lookN);

//            EditorGUILayout.Space();

//            moveEvent.camX = EditorGUILayout.FloatField("카메라 x pos", moveEvent.camX);
//            moveEvent.camY = EditorGUILayout.FloatField("카메라 y pos", moveEvent.camY);
//        }
//    }
//}
