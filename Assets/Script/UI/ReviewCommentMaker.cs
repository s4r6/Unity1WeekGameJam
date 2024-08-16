using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

//このコードはデバッグ用のコードである。
public class ReviewCommentMaker : MonoBehaviour
{
    [SerializeField] private ReviewCommentViewer reviewCommentViewer;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            reviewCommentViewer.ShowComment(1.4f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            reviewCommentViewer.ShowComment(2.5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            reviewCommentViewer.ShowComment(3.12f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            reviewCommentViewer.ShowComment(4.44f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            reviewCommentViewer.ShowComment(5);
        }
    }
    
}
