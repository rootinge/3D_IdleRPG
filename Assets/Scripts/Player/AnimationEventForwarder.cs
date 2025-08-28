using UnityEngine;

// 자식 오브젝트(Animator가 있는 곳)에 이 스크립트를 붙입니다.
public class AnimationEventForwarder : MonoBehaviour
{
    // 부모의 스크립트를 담을 변수
    private Player parentScript;

    void Awake()
    {
        // 시작할 때 부모 오브젝트에서 MyCharacterScript를 찾아서 저장해둡니다.
        parentScript = GetComponentInParent<Player>();
    }

    // 애니메이션 이벤트가 호출할 함수
    public void OnHit()
    {
        // 부모 스크립트가 있다면, 부모의 OnHit() 함수를 대신 호출해줍니다.
        if (parentScript != null)
        {
            parentScript.OnHit();
        }
        else
        {
            Debug.LogError("부모에서 MyCharacterScript를 찾을 수 없습니다!", gameObject);
        }
    }

}