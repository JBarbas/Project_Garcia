using UnityEngine;
using UnityEngine.UI;

public class changeLanguage : MonoBehaviour
{
    public string TextId;
    public static int idioma = 0;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cambiarLenguageEs()
    {
        I18n.SetLanguage("ES");
        idioma = 1;
    }

    public void cambiarLenguageEn()
    {
        I18n.SetLanguage("EN");
        idioma = 2;
    }
}