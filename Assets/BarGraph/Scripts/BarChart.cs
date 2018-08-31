using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BarChart : MonoBehaviour {

    public Bar barPrefab;
    public int[] inputValues;

    List<Bar> bars = new List<Bar>();

    float chartHeight;

	void Start () {
        chartHeight = Screen.height + GetComponent<RectTransform>().sizeDelta.y;
        //float[] values = {0.1f, 0.25f, 0.15f, 0.3f, 0.04f, 0.06f, 0.1f };
        DisplayGraph(inputValues);
	}
	
    void DisplayGraph(int[] vals){     //圆括号里是啥？
        int maxValue = vals.Max();

        for (int i = 0; i < vals.Length; i++){
            Bar newBar = Instantiate(barPrefab) as Bar;
            newBar.transform.SetParent(transform);
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();
            float normalizedValue =((float)vals[i] / (float)maxValue)* 0.93f;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, chartHeight * normalizedValue);
        }
    }



}
 