using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory(ActionCategory.UnityObject)]
	public class getInProp : FsmStateAction
	{

		public FsmOwnerDefault gameObject;

		public bool everyFrame;


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var ghost = gameObject.GameObject.Value;
			ghost.GetComponent<GhostAI>().OnEnter();
			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnFixedUpdate()
		{
			var ghost = gameObject.GameObject.Value;
			ghost.GetComponent<GhostAI>().OnEnter();
		}
	}

}
