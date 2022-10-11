using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputParams : Singleton<InputParams>
{
    [SerializeField] private Transform movePositionPoint;
    [SerializeField] private TMP_Text xPosition;
    [SerializeField] private TMP_Text zPosition;
    [SerializeField] private TMP_Text inputTime;
    [SerializeField] private TMP_Text inputSpeed;

    private Vector3 movePosition;
    private float currentTime;
    private float currentSpeed;

    public Vector3 MovePosition => movePosition;
    public float CurrentTime => currentTime;
    public float CurrentSpeed => currentSpeed;

    public void ApplyParam ()
    {
        SetPosition();
        SetTime();
        SetSpeed();
    }

    private void SetPosition ()
    {
        float valueX = FloatParce.ParceToVector3(xPosition.text);
        float valueZ = FloatParce.ParceToVector3(zPosition.text);

        movePosition = new Vector3(valueX, 0 ,valueZ);

        movePositionPoint.position = movePosition;
    }
    private void SetTime()
    {
        currentTime = FloatParce.ParceToTime(inputTime.text);
    }
    private void SetSpeed()
    {
        currentSpeed = FloatParce.ParceToTime(inputSpeed.text);
    }
}

public static class FloatParce
{
    // Если метод не смог конвертнуть полученный текст в число, то вернёт ноль. Сделал для удобства и что бы не городить миллиард проверок
    //* Все возможные ошибки и дропы вроде обработаны
    public static float ParceToVector3 (string text)
    {
        string result = "";

        bool comma = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i]))
            {
                result += text[i];
            }
            else if (!comma && (Convert.ToString(text[i]) == "." || Convert.ToString(text[i]) == ","))
            {
                result += ",";
                comma = true;
            }
            else if (Convert.ToString(text[i]) == "-" && i == 0)
            {
                result = "-";
            }
        }

        if (result.Length == 0 || (result.Length == 0 && Convert.ToString(result[0]) == "-"))
        {
            result = "0";
        }
        if ((Convert.ToString(result[result.Length - 1]) == "," || Convert.ToString(result[result.Length - 1]) == "."))
        {
            result += "0";
        }

        return Convert.ToSingle(result);
    }
    public static float ParceToTime(string text)
    {
        string result = "";

        bool comma = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i]))
            {
                result += text[i];
            }
            else if (!comma && (Convert.ToString(text[i]) == "." || Convert.ToString(text[i]) == ","))
            {
                result += ",";
                comma = true;
            }
        }

        if ((Convert.ToString(result[result.Length - 1]) == "," || Convert.ToString(result[result.Length - 1]) == "."))
        {
            result += "0";
        }

        return Convert.ToSingle(result);
    }
}
