using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;

public class ReviewCommentViewer : MonoBehaviour
{
    private TextAsset csvFile;
    
    private List<string[]> csvData = new List<string[]>();

    //canvasGroupはpanelがもってあるのでパネルをアタッチしてください
    [SerializeField] private CanvasGroup commentCanvasGroup;
    //[SerializeField] private TextMeshProUGUI starText;
    [SerializeField] private TextMeshProUGUI commentText;

    private RectTransform canvasRectTransform;
    private void Start()
    {
        csvFile = Resources.Load("PancakeComment") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvData.Add(line.Split(','));
        }

        commentCanvasGroup.DOFade(0.0f, 0.0f);
        canvasRectTransform = commentCanvasGroup.gameObject.GetComponent<RectTransform>();
        canvasRectTransform.DOAnchorPos(new Vector2(0.0f,-10.0f), 1.0f);
    }
    
    //コメントに対応したテキストを書き込む
    public void ShowComment(PancakeComment pancakeComment)
    {
        //StringReviewStar(星の数)に対応したコメントを全て検索する。
        var reviewCommnets = csvData.FindAll(x => x[0] == pancakeComment.ToString());
        
        int randomNum = Random.Range(0, reviewCommnets.Count);
        commentText.text = reviewCommnets[randomNum][1];
        CommentMove();
    }
    
   //ポップアウトにコメントを動かす関数
   void CommentMove()
   {
       Sequence sequence = DOTween.Sequence();
       sequence
           .Append(commentCanvasGroup.DOFade(1.0f, 1.0f))
           .Join(canvasRectTransform.DOAnchorPos(new Vector2(0.0f, 0.0f), 1.0f))
           .AppendInterval(1.0f)
           .Append(commentCanvasGroup.DOFade(0.0f, 1.0f))
           .Join(canvasRectTransform.DOAnchorPos(new Vector2(0.0f, -10.0f), 1.0f));
   }
}
