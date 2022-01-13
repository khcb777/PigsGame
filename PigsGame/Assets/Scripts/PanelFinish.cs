using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelFinish : MonoBehaviour
{
    [SerializeField] private AudioClip _finishClip;
    [SerializeField] private AudioSource _musicPlayerBG;
    [SerializeField] private Text pfrasestext;
    [SerializeField] private string[] prases;

    private void Start()
    {
        
        GameInfo.init._Finish.FinishAction += Finish;
        gameObject.SetActive(false);
    }

    private void Finish()
    {
        gameObject.SetActive(true);
        int r = Random.Range(0, prases.Length);
        pfrasestext.text = prases[r];
        _musicPlayerBG.enabled = false;
        GameInfo.init._Finish.FinishAction -= Finish;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    }
}
