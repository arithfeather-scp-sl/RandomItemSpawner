﻿using ArithFeather.Points;
using ArithFeather.Points.DataTypes;
using Exiled.API.Features;
using UnityEngine;

namespace ArithFeather.CustomItemSpawner
{
	public class ItemSpawnPoint
	{
		public delegate void NotifyPointFreedom(bool isFree);
		public event NotifyPointFreedom OnNotifyPointFreedom;

		public Room Room => _fixedPoint.Room;
		public Vector3 Position => _fixedPoint.Position;
		public Quaternion Rotation => _fixedPoint.Rotation;

		private readonly FixedPoint _fixedPoint;

		public ItemSpawnPoint(FixedPoint fixedPoint)
		{
			_fixedPoint = fixedPoint;
		}

		private bool _isFree = true;

		public bool IsFree
		{
			set
			{
				if (value != _isFree)
				{
					OnNotifyPointFreedom?.Invoke(value);
					_isFree = value;
				}
			}
			get => _isFree;
		}
	}
}
