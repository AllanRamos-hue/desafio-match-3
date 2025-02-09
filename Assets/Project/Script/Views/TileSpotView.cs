using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gazeus.DesafioMatch3.Views
{
    public class TileSpotView : MonoBehaviour
    {
        public event Action<int, int> Clicked;
        public event Action<int, int> Destroyed;

        [SerializeField] private Button _button;
        [SerializeField] private ParticleSystem _explosionParticle;

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

        private void OnTileDestroyed()
        {
            Destroyed?.Invoke(_x, _y);  
        }

        public void PlayParticle()
        {
            Image image = GetComponentInChildren<Image>();
            
            var main = _explosionParticle.main;
            main.startColor = image.color;

            _explosionParticle.Play();
        }
    }
}
