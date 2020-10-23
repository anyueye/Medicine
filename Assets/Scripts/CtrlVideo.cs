using UnityEngine;
using UnityEngine.Video;

public class CtrlVideo : MonoBehaviour
{
    public VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        // Observable.Select(_ => Input.GetMouseButtonDown(0));
    }

    public void OnShow()
    {
        vp.frame = 0;
        vp.Play();
        vp.SetDirectAudioMute(0,false);
    }

    public void OnHide()
    {
        vp.SetDirectAudioMute(0,true);
    }
}
