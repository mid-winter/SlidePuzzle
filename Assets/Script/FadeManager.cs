using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{

    static GameObject _instance = null;

    private float _alpha = 0.0f;
    private Image _fadeObject = null;

    private static bool _fadeFlug = false;
    //public bool isFadeFlug
    //{
    //    get { return _fadeFlug; }
    //    set { _fadeFlug = value; }
    //}

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        _fadeObject = GetComponentInChildren<Image>();
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);

    }

    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        FadeStart(GameScene.GAME);
    //    }
    //}

    public void SceneChange(GameScene scene)
    {
        if (_fadeFlug) return;
        _fadeFlug = true;
        StartCoroutine(Fade(scene));
    }

    public IEnumerator Fade(GameScene scene)
    {
        while (_alpha < 1.0f)
        {
            FadeIn();
            yield return null;
        }

        FadeAdjustment(1.0f);
        SceneManager.LoadScene((int)scene);

        while (_alpha > 0.0f)
        {
            FadeOut();
            yield return null;
        }

        FadeAdjustment(0.0f);
        _fadeFlug = false;
        yield return null;
    }

    private void FadeIn()
    {
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        _alpha += 0.01f;
    }

    private void FadeOut()
    {
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        _alpha -= 0.01f;
    }

    private void FadeAdjustment(float alpha)
    {
        _alpha = alpha;
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
    }
}
