#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;


[CreateAssetMenu(fileName = "New Question", menuName = "Questions", order = 1)]
public class QuizQuestion : ScriptableObject
{
    [SerializeField]
    private string question;
    [SerializeField]
    private string[] answers;
    [SerializeField]
    private int correctAnswer;

    public string Question
    {
        get => question;
    }

    public string[] Answers
    {
        get
        {
            return answers;
        }
    }

    public int CorrectAnswer
    {
        get => correctAnswer;
    }

    public bool Asked
    {
        get;
        set;
    }

    //public void OnValidate()
    //{
    //    if(correctAnswer > answers.Length)
    //    {
    //        correctAnswer = 0;
    //    }
    //    RenameScriptableObjectToMatchQuestion();
    //}

    void RenameScriptableObjectToMatchQuestion()
    {
        /* Primjer pitanja i zapisa:
         * Što je to var?
         * 
         * 0. Varivo
         * 1. Varijabla
         * 2. VarIvo
         * 3. Viagra
         * 
         * Ispis æe biti (novi naziv): "Što je to var [varijabla]"
         */
        string desiredName = string.Format("{0} [{1}]", question.Replace("?", ""), answers[correctAnswer]);
#if UNITY_EDITOR
        string assetPath = AssetDatabase.GetAssetPath(this.GetInstanceID());
#endif
        string shouldEndWith = "/" + desiredName + ".asset";
#if UNITY_EDITOR
        if(assetPath.EndsWith(shouldEndWith) == false)
        {
            Debug.Log("Want to rename to: " + desiredName);
            AssetDatabase.RenameAsset(assetPath, desiredName);
            AssetDatabase.SaveAssets();
        }
#endif
    }
}
