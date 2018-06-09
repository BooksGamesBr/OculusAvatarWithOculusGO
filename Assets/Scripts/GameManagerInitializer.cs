using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;

public class GameManagerInitializer : MonoBehaviour {

	public OvrAvatar myAvatar;

    void Awake() {

		//Core.AsyncInitialize("1793939687353438");
        //Entitlements.IsUserEntitledToApplication().OnComplete(GetEntitlementCallback);
   //     Users.GetLoggedInUser().OnComplete(msg => {
			//myAvatar.oculusUserID = msg.GetUser().ID;
        //    Debug.Log(msg.GetUser().ID); // 自身の ID（16 桁の数字）を表示
        //    Debug.Log(msg.GetUser().OculusID); // 自身の ID（文字列）を表示
        //});

   //     OvrAvatarSDKManager.Instance.RequestAvatarSpecification(
			//10150022857785745, (specification) => {
            //    Debug.Log(specification.ToString());
            //});

        Core.Initialize();
        Users.GetLoggedInUser().OnComplete(GetLoggedInUserCallback);
        Request.RunCallbacks();  //avoids race condition with OvrAvatar.cs Start().
    }

	void GetLoggedInUserCallback(Message<User> message) {
        if (!message.IsError) {
			// 10150022857785745
			// 10150022857770130
			// 10150022857753417
			// 10150022857731826
			// 2120050248023634

			//myAvatar.oculusUserID = 2120050248023634;
			myAvatar.oculusUserID = message.Data.ID;
        }
    }

	// Use this for initialization
	void Start () {

	}

	void GetEntitlementCallback(Message msg) {
        if (msg.IsError) {
            Debug.LogError("You are NOT entitled to use this app.");
            UnityEngine.Application.Quit();
        } else {
            Debug.Log("You are entitled to use this app.");
        }
    }
}
