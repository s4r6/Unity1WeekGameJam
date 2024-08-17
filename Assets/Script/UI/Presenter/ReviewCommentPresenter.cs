using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class ReviewCommentPresenter : MonoBehaviour
{
    [SerializeField] private GameMaster gameMaster;
    [SerializeField] private ReviewCommentViewer reviewCommentViewer;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster.OnComment.Subscribe(x => reviewCommentViewer.ShowComment(x));
    }
}
