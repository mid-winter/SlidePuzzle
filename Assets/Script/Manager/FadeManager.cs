using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Fadeのα値の変動のみを扱うstaticなクラス
/// </summary>
public static class Fade
{
    private static Image _fadeObject = null;
    public static Image fadeObject
    {
        set { _fadeObject = value; }
    }
    public static Color fadeColor
    {
        set { _fadeObject.color = value; }
    }
    private static float _alpha = 0.0f;
    public static float alpha
    {
        get { return _alpha; }
        set { _alpha = value; }
    }  

    public static void FadeOut(float speed)
    {
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        _alpha += speed;
    }

    public static void FadeIn(float speed)
    {
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
        _alpha -= speed;
    }

    public static void FadeAdjustment(float alpha)
    {
        _alpha = alpha;
        _fadeObject.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
    }

}

/// <summary>
/// Fadeclassを使ってFadeの管理をするクラス
/// </summary>
public class FadeManager : MonoBehaviour
{

    static GameObject _instance = null;

    [SerializeField, Range(0.001f, 0.01f), Tooltip("フェイドスピード")]
    private float _speed = 0.005f;

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
            Fade.fadeObject = GetComponentInChildren<Image>();
            Fade.fadeColor = new Color(0.0f, 0.0f, 0.0f, Fade.alpha);

            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// Fadeを使ってシーン遷移したいときは
    /// このメソッドを呼び出す
    /// ボタンで押す部分は自分たちのスクリプトで作ってね☆
    /// </summary>
    /// <param name="scene"></param>
    public void StartFade(GameScene scene)
    {
        if (_fadeFlug) return;
        _fadeFlug = true;
        StartCoroutine(FadeOut(scene));
    }

    /// <summary>
    /// 引数のないFadeoutは単体で使用可能
    /// この時は画面が暗くなっていくだけ
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeOut()
    {
        FindObjectOfType<Canvas>().sortingOrder = 10;
        yield return null;
        while (Fade.alpha < 1.0f)
        {
            Fade.FadeOut(_speed);
            yield return null;
        }

        Fade.FadeAdjustment(1.0f);
    }

    /// <summary>
    /// Fadeinするときに使う
    /// 画面が明るくなっていく
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeIn()
    {
        while (Fade.alpha > 0.0f)
        {
            Fade.FadeIn(_speed);
            yield return null;
        }
        Fade.FadeAdjustment(0.0f);
        _fadeFlug = false;
        FindObjectOfType<Canvas>().sortingOrder = -1;
        yield return null;


    }

    /// <summary>
    /// シーン遷移するFade。
    /// こちらは勝手にFadeinまでよんでくれる
    /// </summary>
    /// <param name="scene"></param>
    /// <returns></returns>
    public IEnumerator FadeOut(GameScene scene)
    {
        FindObjectOfType<Canvas>().sortingOrder = 10;
        yield return null;
        while (Fade.alpha < 1.0f)
        {
            Fade.FadeOut(_speed);
            yield return null;
        }

        Fade.FadeAdjustment(1.0f);

        SceneChange(scene);
        yield return StartCoroutine(FadeIn());

    }

    /// <summary>
    /// シーン遷移用関数
    /// </summary>
    /// <param name="scene"></param>
    private static void SceneChange(GameScene scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}
