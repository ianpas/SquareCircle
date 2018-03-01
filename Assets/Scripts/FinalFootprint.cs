using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalFootprint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var records = collision.gameObject.GetComponent<SampleAnimation>().m_Records;
        var mark_objects = GameObject.FindGameObjectsWithTag("Mark");

        //sort by parent name if in square game
        if (SceneManager.GetActiveScene().name == "Level Square")
        {
            Array.Sort
            (
                mark_objects,
                delegate (GameObject mark1, GameObject mark2)
                {
                    return Convert.ToInt32(mark1.transform.parent.name).CompareTo(Convert.ToInt32(mark2.transform.parent.name));
                }
            );

            Debug.Log("is square game");
        }


        var marks = new List<float>();
        for (int i = 0; i < 24; ++i)
        {
            var position = mark_objects[i].transform.position;
            var distance = Vector3.Distance(Vector3.zero, position);
            marks.Add(distance);
            Debug.Log(mark_objects[i].transform.parent.name);
        }

        int count = Math.Min(marks.Count, records.Count);

        float dot = 0;
        if (count < 24)
        {
            while (records.Count != 24)
            {
                records.Add(0);
            }
        }

        for (int i = 0; i < 24; ++i)
        {
            dot += marks[i] * records[i];
        }

        m_Cos = dot / (Module(marks) * Module(records));

        //
        FindObjectOfType<GameManager>().EndGame();
    }

    static float Module(List<float> v)
    {
        float module_square = 0f;
        foreach (var each in v)
        {
            module_square += Mathf.Pow(each, 2);
        }
        return Mathf.Sqrt(module_square);
    }

    public float m_Cos;
}
