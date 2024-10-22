using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorLight : MonoBehaviour
{
    public void SwitchRedState()
    {
        ColorManager.instance.redState = !ColorManager.instance.redState;
    }

    public void SwitchGreenState()
    {
        ColorManager.instance.greenState = !ColorManager.instance.greenState;
    }

    public void SwitchBlueState()
    {
        ColorManager.instance.blueState = !ColorManager.instance.blueState;
    }

}
