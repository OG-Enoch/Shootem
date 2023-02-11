using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    public List<Color> TintColors;
    Color randomColor;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        Color c = TintColors[Random.Range(0, TintColors.Count)];
        img.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
