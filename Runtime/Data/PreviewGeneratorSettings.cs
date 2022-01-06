using System;
using UnityEngine;

namespace Hertzole.ALE
{
	[Serializable]
	public struct PreviewGeneratorSettings
	{
		[SerializeField]
		private bool isOrthographic;
		[SerializeField]
		private Color backgroundColor;
		[SerializeField]
		private float padding;
		[SerializeField]
		private Vector3 previewDirection;
		[SerializeField]
		private Vector2Int imageSize;

		public bool IsOrthographic { get { return isOrthographic; } }
		public Color BackgroundColor { get { return backgroundColor; } }
		public float Padding { get { return padding; } }
		public Vector3 PreviewDirection { get { return previewDirection; } }
		public Vector2Int ImageSize { get { return imageSize; } }

		public static PreviewGeneratorSettings Default
		{
			get
			{
				return new PreviewGeneratorSettings
				{
					isOrthographic = true,
					backgroundColor = Color.clear,
					padding = 0,
					imageSize = new Vector2Int(128, 128),
					previewDirection = new Vector3(-1f, -1f, -1f)
				};
			}
		}
	}
}