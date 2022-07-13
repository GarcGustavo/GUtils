using System;
using _Project.Common;
using UnityEngine;

namespace _Project.PortalSystem
{
	public class Portal : MonoBehaviour
	{
		public Portal linkedPortal;
		public MeshRenderer screen;
		private Camera playerCam;
		private Camera portalCam;
		RenderTexture portalTexture;

		private void Awake()
		{
			playerCam = CommonUtils.MainCamera();
			portalCam = GetComponentInChildren<Camera>();
			portalCam.enabled = false;
		}

		private void CreateViewTexture()
		{
			if(portalTexture == null || portalTexture.width != Screen.width || portalTexture.height != Screen.height)
			{
				if(portalTexture != null)
				{
					portalTexture.Release();
				}
				portalTexture = new RenderTexture(Screen.width, Screen.height, 0);
				portalCam.targetTexture = portalTexture;
			}
		}

		public void RenderView()
		{
			screen.enabled = true;
			CreateViewTexture();
			
			var m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix * playerCam.transform.localToWorldMatrix;
			portalCam.Render();
			screen.enabled = true;
		}
	}
}