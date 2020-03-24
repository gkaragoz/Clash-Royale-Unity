using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAgent : AIPath {

	public float searchTime = 0.1f;
	public bool shouldSearch = true;
	public Transform[] goals;

	private List<Vector3> _goalVectors;
	private MultiTargetPath MTP; 

	protected override void Start() {
		base.Start();

		_goalVectors = new List<Vector3>();
		foreach (Transform goal in goals) {
			_goalVectors.Add(goal.position);
		}

		StartCoroutine(ISearch());
    }

    private IEnumerator ISearch() {
		while (shouldSearch) {
			 MTP = seeker.StartMultiTargetPath(transform.position, _goalVectors.ToArray(), false);
			
			yield return new WaitForSeconds(searchTime);
		}
	}

	public override void OnTargetReached() {
		_goalVectors.Remove(MTP.originalEndPoint);
	}

}