using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    [SerializeField] private VideoPlayer m_audioSource;
    
    void Start()
    {
        
    }

    private void Update()
    {
        // まだ Audio が再生されておらず
        // かつ何らかのキーかマウスボタンが押された場合
        if (!m_audioSource.isPlaying && Input.anyKeyDown)
        {
            // Audio を再生する
            m_audioSource.Play();
        }
    }
}