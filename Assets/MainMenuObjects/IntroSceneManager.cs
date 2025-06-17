using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public void BeginGame()
    {
        SceneManager.LoadScene("PrimarySchoolLifeStage_1");
    }
}
