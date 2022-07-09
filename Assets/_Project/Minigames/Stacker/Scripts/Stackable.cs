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
		private Transform _plateParent;
		private GameObject _stackableTypeData;

		private void Awake()
		{
			//_frictionJoint = GetComponent<FrictionJoint2D>();
			//_frictionJoint.enabled = false;
			_rigidbody = GetComponentInParent<Rigidbody>();
			_rigidbody.velocity = Vector3.zero;
			_plateParent = StackerManager.Instance.PlateParent;
		}
		
		private void OnTriggerEnter(Collider other)
		{
			switch (other.gameObject.tag)
			{
				case "Player":
					break;
				case "Platform":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					_rigidbody.velocity = Vector3.zero;
					//_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
					//transform.parent.SetParent(_plate.gameObject.transform);
					transform.parent.SetParent(_plateParent);
					break;
				case "Stackable":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					_rigidbody.velocity = Vector3.zero;
					//_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
					//transform.parent.SetParent(_plate.gameObject.transform.parent);
					transform.parent.SetParent(_plateParent);
					break;
				case "Floor":
					StartCoroutine(DestroyBlock());
					break;
				default:
					break;
			}
		}

		private void OnTriggerStay(Collider other)
		{
			switch (other.gameObject.tag)
			{
				case "Player":
					break;
				case "Platform":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					//transform.parent.SetParent(_plate.gameObject.transform);
					//_rigidbody.velocity = Vector3.zero;
					transform.parent.SetParent(_plateParent);
					break;
				case "Stackable":
					//_frictionJoint.enabled = true;
					//_frictionJoint.connectedAnchor = other.contacts[0].point;
					//transform.parent.SetParent(_plate.gameObject.transform.parent);
					//_rigidbody.velocity = Vector3.zero;
					transform.parent.SetParent(_plateParent);
					break;
				case "Floor":
					StartCoroutine(DestroyBlock());
					break;
				default:
					//transform.parent.SetParent(StackerManager.Instance.transform);
					break;
			}
		}

		private void OnTriggerExit(Collider other)
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
					//transform.parent.SetParent(null);
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
			transform.parent.SetParent(StackerManager.Instance.transform);
			_rigidbody.velocity = Vector3.zero;
			//transform.position = Vector3.zero;
			yield return new WaitForFixedUpdate();
			transform.parent.gameObject.SetActive(false);
		}
	}
}