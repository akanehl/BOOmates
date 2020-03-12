using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory(ActionCategory.GameObject)]
	public class ChangeToClean : FsmStateAction
	{

		public FsmGameObject ghostAI;

		public FsmGameObject Chore;


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			changeClean();

			Finish();
		}

		void changeClean()
		{
			GameObject targetObject = ghostAI.Value;
			GameObject targetChore = Chore.Value;
			
			if (targetObject == null)
			{
				return;
			}
			if(!targetChore.GetComponent<Chores>().complete()){
				targetObject.GetComponent<GhostAI>().currentItem = GhostAI.selectedItem.CleanObject;
				targetObject.GetComponent<GhostAI>().currentChore = targetChore.GetComponent<Chores>();
			}
		}

	}

}
