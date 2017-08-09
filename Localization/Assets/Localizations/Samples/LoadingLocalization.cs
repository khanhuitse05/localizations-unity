using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingLocalization : MonoBehaviour {

    public Dropdown dropLanguage;
    public GameObject guiMain;
    public GameObject setting;
    // Use this for initialization
    void Start() {
        // Language
        LocalizationData.LoadLocalization();
        dropLanguage.onValueChanged.AddListener(delegate { OnLanguageDropdown(); });

        string[] _knownLanguages = Localization.knownLanguages;
        List<string> _Languages = ConverArray<string>(_knownLanguages);
        dropLanguage.ClearOptions();
        dropLanguage.AddOptions(_Languages);
        SetTextDropDown(dropLanguage, Localization.language, false);

        isShow = false;
        OnShowSetting();
    }

    bool isShow = false;
    public void OnShowSetting()
    {
        isShow = !isShow;
        guiMain.SetActive(isShow);
        setting.SetActive(!isShow);
    }
    public void OnLanguageDropdown()
    {
        Localization.language = dropLanguage.captionText.text;
    }
    List<T> ConverArray<T>(T[] paramArray)
    {
        if (paramArray == null)
            return null;
        List<T> list = new List<T>();
        for (int i = 0; i < paramArray.Length; i++)
        {
            list.Add(paramArray[i]);
        }
        return list;
    }
    bool SetTextDropDown(Dropdown drop, string value, bool addnew = true)
    {
        for (int i = 0; i < drop.options.Count; i++)
        {
            if (drop.options[i].text == value)
            {
                drop.value = i;
                return true;
            }
        }
        if (addnew)
        {
            drop.options.Add(new Dropdown.OptionData { text = value });
            drop.value = drop.options.Count - 1;
        }
        return false;
    }
}
