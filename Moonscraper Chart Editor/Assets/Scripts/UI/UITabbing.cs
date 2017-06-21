﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UITabbing : MonoBehaviour {
    public static Selectable defaultSelectable = null;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = defaultSelectable;
            if (EventSystem.current.currentSelectedGameObject)
                next = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {
                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(EventSystem.current));  //if it's an input field, also set the text caret

                EventSystem.current.SetSelectedGameObject(next.gameObject, new BaseEventData(EventSystem.current));
            }
        }
    }
}