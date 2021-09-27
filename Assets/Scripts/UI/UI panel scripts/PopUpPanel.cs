using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpPanel : MonoBehaviour
{
    /*Params*/
    [SerializeField] TMP_Text mainText;
    [Space]
    [SerializeField] Button okButton;
    [SerializeField] TMP_Text okText;
    [Space]
    [SerializeField] Button yesButton;
    [SerializeField] TMP_Text yesText;
    [Space]
    [SerializeField] Button noButton;
    [SerializeField] TMP_Text noText;

    private RectTransform _panelRectTransform;
    private Vector3 _startLocalScale;
    private int textID = -1;
    private string textContent = null;

    /*Private methods*/
    private void Awake()
    {
        _panelRectTransform = GetComponent<RectTransform>();
    }

    private void AnimationPopUpLoad()
    {
        _startLocalScale = _panelRectTransform.localScale;
        _panelRectTransform.localScale = new Vector3(_panelRectTransform.localScale.x, 0, _panelRectTransform.localScale.z);
        LeanTween.scaleY(gameObject, _startLocalScale.y, 0.5f).setEaseOutBack();
    }

    private void DestroyPopUp()
    {
        LeanTween.scaleY(gameObject, 0, 0.5f).setEaseInBack().setOnComplete(DestroyMe);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }


    /*Public methods*/
    public void BuildOkPopUp(string text, System.Action method, int id)
    {
        _panelRectTransform.localPosition = Vector3.zero;
        AnimationPopUpLoad();

        okButton.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        okText.text = Managers.Language.CurrentLanguage.OkPopUpOK;

        //Already set up pop up
        if (id > -1)
            mainText.text = Managers.Language.CurrentLanguage.OkPopUp[id];
        //Custom pop up
        else
            mainText.text = text;

        okButton.onClick.AddListener(delegate { method(); DestroyPopUp(); });
    }

    public void BuildYesNoPopUp(string text, System.Action methodYes, System.Action methodNo, int id)
    {
        _panelRectTransform.localPosition = Vector3.zero;
        AnimationPopUpLoad();

        okButton.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
        yesText.text = Managers.Language.CurrentLanguage.YesNoPopUpYes;
        noText.text = Managers.Language.CurrentLanguage.YesNoPopUpNo;

        //Already set up pop up
        if (id > -1)
            mainText.text = Managers.Language.CurrentLanguage.YesNoPopUp[id];
        //Custom pop up
        else
            mainText.text = text;

        yesButton.onClick.AddListener(delegate { methodYes(); DestroyPopUp(); });
        noButton.onClick.AddListener(delegate { methodNo(); DestroyPopUp(); });
    }

}
