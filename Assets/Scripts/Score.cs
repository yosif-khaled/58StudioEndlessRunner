using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0f;

    [SerializeField] private Text scoreText;
    void Start()
    {
        scoreText.text = "Time Survived";
    }

    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();

    }
}
