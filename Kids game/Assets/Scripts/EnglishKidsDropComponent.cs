using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Spine.Unity;

public class EnglishKidsDropComponent : MonoBehaviour, IDropHandler
{
    public SkeletonAnimation StarsPrefab;
    public SkeletonAnimation StarEffect;
    public SkeletonAnimation RobotAnimation;
    public EnglishKidsAudio AudioManager;
    public string Color;

    private int _activeChild = 0;
    
    public void OnDrop(PointerEventData eventData)
    {
        EnglishKidsComponent RobotComponent = eventData.pointerDrag.GetComponent<EnglishKidsComponent>();
        if (transform.Find(RobotComponent.GetComponent<Image>().sprite.name) == true)
        {
            AudioManager.CorrectAnswer();
            AudioManager.Invoke("Mc" + Color, 1);
            Destroy(RobotComponent.gameObject);
            transform.Find(RobotComponent.GetComponent<Image>().sprite.name).gameObject.SetActive(true);
            _activeChild += 1;
            //код не самый лучший т.к. о существовании плагина spine я узнал час назад =)
            if (!StarEffect)
            {
                StarEffect = Instantiate(StarsPrefab);
                StarEffect.transform.SetParent(transform, false);
            }
            else
            {
                StarEffect = Instantiate(StarsPrefab);
                StarEffect.transform.SetParent(transform, false);
            }
            if(_activeChild == 4)
            {
                Instantiate(RobotAnimation);
                Destroy(gameObject);
            }
        }
        else
        {
            AudioManager.WrongAnswer();
            RobotComponent.FalseAnser();
        }
    }
}
