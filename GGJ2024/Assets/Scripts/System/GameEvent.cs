using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Utility;
namespace System
{
    public class GameEvent : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private GameObject gameOverObj;

        public bool isGameOver { get; private set; }

        private void Awake()
        {
            Locator.Register(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        public void OnGameOver()
        {
            gameOverObj.SetActive(true);
            Camera.main.transform.localRotation = Quaternion.identity;
            isGameOver = true;

            Cursor.lockState = CursorLockMode.None;

            DOTween.To(() => canvasGroup.alpha, (a) => canvasGroup.alpha = a, 1, 0.3f)
            .SetDelay(5)
            .OnComplete(() =>
            {
                canvasGroup.blocksRaycasts = true;
                canvasGroup.interactable = true;
            });
        }

        public void Restart()
        {
            SceneManager.LoadScene("Player");
        }
    }
}