using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineConnection : MonoBehaviour
{

    public Transform Parent;     public GameObject gameObj;
    List<float> positionsY = new List<float>() { };
    //float elapsed = 0f;
    //public GameObject objPrefab;
    //LineRenderer lineRenderer;

    public void Start()
    {
        for (int i = 0; i < 2000; i++)
        {
            positionsY.Add(Random.Range(0f, 40f));
        }
    }


    float elapsed = 0f;
    int i = 0;
    void Update()
    {
        elapsed += Time.deltaTime;

            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                i += 1;
                OutputTime(i);
            }


    }


    void OutputTime(int indexj){


        LineRenderer lineRenderer = gameObj.GetComponent<LineRenderer>();

        gameObj.transform.SetParent(Parent, false);
        if (lineRenderer != null)
        {
            lineRenderer.startWidth = 1f;
            lineRenderer.endWidth = 1f;
            lineRenderer.positionCount = 10;
            int count = lineRenderer.positionCount;
            
            for (int j = indexj; j < indexj + count; j++)
            {
                for (int i = 0; i < count; i++)
                {
                    lineRenderer.SetPosition(i, new Vector3(20 * i, positionsY[j + i], 0));
                }
            }

        }
    }
        //transform.position += transform.right * speed * Time.deltaTime;
 }


