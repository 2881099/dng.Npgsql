﻿using NpgsqlTypes;
using System;

public static partial class NpgsqlTypesExtensions {
	/// <summary>
	/// 测量两个经纬度的距离，返回单位：米
	/// </summary>
	/// <param name="that">经纬坐标1</param>
	/// <param name="point">经纬坐标2</param>
	/// <returns>返回距离（单位：米）</returns>
	public static double Distance(this NpgsqlPoint that, NpgsqlPoint point) {
		double radLat1 = (double)(that.Y) * Math.PI / 180d;
		double radLng1 = (double)(that.X) * Math.PI / 180d;
		double radLat2 = (double)(point.Y) * Math.PI / 180d;
		double radLng2 = (double)(point.X) * Math.PI / 180d;
		return 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((radLat1 - radLat2) / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin((radLng1 - radLng2) / 2), 2))) * 6378137;
	}
}