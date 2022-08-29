using System;
using DG.Tweening;
using UnityEngine;
using static DG.Tweening.DOTween;

namespace _Project.Common
{
	//DOTween facade implementation, will expand as needed
	public class GTween : MonoBehaviour
	{
		public static void MoveObject(Transform target_transform, Vector3 end_position, float duration, Ease ease)
		{
			target_transform.DOMove(end_position, duration).SetEase(ease);
		}
		
		public static void SwapPositions(Transform first_transform, Transform second_transform, float duration, Ease ease)
		{
			var tmp_pos = second_transform.position;
			second_transform.DOMove(first_transform.position, duration).SetEase(ease);
			first_transform.DOMove(tmp_pos, duration).SetEase(ease);
		}
		
		public static void YoYoObject(Transform target_transform, Vector3 end_position, float duration, Ease ease, bool loop)
		{
			if (loop)
				target_transform.DOMove(end_position, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
		}
		
		public static void ShakeObject(Transform target_transform, float duration, float strength)
		{
			target_transform.DOShakePosition(duration, strength);
		}
		
		public static void BounceObject(Transform target_transform, float duration, float strength, LoopType loop_type, bool loop)
		{
			if (loop)
				target_transform.DOJump(target_transform.position, strength, 1, duration).SetLoops(-1, loop_type);
			else
				target_transform.DOJump(target_transform.position, strength, 1, duration);
		}
		
		public static void StopTween(Transform target_transform)
		{
			target_transform.DOComplete();
		}
		
		public static void PunchObject(Transform target_transform, float duration, Vector3 target_pos)
		{
			target_transform.DOPunchPosition(target_pos, duration);
		}
		
		public static void RotateObject(Transform target_transform, Vector3 end_rotation, float duration)
		{
			target_transform.DORotate(end_rotation, duration);
		}
	}
}