using UnityEngine;
using System.Collections;

public class Controls {

    public static Vector2 GetDirection(int playerNum)
    {
        float xAxis = 0;
        float yAxis = 0;

        Debug.Log(Input.GetAxis("P1 Horizontal"));

        if (playerNum == 0)
        {
            xAxis = Input.GetAxis("P1 Horizontal");
            yAxis = Input.GetAxis("P1 Vertical");
        }
        else if (playerNum == 1)
        {
            xAxis = Input.GetAxis("P2 Horizontal");
            yAxis = Input.GetAxis("P2 Vertical");
        }
        else if (playerNum == 2)
        {
            xAxis = Input.GetAxis("P3 Horizontal");
            yAxis = Input.GetAxis("P3 Vertical");
        }
        else if (playerNum == 3)
        {
            xAxis = Input.GetAxis("P4 Horizontal");
            yAxis = Input.GetAxis("P4 Vertical");
        }
        return new Vector2(xAxis, yAxis);
    }

    public static Parameters.InputDirection GetInputDirection(int playerNum)
    {
        return Parameters.vectorToDirection(GetDirection(playerNum));
    }

    public static bool YInputDown(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButtonDown("P1 Y");
        else if (playerNum == 1)           
            return Input.GetButtonDown("P2 Y");
        else if (playerNum == 2)           
            return Input.GetButtonDown("P3 Y");
        else if (playerNum == 3)           
            return Input.GetButtonDown("P4 Y");
        else
            return false;
    }

    public static bool XInputDown(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButtonDown("P1 X");
        else if (playerNum == 1)           
            return Input.GetButtonDown("P2 X");
        else if (playerNum == 2)           
            return Input.GetButtonDown("P3 X");
        else if (playerNum == 3)           
            return Input.GetButtonDown("P4 X");
        else
            return false;
    }

    public static bool AInputDown(int playerNum)
    {
        if (playerNum == 0)
        {
            Debug.Log("what");
            Debug.Log(Input.GetButtonDown("P1 A"));
            return Input.GetButtonDown("P1 A");
        }
        else if (playerNum == 1)
            return Input.GetButtonDown("P2 A");
        else if (playerNum == 2)
            return Input.GetButtonDown("P3 A");
        else if (playerNum == 3)
            return Input.GetButtonDown("P4 A");
        else
            return false;
    }

    public static bool BInputDown(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButtonDown("P1 B");
        else if (playerNum == 1)           
            return Input.GetButtonDown("P2 B");
        else if (playerNum == 2)           
            return Input.GetButtonDown("P3 B");
        else if (playerNum == 3)           
            return Input.GetButtonDown("P4 B");
        else
            return false;
    }

    public static bool RInputDown(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButtonDown("P1 R");
        else if (playerNum == 1)           
            return Input.GetButtonDown("P2 R");
        else if (playerNum == 2)           
            return Input.GetButtonDown("P3 R");
        else if (playerNum == 3)           
            return Input.GetButtonDown("P4 R");
        else
            return false;
    }

    public static bool LInputDown(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButtonDown("P1 L");
        else if (playerNum == 1)           
            return Input.GetButtonDown("P2 L");
        else if (playerNum == 2)           
            return Input.GetButtonDown("P3 L");
        else if (playerNum == 3)           
            return Input.GetButtonDown("P4 L");
        else
            return false;
    }

    public static bool ZInputDown(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButtonDown("P1 Z");
        else if (playerNum == 1)           
            return Input.GetButtonDown("P2 Z");
        else if (playerNum == 2)           
            return Input.GetButtonDown("P3 Z");
        else if (playerNum == 3)           
            return Input.GetButtonDown("P4 Z");
        else
            return false;
    }

    public static bool pauseInputDown(int playerNum)
    {
        return Input.GetButtonDown("Pause");
    }


    public static bool YInputHeld(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButton("P1 Y");
        else if (playerNum == 1)
            return Input.GetButton("P2 Y");
        else if (playerNum == 2)
            return Input.GetButton("P3 Y");
        else if (playerNum == 3)
            return Input.GetButton("P4 Y");
        else
            return false;
    }

    public static bool XInputHeld(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButton("P1 X");
        else if (playerNum == 1)
            return Input.GetButton("P2 X");
        else if (playerNum == 2)
            return Input.GetButton("P3 X");
        else if (playerNum == 3)
            return Input.GetButton("P4 X");
        else
            return false;
    }

    public static bool AInputHeld(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButton("P1 A");
        else if (playerNum == 1)
            return Input.GetButton("P2 A");
        else if (playerNum == 2)
            return Input.GetButton("P3 A");
        else if (playerNum == 3)
            return Input.GetButton("P4 A");
        else
            return false;
    }

    public static bool BInputHeld(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButton("P1 B");
        else if (playerNum == 1)
            return Input.GetButton("P2 B");
        else if (playerNum == 2)
            return Input.GetButton("P3 B");
        else if (playerNum == 3)
            return Input.GetButton("P4 B");
        else
            return false;
    }

    public static bool RInputHeld(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButton("P1 R");
        else if (playerNum == 1)
            return Input.GetButton("P2 R");
        else if (playerNum == 2)
            return Input.GetButton("P3 R");
        else if (playerNum == 3)
            return Input.GetButton("P4 R");
        else
            return false;
    }

    public static bool LInputHeld(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButton("P1 L");
        else if (playerNum == 1)
            return Input.GetButton("P2 L");
        else if (playerNum == 2)
            return Input.GetButton("P3 L");
        else if (playerNum == 3)
            return Input.GetButton("P4 L");
        else
            return false;
    }

    public static bool ZInputHeld(int playerNum)
    {
        if (playerNum == 0)
            return Input.GetButton("P1 Z");
        else if (playerNum == 1)
            return Input.GetButton("P2 Z");
        else if (playerNum == 2)
            return Input.GetButton("P3 Z");
        else if (playerNum == 3)
            return Input.GetButton("P4 Z");
        else
            return false;
    }

    public static bool pauseInputHeld(int playerNum)
    {
        return Input.GetButton("Pause");
    }
}
