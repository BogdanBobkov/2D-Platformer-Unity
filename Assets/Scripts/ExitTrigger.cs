using System.Collections;
using Platformer.Common;
using Platformer.GameManager;
using Platformer.Ui;
using UnityEngine;

namespace Platformer
{
    public class ExitTrigger : MonoBehaviour
    {
        private IUiManager _uiManager;
        private IGameManager _gameManager;

        private void Start()
        {
            _uiManager = ServiceLocator.Instance.Get<IUiManager>();
            _gameManager = ServiceLocator.Instance.Get<IGameManager>();
        }

        //public Animator anim;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine("LevelExit");
            }
        }

        IEnumerator LevelExit()
        {
            //anim.SetTrigger("Exit");
            yield return new WaitForSeconds(0.1f);

            _uiManager.SetFadeToBlack(true);

            yield return new WaitForSeconds(2f);
            // Do something after flag anim
            _gameManager.LevelComplete();
        }
    }
}