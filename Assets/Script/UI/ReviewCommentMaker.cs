using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

//���̃R�[�h�̓f�o�b�O�p�̃R�[�h�ł���B
public class ReviewCommentMaker : MonoBehaviour
{
    [SerializeField] private ReviewCommentViewer reviewCommentViewer;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            reviewCommentViewer.ShowComment(PancakeComment.COMMON);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            reviewCommentViewer.ShowComment(PancakeComment.PERFECT);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            reviewCommentViewer.ShowComment(PancakeComment.BURNT);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            reviewCommentViewer.ShowComment(PancakeComment.DROPED);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            reviewCommentViewer.ShowComment(PancakeComment.TIMEDOUT);
        }
    }
    
}
