using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Architecture.UI
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        #region Variabels
        [SerializeField] private string m_sceneName = "Game";
        private Button m_button;
        #endregion
        

        private void Awake() {
            m_button = GetComponent<Button>();
            m_button.onClick.AddListener(() => SceneManager.LoadScene(m_sceneName));
        }

    }
}