using UnityEngine;
using UnityEngine.UI;

public class CheckPressure: MonoBehaviour
{
    public Text message;
    public InputField dummy, check;
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
        dummy.text = string.Empty;
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
        if (int.Parse(field.text) <60)
        {
            Images[0].SetActive(true);
        }
        else if (int.Parse(field.text)<80)
        {
            Images[1].SetActive(true);
        }
        else if (int.Parse(field.text)<89)
        {
            Images[2].SetActive(true);
        }
        else if (int.Parse(field.text)<99)
        {
            Images[3].SetActive(true);
        }
        else if (int.Parse(field.text)<109)
        {
            Images[4].SetActive(true);
        }
        else
        {
            Images[5].SetActive(true);
        }
        
    }
}
