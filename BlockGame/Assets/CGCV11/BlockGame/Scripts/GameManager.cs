using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CGCV11.BlockGame.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        private int _brickCount, _lifeCount, _score;
        private bool _isGameOver;
        public GameObject objectBall;

        [SerializeField] private Transform bricks;
        [SerializeField] private Toggle[] lives;
        [SerializeField] private RectTransform loseScreen, winScreen, startScreen;
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private float time;

        public void CollideBrick(Collision other)
        {
            if (_isGameOver) return;
            _brickCount--;
            other.gameObject.SetActive(false);
            score.text = $"Score: {++_score}";
            if (_brickCount > 0) return;
            _isGameOver = true;
            winScreen.gameObject.SetActive(true);
            Invoke(nameof(Restart), time);
            _isGameOver = true;
        }

        public void CollideWater(Collision other)
        {
            objectBall.transform.position = new Vector3(0,(float)2.5,0);
            lives[_lifeCount-1].gameObject.SetActive(false);
            _lifeCount--;
            if (_lifeCount == 0)
            {
                _isGameOver = true;
                loseScreen.gameObject.SetActive(true);
                Invoke(nameof(Restart), time);
                _isGameOver = true;
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Reset()
        {
            bricks = null;
            lives = null;
            loseScreen = null;
            score = null;
            winScreen = null;
            time = 5;
        }

        private void Start()
        {
            startScreen.gameObject.SetActive(true);
            loseScreen.gameObject.SetActive(false);
            winScreen.gameObject.SetActive(false);
            _brickCount = 32;
            _lifeCount = 6;
            _isGameOver = false;
            Time.timeScale = 0;

        }

        private void Update()
        {
            if (_isGameOver) return;
            if (Input.GetKey(KeyCode.R))
            {
                Restart();
            }
            if (Input.GetKey("escape"))
            {
                Time.timeScale = 0;
            }
            if (Input.GetKey("return"))
            {
                startScreen.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

    }
}


