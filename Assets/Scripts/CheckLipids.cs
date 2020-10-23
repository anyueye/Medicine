using UnityEngine;
using UnityEngine.UI;


public class CheckLipids: MonoBehaviour
{
    public Text message;
    public InputField check;
    public GameObject[] Images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCheck()
    {
        check.text = string.Empty;
        foreach (var o in Images)
        {
            o.SetActive(false);
        }

        SceneAction.canPress = true;
    }
    public void ImageForCheck(InputField field)
    {
        if (string.IsNullOrEmpty(field.text))
        {
            if (message!=null)
            {
                message.text = $"请输入数值！";
            }
            return;
        }

        foreach (var image in Images)
        {
            image.SetActive(false);
        }
        if (float.Parse(field.text) <2.6f)
        {
            Images[0].SetActive(true);
        }
        else if (float.Parse(field.text)<3.4f)
        {
            Images[1].SetActive(true);
        }
        else if (float.Parse(field.text)<4.1f)
        {
            Images[2].SetActive(true);
        }
        else
        {
            Images[3].SetActive(true);
        }
        
    }
}
