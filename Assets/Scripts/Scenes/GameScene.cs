using UnityEngine;


/// <summary>
/// Scene �ʱ�ȭ class
/// GameManager�� Init�� ���� �ý��� �ʱ�ȭ��� 
/// {Scene�̸�}Scene �ø���� �ش� ���� �ʱ�ȭ�� ���
/// </summary>
public class GameScene : MonoBehaviour
{
    private void Start()
    {
        GameManager.UI.ShowSceneUI<UI_GameScene>();
    }
}
