using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    //�з�����
    public float speed;
    public int dis;

    //��ũ�Ѹ�
    public float OverNum;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;


    void LateUpdate()
    {
        if (dis == 1)
        {
            //�з�����
            //������� <-
            Vector3 curPos = transform.position;
            Vector3 nextPos = Vector3.right * speed * Time.deltaTime;
            transform.position = curPos + nextPos;

            //��ũ�Ѹ�
            if (sprites[endIndex].position.x > OverNum)
            {
                Vector3 backSpritePos = sprites[startIndex].localPosition;
                Vector3 frontSpritePos = sprites[endIndex].localPosition;
                sprites[endIndex].transform.localPosition = backSpritePos + Vector3.left * OverNum;

                // ����(���� ���߿� �̵��ؾ��ϴ� �ε���)�� start -> 0
                // �Ӹ�(���� ���� �̵��ؾ��ϴ� �ε���)�� End -> 2
                int StartIndexSave = startIndex;
                startIndex = endIndex;
                // �ε��� ��ȣ
                // 0 1 2
                // 2 0 1
                // 1 2 0
                // start -> 2 1 0
                // end -> 1 0 2
                endIndex = StartIndexSave+1 == 3 ? sprites.Length - 3 : StartIndexSave + 1;
            }
        }
        else if (dis == 2)
        {
            //�з�����
            // ������� ->
            Vector3 curPos = transform.position;
            Vector3 nextPos = Vector3.left * speed * Time.deltaTime;
            transform.position = curPos + nextPos;

            //��ũ�Ѹ�
            if (sprites[endIndex].position.x < OverNum * (-1))
            {
                Vector3 backSpritePos = sprites[startIndex].localPosition;
                Vector3 frontSpritePos = sprites[endIndex].localPosition;
                sprites[endIndex].transform.localPosition = backSpritePos + Vector3.right * OverNum * 1;

                // ����(���� ���� �̵��ؾ��ϴ� �ε���)�� start
                int startIndexSave = startIndex;
                startIndex = endIndex;
                // 0 1 2
                // 1 2 0
                // 2 0 1
                endIndex = startIndexSave-1 == -1 ? sprites.Length - 1 : startIndexSave - 1;
            }
        }        
    }
}
