using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Gazeus.DesafioMatch3
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        private int _points;

        public void AddPoints()
        {
            _points++;

            _scoreText.text = "Score: " + _points.ToString();
        }
    }
}
