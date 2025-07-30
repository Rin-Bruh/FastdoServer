using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace FastdoServer.Common.Helpers
{
	public static class AppHelper
	{
		public static string CreateMD5(string input)
		{

			using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
			{
				byte[] inputBytes = Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Convert the byte array to hexadecimal string
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("X2"));
				}
				return sb.ToString();
			}
		}



		public static T Clone<T>(T self)
		{
			var serialized = JsonConvert.SerializeObject(self);
			return JsonConvert.DeserializeObject<T>(serialized);
		}
		public static bool TryConvert<T>(this string numberString, out T value) where T : struct, IConvertible
		{
			value = default;

			if (numberString.IsEmpty())
				return false;

			try
			{
				if (typeof(T) == typeof(int) && int.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out int intValue))
				{
					value = (T)(object)intValue;
					return true;
				}
				if (typeof(T) == typeof(double) && double.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue))
				{
					value = (T)(object)doubleValue;
					return true;
				}
				if (typeof(T) == typeof(float) && float.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out float floatValue))
				{
					value = (T)(object)floatValue;
					return true;
				}
				if (typeof(T) == typeof(decimal) && decimal.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalValue))
				{
					value = (T)(object)decimalValue;
					return true;
				}
				if (typeof(T) == typeof(long) && long.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out long longValue))
				{
					value = (T)(object)longValue;
					return true;
				}
				if (typeof(T) == typeof(short) && short.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out short shortValue))
				{
					value = (T)(object)shortValue;
					return true;
				}
				if (typeof(T) == typeof(byte) && byte.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out byte byteValue))
				{
					value = (T)(object)byteValue;
					return true;
				}
				if (typeof(T) == typeof(sbyte) && sbyte.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out sbyte sbyteValue))
				{
					value = (T)(object)sbyteValue;
					return true;
				}
				if (typeof(T) == typeof(uint) && uint.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out uint uintValue))
				{
					value = (T)(object)uintValue;
					return true;
				}
				if (typeof(T) == typeof(ulong) && ulong.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out ulong ulongValue))
				{
					value = (T)(object)ulongValue;
					return true;
				}
				if (typeof(T) == typeof(ushort) && ushort.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out ushort ushortValue))
				{
					value = (T)(object)ushortValue;
					return true;
				}
			}
			catch
			{
				// Handle any unexpected exceptions
			}
			return false;
		}

		public static bool TryConvert<T>(this string numberString, T defaultValue, out T value) where T : struct, IConvertible
		{
			value = defaultValue;

			if (numberString.IsEmpty())
				return false;

			try
			{
				if (typeof(T) == typeof(int) && int.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out int intValue))
				{
					value = (T)(object)intValue;
					return true;
				}
				if (typeof(T) == typeof(double) && double.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleValue))
				{
					value = (T)(object)doubleValue;
					return true;
				}
				if (typeof(T) == typeof(float) && float.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out float floatValue))
				{
					value = (T)(object)floatValue;
					return true;
				}
				if (typeof(T) == typeof(decimal) && decimal.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalValue))
				{
					value = (T)(object)decimalValue;
					return true;
				}
				if (typeof(T) == typeof(long) && long.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out long longValue))
				{
					value = (T)(object)longValue;
					return true;
				}
				if (typeof(T) == typeof(short) && short.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out short shortValue))
				{
					value = (T)(object)shortValue;
					return true;
				}
				if (typeof(T) == typeof(byte) && byte.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out byte byteValue))
				{
					value = (T)(object)byteValue;
					return true;
				}
				if (typeof(T) == typeof(sbyte) && sbyte.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out sbyte sbyteValue))
				{
					value = (T)(object)sbyteValue;
					return true;
				}
				if (typeof(T) == typeof(uint) && uint.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out uint uintValue))
				{
					value = (T)(object)uintValue;
					return true;
				}
				if (typeof(T) == typeof(ulong) && ulong.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out ulong ulongValue))
				{
					value = (T)(object)ulongValue;
					return true;
				}
				if (typeof(T) == typeof(ushort) && ushort.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out ushort ushortValue))
				{
					value = (T)(object)ushortValue;
					return true;
				}
			}
			catch
			{
				// Handle any unexpected exceptions
			}
			return false;
		}




		/// <summary>
		/// Kiểm tra dữ liệu rỗng
		/// </summary>
		public static bool IsEmpty(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return string.IsNullOrEmpty(source);
			else
				return string.IsNullOrEmpty(source.Trim());
		}

		/// <summary>
		/// Lấy khoản thời gian
		/// 1. Tuần này
		/// 2. Tháng này
		/// 3. Quý này
		/// 4. 30 ngày gần đây
		/// 5. 3 tháng gần đây
		/// 6. 6 tháng gần đây
		/// 7. Quý trước
		/// 8. 7 ngày tiếp theo
		/// 9. 14 ngày tiếp theo
		/// 10. 30 ngày tiếp theo
		/// 11. Tuần trước
		/// 12. 60 ngày tiếp theo
		/// 13. 180 ngày tiếp theo
		/// 22. Tháng trước
		/// </summary>
		public static void GetTimeSpan(int type, out DateTime start, out DateTime end)
		{
			var date = DateTime.Today;
			start = date;
			end = date;

			if (type == 1)
			{
				if (date.DayOfWeek == DayOfWeek.Tuesday)
					start = date.AddDays(-1);
				else if (date.DayOfWeek == DayOfWeek.Wednesday)
					start = date.AddDays(-2);
				else if (date.DayOfWeek == DayOfWeek.Thursday)
					start = date.AddDays(-3);
				else if (date.DayOfWeek == DayOfWeek.Friday)
					start = date.AddDays(-4);
				else if (date.DayOfWeek == DayOfWeek.Saturday)
					start = date.AddDays(-5);
				else if (date.DayOfWeek == DayOfWeek.Sunday)
					start = date.AddDays(-6);
				end = start.AddDays(6);
			}
			else if (type == 2)
			{
				start = Convert.ToDateTime(string.Format("{0:yyyy-MM-01}", DateTime.Today));
				end = start.AddMonths(1).AddDays(-1);
			}
			else if (type == 3)
			{
				if (date.Month <= 3)
					start = Convert.ToDateTime(string.Format("{0:yyyy-01-01}", date));
				else if (date.Month <= 6)
					start = Convert.ToDateTime(string.Format("{0:yyyy-04-01}", date));
				else if (date.Month <= 9)
					start = Convert.ToDateTime(string.Format("{0:yyyy-07-01}", date));
				else
					start = Convert.ToDateTime(string.Format("{0:yyyy-10-01}", date));
				end = start.AddMonths(3).AddDays(-1);
			}
			else if (type == 4)
			{
				start = date.AddDays(-30);
				end = date;
			}
			else if (type == 5)
			{
				start = Convert.ToDateTime(string.Format("{0:yyyy-MM-01}", DateTime.Today)).AddMonths(-2);
				end = start.AddMonths(3).AddDays(-1);
			}
			else if (type == 6)
			{
				start = Convert.ToDateTime(string.Format("{0:yyyy-MM-01}", DateTime.Today)).AddMonths(-5);
				end = start.AddMonths(6).AddDays(-1);
			}
			else if (type == 7)
			{
				if (date.Month <= 3)
					start = Convert.ToDateTime(string.Format("{0:yyyy-10-01}", date.AddYears(-1)));
				else if (date.Month <= 6)
					start = Convert.ToDateTime(string.Format("{0:yyyy-01-01}", date));
				else if (date.Month <= 9)
					start = Convert.ToDateTime(string.Format("{0:yyyy-04-01}", date));
				else
					start = Convert.ToDateTime(string.Format("{0:yyyy-07-01}", date));
				end = start.AddMonths(3).AddDays(-1);
			}
			else if (type == 8)
			{
				end = start.AddDays(6);
			}
			else if (type == 9)
			{
				end = start.AddDays(13);
			}
			else if (type == 10)
			{
				end = start.AddDays(29);
			}
			else if (type == 11)
			{
				GetTimeSpan(1, out start, out end);
				start = start.AddDays(-7);
				end = end.AddDays(-7);
			}
			else if (type == 12)
			{
				end = start.AddDays(59);
			}
			else if (type == 13)
			{
				end = start.AddDays(179);
			}
			else if (type == 22)
			{
				start = Convert.ToDateTime(string.Format("{0:yyyy-MM-01}", DateTime.Today)).AddMonths(-1);
				end = start.AddMonths(1).AddDays(-1);
			}
		}

		/// <summary>
		/// Hàm xóa HTML từ desktop đẩy về
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string StripHTML(string input)
		{
			return Regex.Replace(input, "<.*?>", " ");
		}

		public static void ReplaceNullsWithDefaults<T>(T obj)
		{
			var properties = typeof(T).GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

			foreach (var property in properties)
			{
				var value = property.GetValue(obj);
				var type = property.PropertyType;

				if (value == null)
				{
					if (type == typeof(string))
					{
						property.SetValue(obj, string.Empty);
					}
					else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
					{
						var listType = typeof(List<>).MakeGenericType(type.GetGenericArguments()[0]);
						var instance = Activator.CreateInstance(listType);
						property.SetValue(obj, instance);
					}
					else if (type.IsClass)
					{
						var instance = Activator.CreateInstance(type);
						property.SetValue(obj, instance);
					}
				}
			}
		}

		/// <summary>
		/// Đổi cách hiển thị thời gian
		/// </summary>
		public static string ConvertDate(DateTime? date)
		{
			DateTime DateTimeNow = DateTime.Now;
			string postTime = string.Empty;
			if (date != null)
			{
				if (DateTime.Compare(date.Value, DateTimeNow) <= 0)
				{
					TimeSpan spanMe = DateTimeNow.Subtract(date.Value);
					if (spanMe.Days < 1)
					{
						if (spanMe.Hours < 1)
						{
							if (spanMe.Minutes < 1)
							{
								if (spanMe.Seconds < 5)
									postTime = "vừa xong";
								else
									postTime = spanMe.Seconds + " giây trước";
							}
							else
								postTime = spanMe.Minutes + " phút trước";
						}
						else
							postTime = spanMe.Hours + " giờ trước";
					}
					else if (spanMe.Days < 30)
					{
						postTime = spanMe.Days + " ngày trước";
					}
					else if (spanMe.Days < 365)
					{
						postTime = Convert.ToInt32(spanMe.Days / 30) + " tháng trước";
					}
					else if (spanMe.Days > 365)
					{
						postTime = Convert.ToInt32(spanMe.Days / 365) + " năm trước";
					}
				}
				else
				{
					TimeSpan spanMe = date.Value.Subtract(DateTimeNow);
					if (spanMe.Days < 1)
					{
						if (spanMe.Hours < 1)
						{
							if (spanMe.Minutes < 1)
							{
								if (spanMe.Seconds < 5)
									postTime = "bây giờ";
								else
									postTime = spanMe.Seconds + " giây nữa";
							}
							else
								postTime = spanMe.Minutes + " phút nữa";
						}
						else
							postTime = spanMe.Hours + " giờ nữa";
					}
					else if (spanMe.Days < 30)
					{
						postTime = spanMe.Days + " ngày nữa";
					}
					else if (spanMe.Days < 365)
					{
						postTime = Convert.ToInt32(spanMe.Days / 30) + " tháng nữa";
					}
					else if (spanMe.Days > 365)
					{
						postTime = Convert.ToInt32(spanMe.Days / 365) + " năm nữa";
					}
				}
			}

			return postTime;
		}

		/// <summary>
		/// So sánh thời gian ước tính và realtime
		/// </summary>
		public static string CompareTime(long estimate, long realTime, bool checkEarly = true)
		{
			DateTime estimateDate = new DateTime(estimate);
			DateTime realTimeDate = new DateTime(realTime);
			string result = string.Empty;
			// trễ hạn
			if (DateTime.Compare(estimateDate, realTimeDate) < 0)
			{
				TimeSpan spanMe = realTimeDate.Subtract(estimateDate);
				if (spanMe.Days < 1)
				{
					if (spanMe.Hours < 1)
					{
						if (spanMe.Minutes < 1)
							result = $"Trễ < 1 phút";
						else
							result = $"Trễ {spanMe.Minutes} phút";
					}
					else
						result = $"Trễ {spanMe.Hours} giờ";
				}
				else
					result = $"Trễ {spanMe.Days} ngày";
			}
			else if (DateTime.Compare(estimateDate, realTimeDate) > 0 && checkEarly)
			{
				// chưa trễ hạn
				TimeSpan spanMe = estimateDate.Subtract(realTimeDate);
				if (spanMe.Days < 1)
				{
					if (spanMe.Hours < 1)
					{
						if (spanMe.Minutes < 1)
							result = $"Còn < 1 phút";
						else
							result = $"Còn {spanMe.Minutes} phút";
					}
					else
						result = $"Còn {spanMe.Hours} giờ";
				}
				else
					result = $"Còn {spanMe.Days} ngày";
			}
			else
				result = "";

			return result;
		}

		public static List<T> CloneList<T>(List<T> self)
		{
			var result = new List<T>();

			foreach (var item in self)
			{
				result.Add(Clone(item));
			}

			return result;
		}


		/// <summary>
		/// Chuyển mốc thời gian trong ngày về đầu ngày
		/// </summary>
		public static DateTime DateToDay(DateTime date)
		{
			return Convert.ToDateTime(date.ToString("yyyy-MM-dd"));
		}


		/// <summary>
		/// Chuyển thời gian thành thứ trong tuần bằng tiếng Việt
		/// </summary>
		public static string ConvertWeekdays(DateTime value)
		{
			CultureInfo englishCulture = new("en-US");
			var date = value.ToString("ddd", englishCulture);

			if (date.Contains("Mon"))
				return date.Replace("Mon", "Th 2");
			else if (date.Contains("Tue"))
				return date.Replace("Tue", "Th 3");
			else if (date.Contains("Wed"))
				return date.Replace("Wed", "Th 4");
			else if (date.Contains("Thu"))
				return date.Replace("Thu", "Th 5");
			else if (date.Contains("Fri"))
				return date.Replace("Fri", "Th 6");
			else if (date.Contains("Sat"))
				return date.Replace("Sat", "Th 7");
			else if (date.Contains("Sun"))
				return date.Replace("Sun", "CN");
			return "";
		}

		/// <summary>
		/// Chuyển thời gian thành thứ trong tuần bằng tiếng Việt
		/// </summary>
		public static string ConvertWeekdays(DateTime value, bool isFull = false)
		{
			// Định dạng riêng cho giờ là theo tiếng Anh (en-US)
			CultureInfo englishCulture = new CultureInfo("en-US");
			var date = value.ToString("ddd", englishCulture);

			if (date.Contains("Mon"))
				return date.Replace("Mon", isFull ? "Thứ 2" : "T2");
			else if (date.Contains("Tue"))
				return date.Replace("Tue", isFull ? "Thứ 3" : "T3");
			else if (date.Contains("Wed"))
				return date.Replace("Wed", isFull ? "Thứ 4" : "T4");
			else if (date.Contains("Thu"))
				return date.Replace("Thu", isFull ? "Thứ 5" : "T5");
			else if (date.Contains("Fri"))
				return date.Replace("Fri", isFull ? "Thứ 6" : "T6");
			else if (date.Contains("Sat"))
				return date.Replace("Sat", isFull ? "Thứ 7" : "T7");
			else if (date.Contains("Sun"))
				return date.Replace("Sun", "CN");
			else if (date.Contains("Th"))
				return date.Replace("Th ", isFull ? "Thứ" : "T");
			else if (date == "CN")
				return "CN";

			return "";
		}


		/// <summary>
		/// Tính số phút chênh lệnh giũa 2 mốc thời gian
		/// </summary>
		/// <returns>Lớn 0: date2 > datet1</returns>
		public static long CompareTime(DateTime date1, DateTime date2)
		{
			date1 = date1.Date + new TimeSpan(date1.Hour, date1.Minute, 0);
			date2 = date2.Date + new TimeSpan(date2.Hour, date2.Minute, 0);

			TimeSpan spanMe = date2.Subtract(date1);
			return Convert.ToInt64(spanMe.TotalMinutes);
		}


		/// <summary>
		/// So sánh thời gian ước tính và realtime
		/// </summary>
		public static string CompareTime(long estimate, bool checkEarly = true)
		{
			DateTime estimateDate = new DateTime(estimate);
			DateTime realTimeDate = DateTime.Now;
			string result = string.Empty;
			// trễ hạn
			if (DateTime.Compare(estimateDate, realTimeDate) < 0)
			{
				TimeSpan spanMe = realTimeDate.Subtract(estimateDate);
				if (spanMe.Days < 1)
				{
					if (spanMe.Hours < 1)
					{
						if (spanMe.Minutes < 1)
							result = $"Trễ < 1 phút";
						else
							result = $"Trễ {spanMe.Minutes} phút";
					}
					else
						result = $"Trễ {spanMe.Hours} giờ";
				}
				else
					result = $"Trễ {spanMe.Days} ngày";
			}
			else if (DateTime.Compare(estimateDate, realTimeDate) > 0 && checkEarly)
			{
				// chưa trễ hạn
				TimeSpan spanMe = estimateDate.Subtract(realTimeDate);
				if (spanMe.Days < 1)
				{
					if (spanMe.Hours < 1)
					{
						if (spanMe.Minutes < 1)
							result = $"Còn < 1 phút";
						else
							result = $"Còn {spanMe.Minutes} phút";
					}
					else
						result = $"Còn {spanMe.Hours} giờ";
				}
				else
					result = $"Còn {spanMe.Days} ngày";
			}
			else
				result = "";

			return result;
		}

		public static string CovertDate(long date_done, long date_end, int status)
		{
			string postTime = string.Empty;
			DateTime date;
			if (date_done != 0 && status == 4)
				date = new DateTime(date_done);
			else
				date = DateTime.Now;

			if (date_done > date_end || date.Ticks > date_end)
			{
				TimeSpan spanMe = date.Subtract(new DateTime(date_end));

				if (spanMe.Days < 1)
				{
					if (spanMe.Hours < 1)
					{
						if (spanMe.Minutes < 1)
						{
							postTime = spanMe.Seconds + " giây";
						}
						else
							postTime = spanMe.Minutes + " phút";
					}
					else
						postTime = spanMe.Hours + " giờ";
				}
				else if (spanMe.Days < 30)
				{
					postTime = spanMe.Days + " ngày";
				}
				else if (spanMe.Days < 365)
				{
					postTime = (System.Convert.ToInt32(spanMe.Days / 30)) + " tháng";
				}
				else if (spanMe.Days > 365)
				{
					postTime = (System.Convert.ToInt32(spanMe.Days / 365)) + " năm";
				}
			}
			return postTime;
		}

		/// <summary>
		/// Hàm chuyển vị trí thành thứ
		/// </summary>
		/// <param name="posstion"></param>
		/// <returns></returns>
		public static string ConvertPosToWeekdays(int posstion)
		{
			string dayOfWeek = posstion switch
			{
				2 => "T2",
				3 => "T3",
				4 => "T4",
				5 => "T5",
				6 => "T6",
				7 => "T7",
				_ => "CN",
			};
			return dayOfWeek;
		}

		public static string ToDate<T>(this T source, string format = "dd/MM/yyyy", bool returnEmpty = false)
		{
			if (source.GetType() != typeof(long))
			{
				return "Dữ liệu không phù hợp";
			}

			var value = (long)Convert.ChangeType(source, typeof(long));

			return value == 0 ? (returnEmpty ? "" : format) : $"{new DateTime(value).ToString(format)}";
		}

		/// <summary>
		/// Chuyển mốc thời gian trong ngày về đầu tháng
		/// </summary>
		public static DateTime DateToMonth(DateTime date)
		{
			return Convert.ToDateTime(date.ToString("yyyy-MM-01"));
		}


		public static string CheckNullString(string value)
		{
			return string.IsNullOrEmpty(value) ? string.Empty : value;
		}

		public static string GetBGColorTag(string colorTag)
		{
			string cl = string.IsNullOrEmpty(colorTag) ? "#FAFAFA" : colorTag;
			string insertString = "4D";
			return cl.Insert(1, insertString);
		}

		/// <summary>
		/// Đổi thành mã code
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ConvertCode(string str)
		{
			str = RemoveVietnamese(str).Replace(" ", "");
			str = str.ToLower();
			return str;
		}

		/// <summary>
		/// Tính % tiến độ
		/// </summary>
		public static double Progress(double result, double target)
		{
			if (target > 0)
			{
				double progress = result * 100 / target;
				if (progress > 100)
					return 100;
				else if (progress < -100)
					return -100; // Giới hạn % âm ở mức -100 nếu cần
				else
					return progress;
			}
			else
				return 0;
		}



		/// <summary>
		/// Tính số sao đánh giá
		/// </summary>
		public static double Review(double point, int count)
		{
			if (count > 0)
				return point / count;
			else
				return 0;
		}

		public static string ConverUrlYoutube(string link)
		{
			try
			{
				if (string.IsNullOrEmpty(link))
					return string.Empty;

				if (!Uri.IsWellFormedUriString(link, UriKind.Absolute))
					return string.Empty;

				// Parse the original URL
				var uri = new Uri(link);

				// Extract the video ID
				var segments = uri.AbsolutePath.Split('/');
				var videoId = segments[segments.Length - 1].Split('?')[0];
				if (!link.Contains("/watch?v="))
					link = $"https://www.youtube.com/watch?v={videoId}";

				if (link.Contains("/watch?v="))
					link = link.Replace("/watch?v=", "/embed/");
				if (link.Contains("&"))
					link = link.Substring(0, link.IndexOf("&"));
				if (link.Contains("drive.google.com"))
					link = link.Replace("/view", "/preview");
				// Create and return the standardized YouTube URL
				return link;
			}
			catch
			{
				// Handle or log the error if link is invalid
				return null;
			}
		}

		public static string CheckStringIsNullOrEmpty(string value)
		{
			return string.IsNullOrEmpty(value) ? string.Empty : value;
		}

		/// <summary>
		/// Kiểm tra nội dung có chưa từ khóa không ?
		/// </summary>
		public static bool SearchKeyword(string keyword, string content, bool ignoreVietnamese = false)
		{
			if (!keyword.IsEmpty() && !content.IsEmpty())
			{
				if (ignoreVietnamese)
				{
					content = RemoveVietnamese(content);
					keyword = RemoveVietnamese(keyword);
				}

				content = content.ToLower();
				var keyChar = keyword.ToLower().Trim().Split(' ');
				for (int i = 0; i < keyChar.Length; i++)
				{
					if (!content.Contains(keyChar[i]))
						return false;
				}

				return true;
			}
			else
				return true;
		}



		// <summary>
		/// Chuyển tiếng Việt có dấu sang không dấu
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string RemoveVietnamese(string str)
		{
			if (str.IsEmpty())
				return "";

			string[] VietnameseSigns = new string[]
			  {

			  "aAeEoOuUiIdDyY",

			  "áàạảãâấầậẩẫăắằặẳẵ",

			  "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

			  "éèẹẻẽêếềệểễ",

			  "ÉÈẸẺẼÊẾỀỆỂỄ",

			  "óòọỏõôốồộổỗơớờợởỡ",

			  "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

			  "úùụủũưứừựửữ",

			  "ÚÙỤỦŨƯỨỪỰỬỮ",

			  "íìịỉĩ",

			  "ÍÌỊỈĨ",

			  "đ",

			  "Đ",

			  "ýỳỵỷỹ",

			  "ÝỲỴỶỸ"
			  };
			for (int i = 1; i < VietnameseSigns.Length; i++)
			{
				for (int j = 0; j < VietnameseSigns[i].Length; j++)
					str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
			}
			return str;
		}

		public static DateTime EndOfDay(this DateTime dt)
		{
			return dt.Date.AddDays(1).AddTicks(-1);
		}

		private static readonly Random random = new Random();

		/// <summary>
		/// Tạo một số ngẫu nhiên
		/// </summary>
		public static int RandomInt(int min, int max)
		{
			return random.Next(min, max);
		}
	}
}
