using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinalCutscene2 : MonoBehaviour
{

    TextPrompterSilence textPrompterSilence;
    private bool Finishing;
    // Start is called before the first frame update
    void Start()
    {
        textPrompterSilence = GetComponent<TextPrompterSilence>();
    }

    // Update is called once per frame
    void Update()
    {
        Finishing = textPrompterSilence.isFinished;
        if (Finishing )
        {
            SceneManager.LoadScene("Ending2");
        }
    }
}
