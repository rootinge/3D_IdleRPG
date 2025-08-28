using UnityEngine;

// �ڽ� ������Ʈ(Animator�� �ִ� ��)�� �� ��ũ��Ʈ�� ���Դϴ�.
public class AnimationEventForwarder : MonoBehaviour
{
    // �θ��� ��ũ��Ʈ�� ���� ����
    private Player parentScript;

    void Awake()
    {
        // ������ �� �θ� ������Ʈ���� MyCharacterScript�� ã�Ƽ� �����صӴϴ�.
        parentScript = GetComponentInParent<Player>();
    }

    // �ִϸ��̼� �̺�Ʈ�� ȣ���� �Լ�
    public void OnHit()
    {
        // �θ� ��ũ��Ʈ�� �ִٸ�, �θ��� OnHit() �Լ��� ��� ȣ�����ݴϴ�.
        if (parentScript != null)
        {
            parentScript.OnHit();
        }
        else
        {
            Debug.LogError("�θ𿡼� MyCharacterScript�� ã�� �� �����ϴ�!", gameObject);
        }
    }

}