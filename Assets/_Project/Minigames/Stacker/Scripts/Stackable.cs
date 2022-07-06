using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Minigames.Stacker.Scripts
{
	public class Stackable : MonoBehaviour
	{
		//private FrictionJoint2D _frictionJoint;
		private Rigidbody _rigidbody;
		private Plate _plate;

		private void Awake()
		{
			//_frictionJoint = GetComponent<FrictionJoint2D>();
			//_frictionJoint.enabled = false;
			_rigidbody = GetComponent<Rigidbody>();
			_plate = StackerManager.Instance.PlateObject;
		}
		
		private void OnCollisionEnter(Collision other)
		{
			switch (other.gameObject.tag)
			{
				case "Player":
					break;
				case "Platform":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					_rigidbody.velocity = Vector3.zero;
					transform.SetParent(_plate.gameObject.transform);
					break;
				case "Stackable":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					_rigidbody.velocity = Vector3.zero;
					transform.SetParent(_plate.gameObject.transform.parent);
					break;
				case "Floor":
					StartCoroutine(DestroyBlock());
					break;
				default:
					break;
			}
		}

		private void OnCollisionStay(Collision other)
		{
			switch (other.gameObject.tag)
			{
				case "Player":
					break;
				case "Platform":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					transform.SetParent(_plate.gameObject.transform);
					break;
				case "Stackable":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					transform.SetParent(_plate.gameObject.transform.parent);
					break;
				case "Floor":
					StartCoroutine(DestroyBlock());
					break;
				default:
					break;
			}
		}

		private void OnCollisionExit(Collision other)
		{
			switch (other.gameObject.tag)
			{
				case "Player":
					break;
				case "Platform":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					//transform.SetParent(null);
					break;
				case "Stackable":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					//transform.SetParent(null);
					break;
				case "Floor":
					//DestroyBlock();
					break;
				default:
					break;
			}
		}

		IEnumerator DestroyBlock()
		{
			//_frictionJoint.enabled = false;
			_rigidbody.velocity = Vector3.zero;
			//transform.position = Vector3.zero;
			yield return new WaitForFixedUpdate();
			gameObject.SetActive(false);
		}
	}
}