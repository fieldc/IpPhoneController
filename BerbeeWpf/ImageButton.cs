﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerbeeWpf
{
	public class ImageButton
	{
		public static readonly DependencyProperty ImageProperty;

		public static ImageSource GetImage(DependencyObject obj)
		{
			return (ImageSource)obj.GetValue(ImageProperty);
		}
		public static void SetImage(DependencyObject obj, ImageSource value)
		{
			obj.SetValue(ImageProperty, value);
		}

		static ImageButton()
		{
			var metadata = new FrameworkPropertyMetadata((ImageSource)null);
			ImageProperty = DependencyProperty.RegisterAttached("Image",
																typeof(ImageSource),
																typeof(ImageButton), metadata);
		}
	}
}
