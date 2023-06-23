using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SubscribableDatatypes
{
	internal class NSVariable<T> where T : notnull
	{
		private T _currentValue;
		public T Value
		{
			get => _currentValue;
			set
			{
				if (_currentValue.Equals(value))
					return;

				var old = _currentValue;
				_currentValue = value;
				ValueChanged?.Invoke(old);
			}
		}

		public event Action<T>? ValueChanged;

		public NSVariable(T initialValue)
		{
			_currentValue = initialValue;
		}

		public static implicit operator NSVariable<T>(T value)
		{
			return new NSVariable<T>(value);
		}

		public static implicit operator T(NSVariable<T> variable)
		{
			return variable.Value;
		}
	}
}