using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject TutorialPanel;
    public GameObject Credits;
    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.SetActive(false);

        TutorialPanel.SetActive(false);
        Credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SettingsOnMenu()
    {
        SettingsPanel.SetActive(true);

    }
    public void SettingsOFF()
    {
        SettingsPanel.SetActive(false);

    }
    public void TutorialOnMenu()
    {
        TutorialPanel.SetActive(true);

    }
    public void TutorialOFF()
    {
        TutorialPanel.SetActive(false);

    }

    public void CreditsOnMenu()
    {
        Credits.SetActive(true);

    }
    public void CreditsOFF()
    {
        Credits.SetActive(false);

    }

    public void QuitOnMenu()
    {
        Application.Quit();
    }
}
