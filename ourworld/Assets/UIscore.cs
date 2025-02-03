using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIscore : MonoBehaviour
{
    private int score = 0;
    
    public void addScore()
    {
        score++;
    }

    private TextMeshProUGUI _TextMeshPro;
    void Start()
    {
        _TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _TextMeshPro.text = "aantal: " + score.ToString();
    }
}
