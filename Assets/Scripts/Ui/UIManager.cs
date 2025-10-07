using Platformer.Common;
using Ui;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUiManager
{
    public bool fadeToBlack, fadeFromBlack;
    public Image blackScreen;
    public float fadeSpeed = 2f;

    private IFadeHandler _fadeHandler;

    private void Awake()
    {
        ServiceLocator.Instance.Set<IUiManager>(this);
        _fadeHandler = new FadeHandler(fadeToBlack, fadeFromBlack, blackScreen, fadeSpeed);
    }

    private void Update()
    {
        _fadeHandler.Update();
    }

    public void SetFadeToBlack(bool state)
    {
        _fadeHandler.SetFadeToBlack(state);
    }

    public void SetFadeFromBlack(bool state)
    {
        _fadeHandler.SetFadeFromBlack(state);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Remove<IUiManager>();
    }
    
}
