using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Graph : MonoBehaviour
{

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    public List<int> values;
    public GameObject linePrefab;


    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

        ShowGraph(values);
    }

    private GameObject CreatCircle(Vector2 anchoredPosition)
    {
        GameObject gameObj = new GameObject("circle", typeof(Image));
        gameObj.transform.SetParent(graphContainer, false);
        gameObj.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(3, 3);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObj; 
    }

    private void ShowGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = valueList.Max(); 
        float xGap = 20f;
        List<Vector2> positions = new List<Vector2>() { };

        GameObject lastCircleObj = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xGap + i * xGap;
            float yPosition = ((valueList[i] / yMaximum) * graphHeight) * 0.9f;
            GameObject circleObj = CreatCircle(new Vector2(xPosition, yPosition));

            Vector2 position = new Vector2(xPosition, yPosition);
            positions.Add(new Vector2(xPosition, yPosition));

            if( lastCircleObj != null ){
                CreatDotConnection(lastCircleObj.GetComponent<RectTransform>().anchoredPosition, positions[i]);
            }
          
            lastCircleObj = circleObj;
        
        
        }


    }

    private void CreatDotConnection(Vector2 position1, Vector2 position2){

        GameObject lineObj = Instantiate(linePrefab) as GameObject;
        lineObj.transform.SetParent(graphContainer,false);


        RectTransform rectTransform = lineObj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(3, 3);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
       
        LineRenderer lineRenderer = lineObj.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, position1);
        lineRenderer.SetPosition(1, position2);
    }
}
