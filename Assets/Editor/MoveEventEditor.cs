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
//            moveEvent.roomN = EditorGUILayout.IntField("���ȣ", moveEvent.roomN);
//            moveEvent.lookN = EditorGUILayout.IntField("������ȣ", moveEvent.lookN);

//            EditorGUILayout.Space();

//            moveEvent.camX = EditorGUILayout.FloatField("ī�޶� x pos", moveEvent.camX);
//            moveEvent.camY = EditorGUILayout.FloatField("ī�޶� y pos", moveEvent.camY);
//        }
//    }
//}
