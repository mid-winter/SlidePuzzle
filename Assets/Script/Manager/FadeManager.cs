using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{

    static GameObject _instance = null;

    private float _alpha = 0.0f;
    private Image _fadeObject = null;

    [SerializeField, Range(0.001f, 0.01f), Tooltip("フェイドスピード")]
    private float _speed = 0.01f;

    private static bool _fadeFlug = false;
    public bool isFadeFlug
    {
        get { return _fadeFlug; }
        private set { _fadeFlug = value; }
    }

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
    
    //UIのボタンはこっち呼ばれる
    public void ButtonSceneChange(int scene)
    {
        SceneChange((GameScene)scene);
    }

    public void SceneChange(GameScene scene)
    {
        if (_fadeFlug) return;
        _fadeFlug = true;
        StartCoroutine(Fade(scene));
    }

    public IEnumerator Fade(GameScene scene)
    {
        GetComponent<Canvas>().sortingOrder = 10;
        yield return null;
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
        GetComponent<Canvas>().sortingOrder = -1;
        yield return null;
    }

    private void FadeIn()
    {
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        _alpha += _speed;
    }

    private void FadeOut()
    {
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        _alpha -= _speed;
    }

    private void FadeAdjustment(float alpha)
    {
        _alpha = alpha;
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
    }
}
