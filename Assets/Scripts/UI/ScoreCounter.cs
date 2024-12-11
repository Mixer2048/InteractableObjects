using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;
    private TMP_Text _scoreText;

    private void Start()
    {
        _score = 0;
        _scoreText = GetComponent<TMP_Text>();
    }

    public void ScoreUp()
    {
        _score++;
        _scoreText.text = "Score: " + _score;
    }
}