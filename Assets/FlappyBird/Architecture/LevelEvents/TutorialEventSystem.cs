using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Architecture.Player;
using Architecture.Environment;

namespace Architecture.LevelEvents
{
    public sealed class TutorialEventSystem : MonoBehaviour
    {
        #region Variabels
        [SerializeField] private Button m_interaction;
        [Inject] private PlayerController m_playerController;
        [Inject] private PipeSpawner m_pipeSpawner;
        #endregion


        private void Start()
        {
            m_playerController.FreezMovement();
            m_pipeSpawner.Pause();

            m_interaction.onClick.AddListener(EndTutorial);
        }

        private void EndTutorial()
        {
            m_interaction.gameObject.SetActive(false);

            m_pipeSpawner.UnPause();
            m_playerController.UnFreezMovement();
            m_playerController.DoJump();
        }


    }
}