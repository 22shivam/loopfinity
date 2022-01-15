using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    // Start is called before the first frame update
    public circularMotion cm;
    public Button btn;
    public CanvasGroup canvasGroup;
    
    void Start()
    {
        hideButton();
        btn.onClick.AddListener(() => {
            cm.startCircle();
            hideButton();
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideButton()
    {
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }
    
    public void showButton()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    
}
