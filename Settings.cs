﻿using ACT.DFAssist.Toolkits;
using Newtonsoft.Json;
using System.Drawing;

namespace ACT.DFAssist
{
	static class Settings
	{
		// 태그
		public static string TagName = "202010171";  // 202010162 -> 202010171

		// 경로
		public static string Path { get; set; }

		// 선택한 페이트 목록
		public static readonly ConcurrentHashSet<string> SelectedFates = new ConcurrentHashSet<string>();

		// 모든 페이트 로깅
		public static bool LoggingWholeFates { get; set; }

		// 오버레이 사용
		public static bool UseOverlay { get; set; }

		// 오버레이 위치
		public static Point OverlayLocation { get; set; } = new Point(0, 0);

		// 플러그인 경로
		public static string PluginPath { get; set; } = "";

		// 오버레이 자동 감추기
		public static bool AutoHideOverlay { get; set; }

		// 프로그램 버전
		public static int ClientVersion { get; set; } = 0;


		// GITHUB에서 버전 태그르 가져온다 -> 업데이트용
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<보류 중>")]
		internal static string GetTagNameForUpdate()
		{
			string url = "https://api.github.com/repos/purutu/ACT.DFAssist/releases/latest";
			var rq = Toolkits.HttpHelper.Request(url);

			if (rq != null)
			{
				try
				{
					var js = JsonConvert.DeserializeObject<dynamic>(rq);
					var tagname = js.tag_name.ToObject<string>();   // "tag_name": "20200113"

					return tagname;
				}
				catch
				{
				}
			}

			// 확인못하면 체크 못하게 현재 태그 날림
			return TagName;
		}
	}
}
