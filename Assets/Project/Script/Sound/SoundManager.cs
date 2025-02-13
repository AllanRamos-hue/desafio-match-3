using Gazeus.DesafioMatch3.Core;
using Gazeus.DesafioMatch3.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gazeus.DesafioMatch3
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[]_normalComboAudios;
        [SerializeField] private AudioClip _hugeComboAudio;

        [SerializeField] private BoardView _boardView;

        void Awake ()
        {
            _boardView.OnDestroyTiles += OnDestroyTiles;
            _boardView.OnHugeCombo += OnHugeCombo;
        }

        private void OnDestroy()
        {
            _boardView.OnDestroyTiles -= OnDestroyTiles;
            _boardView.OnHugeCombo -= OnHugeCombo;
        }

        private void OnHugeCombo()
        {
            PlaySound(_hugeComboAudio, transform.position);
        }

        private void OnDestroyTiles()
        {
            PlaySound(_normalComboAudios[Random.Range(0, _normalComboAudios.Length)], transform.position);
        }

        private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
        {
            AudioSource.PlayClipAtPoint(audioClip, position, volume);
        }
    }
}
