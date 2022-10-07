using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Level;
using TMPro;
using UnityEngine.UI;
using System;

namespace Core.UI
{
    public class GameStatusUI : MonoBehaviour
    {
        [SerializeField] private TilesContainer _tilesContainer;
        [SerializeField] private GameObject _uiWindow;

        [SerializeField] private TMP_Text _header;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _tilesContainer.OnGameOvered += OnGameOver;
        }

        private void OnDisable()
        {
            _tilesContainer.OnGameOvered -= OnGameOver;
        }

        private void OnGameOver()
        {
            _uiWindow.SetActive(true);
            _header.text = "Defeat";
            _button.GetComponentInChildren<TMP_Text>().text = "Retry";
            _button.onClick.AddListener(delegate { Retry(); } );
        }

        private void Retry()
        {
            LevelLoader.Instance.ReloadLevel();
        }

        public void OnGameComplited()
        {
            _uiWindow.SetActive(true);
            _header.text = "Victory";
            _button.GetComponentInChildren<TMP_Text>().text = "Continue";
            _button.onClick.AddListener(delegate { GoNextLevel(); });
        }

        private void GoNextLevel()
        {
            LevelLoader.Instance.NextLevel();
        }

        private void Start()
        {
            _uiWindow.SetActive(false);
        }
    }
}