using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

/// <summary>
/// データを外部ファイルに保存するクラス
/// 読み込み、書き込みができるようにする
/// </summary>
public class DataStream : MonoBehaviour
{

    private string _path = null;

    void Awake()
    {
        ReadFile();
        Debug.Log(_path);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 5, Screen.width, 50), _path);
    }

    public void WriteFile(string text)
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/Data/Data.txt");
        if (fi == null) return;
        using (StreamWriter sw = fi.AppendText())
            sw.WriteLine(text);
        Debug.Log(text);
    }

    private void ReadFile()
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/Data/Data.txt");
        if (fi == null) return;
        StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        _path = sr.ReadToEnd();
    }
}
