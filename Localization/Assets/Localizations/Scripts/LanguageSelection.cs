/// <summary>
/// Turns the popup list it's attached to into a language selection list.
/// </summary>
using UnityEngine;

public class LanguageSelection : MonoBehaviour
{
    public GameObject pfItem;
    public RectTransform content;
    void Start()
    {
        GameObject _objItem;
        LanguageItem _item;
        int lenght = Localization.knownLanguages.Length;
        for (int i = 0; i < lenght; i++)
        {
            _objItem = GameObject.Instantiate(pfItem) as GameObject;
            _objItem.transform.SetParent(content);
            _objItem.transform.localPosition = Vector3.zero;
            _objItem.SetActive(true);

            _item = _objItem.GetComponent<LanguageItem>();
            _item.Init(Localization.knownLanguages[i], OnChange);
            if (Localization.language == Localization.knownLanguages[i])
            {
                _item.OnChoose();
            }
        }
        content.sizeDelta = new Vector2(content.sizeDelta.x, lenght * pfItem.GetComponent<RectTransform>().sizeDelta.y);
    }
    public void onShow()
    {
        gameObject.SetActive(true);
    }
    public void onHide()
    {
        gameObject.SetActive(false);
    }
    public void OnChange(string _value)
    {
        Localization.language = LanguageItem.current.id;
        onHide();
    }
}
