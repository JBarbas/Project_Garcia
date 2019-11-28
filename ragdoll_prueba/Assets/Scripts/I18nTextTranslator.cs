using UnityEngine;
using UnityEngine.UI;

public class I18nTextTranslator : MonoBehaviour
{
    public string TextId;

    // Use this for initialization
    void Start()
    {
        var text = GetComponent<Text>();
        if (text != null)
            if (TextId == "ISOCode")
                text.text = I18n.GetLanguage();
            else
                text.text = I18n.Fields[TextId];
    }

    // Update is called once per frame
    void Update()
    {
        if(changeLanguage.idioma == 1)
        {
            Start();
        }
        if (changeLanguage.idioma == 2)
        {
            Start();
        }


    }
}