using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LineConnection : MonoBehaviour
{
    
    public Transform Parent;
    public Transform staticParent;
    public GameObject gameObj; //Graph
    public GameObject gameObj2; //Graph2
    public GameObject gameObj3; //Graph3
    public GameObject background; 

    public bool swt; //switch
    public bool swt2;
    public bool swt3;
    public bool verticalTime;
    public bool verticalTime2;
    public bool verticalTime3;


    List<float> positionsX = new List<float>() { };
    List<float> positionsZ = new List<float>() { };
    List<float> positions3 = new List<float>() { };

    float yMax;
    float zMax;
    float Max3;
    float xScale = 40; //the range of the data(normalization)
    float Scale3 = 20;
    //float elapsed = 0f;
    //public GameObject objPrefab;
    //LineRenderer lineRenderer;

    public float speed = 10;
    public Transform[] target;
    public float delta = 0.2f;
    private int p = 0;


    public void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            positionsX.Add(Random.Range(0f, 100f));
            yMax = positionsX.Max();

            positionsZ.Add(Random.Range(0f, 100f));
            zMax = positionsZ.Max();

            positions3.Add(Random.Range(0f, 100f));
            Max3 = positions3.Max();
        }
    }


    float elapsed = 0f;
    int n = 9950;
    //int n2 = 0;
    void Update()
    {
        if(swt == true){
            elapsed += 4f * Time.deltaTime;

            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                n -= 1; //data go up
                OutputTimeX(n);
            }
            MoveTo();
        }
        else{
            gameObj.SetActive(false); //hide the Graph
        }


        if (swt2 == true)
        {
            elapsed += 4f * Time.deltaTime;

            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                n -= 1;
                OutputTimeZ(n);
            }
            MoveTo();
        }
        else
        {
            gameObj3.SetActive(false); //hide the Graph2
        }

        if (swt3 == true)
        {
            elapsed += 5f * Time.deltaTime;

            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                n -= 1;
                OutputTime3(n);
            }
        }
        else
        {
            gameObj3.SetActive(false); //hide the Graph3
            background.SetActive(false); //hide the Graph3
        }

    }



    void OutputTimeX(int indexj){
        
        LineRenderer lineRenderer = gameObj.GetComponent<LineRenderer>();

        gameObj.transform.SetParent(Parent, false);
        if (lineRenderer != null)
        {
            lineRenderer.startWidth = 1f;
            lineRenderer.endWidth = 1f;
            lineRenderer.positionCount = 20;
            int count = lineRenderer.positionCount;
            
            for (int j = indexj; j < indexj + count; j++)
            {
                for (int i = 0; i < count; i++)
                {
                    float xPosition = positionsX[j + i] / yMax * xScale;
                    if(verticalTime == true) //vertical or horizontal
                    {
                        lineRenderer.SetPosition(i, new Vector3(xPosition, 10 * i, 0));

                    }
                    else{
                        lineRenderer.SetPosition(i, new Vector3(10 * i, xPosition, 0));
                    }
                }
            }

        }
    } 


    void OutputTimeZ(int indexj)
    {

        LineRenderer lineRenderer = gameObj2.GetComponent<LineRenderer>();

        gameObj2.transform.SetParent(Parent, false);
        if (lineRenderer != null)
        {
            lineRenderer.startWidth = 1f;
            lineRenderer.endWidth = 1f;
            lineRenderer.positionCount = 20;
            int count = lineRenderer.positionCount;

            for (int j = indexj; j < indexj + count; j++)
            {
                for (int i = 0; i < count; i++)
                {
                    float zPosition = positionsZ[j + i] / zMax * xScale;
                    if (verticalTime2 == true)
                    {
                        lineRenderer.SetPosition(i, new Vector3(0, 10 * i, zPosition));
                    }
                    else{
                        lineRenderer.SetPosition(i, new Vector3(0, zPosition, 10 * i));
                    }
                }
            }

        }
    }


    void OutputTime3(int indexj)
    {
        
        LineRenderer lineRenderer = gameObj3.GetComponent<LineRenderer>();
        gameObj3.transform.SetParent(staticParent, false);

        if (lineRenderer != null)
        {
            lineRenderer.startWidth = 1f;
            lineRenderer.endWidth = 1f;
            lineRenderer.positionCount = 20;
            int count = lineRenderer.positionCount;

            for (int j = indexj; j < indexj + count; j++)
            {
                for (int i = 0; i < count; i++)
                {
                    float Position3 = positions3[j + i] / Max3 * Scale3;
                    if (verticalTime3 == true)
                    {
                        lineRenderer.SetPosition(i, new Vector3(5 * i, Position3, 0));
                    }
                    else
                    {
                        lineRenderer.SetPosition(i, new Vector3(5 * i, 0, Position3));
                    }
                }
            }

        }
    }


    //transform.position += transform.right * speed * Time.deltaTime;


    void MoveTo(){

        target[p].position = new Vector3(target[p].position.x, transform.position.y, target[p].position.z);

        //transform.LookAt(target[p]);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

        float step = Time.deltaTime * speed;
        transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, target[p].position, step);

        if(transform.position.x > target[p].position.x - delta &&
           transform.position.x < target[p].position.x + delta &&
           transform.position.z > target[p].position.z - delta &&
           transform.position.z < target[p].position.z + delta)
        {
            p = (p + 1)% target.Length;
            //Debug.Log(p);
        }

    } 

 }


