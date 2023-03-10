using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScale : AudioSyncer
{
    public Vector3 beatScale;
    public Vector3 restScale;

    public override void OnBeat()
    {
        base.OnBeat();
        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", beatScale);
    }
    public override void OnUpdate()
    {
        base.OnUpdate();

        if (isBeat) return;

        transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
    }

    IEnumerator MoveToScale(Vector3 target)
    {
        Vector3 curr = transform.localScale;
		Vector3 initial = curr;
		float _timer = 0;

		while (curr != target)
		{
			curr = Vector3.Lerp(initial, target, _timer / timeToBeat);
			_timer += Time.deltaTime;

			transform.localScale = curr;

			yield return null;
		}

		isBeat = false;
    }
}
