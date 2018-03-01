using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarksManager : MonoBehaviour
{

    public void Hide()
    {
        if (transform.position.y > -85.7)
        {
            transform.position -= new Vector3(0, 0.005f, 0);
        }
    }

    public void Show()
    {
        if (transform.position.y < -85.3)
        {
            transform.position += new Vector3(0, 0.005f, 0);
        }
    }
}
