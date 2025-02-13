﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gazeus.DesafioMatch3.Views
{
    public class TileSpotView : MonoBehaviour
    {
        public event Action<int, int> Clicked;

        [SerializeField] private Button _button;
        
        [SerializeField] private ParticleSystem _explosionParticle;

        [SerializeField] private Material _selectedMaterial;

        private int _x;
        private int _y;

        #region Unity
        private void Awake()
        {
            _button.onClick.AddListener(OnTileClick);
        }
        #endregion

        public Tween AnimatedSetTile(GameObject tile)
        {
            tile.transform.SetParent(transform);
            tile.transform.DOKill();

            return tile.transform.DOMove(transform.position, 0.3f);
        }

        public void SetPosition(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void SetTile(GameObject tile)
        {
            tile.transform.SetParent(transform, false);
            tile.transform.position = transform.position;
        }

        private void OnTileClick()
        {
            Clicked?.Invoke(_x, _y);
        }

        public void SetSelectedMaterialToImage(bool value = false)
        {
            Image image = GetComponentInChildren<Image>();

            if(value)
            {
                image.material = _selectedMaterial;
            }
            else
            {
                image.material = null;
            }
            
        }

        public void SetChildParticleColor()
        {
            Image image = GetComponentInChildren<Image>();

            var main = _explosionParticle.main;
            main.startColor = image.color;
        }

        public void PlayParticle()
        {
            _explosionParticle.Play();
        }
    }
}
