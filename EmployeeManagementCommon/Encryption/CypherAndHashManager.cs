using System;
using System.Security.Cryptography;
using System.Text;

namespace ASM.EmployeeManagement.Common.Encryption
{
	/// <summary>
	/// Cypher And Hash Manager
	/// </summary>
	public class CypherAndHashManager
	{
		#region Private Members

		/// <summary>
		/// Byte to Hex key
		/// </summary>
		private const string ByteToHexKey = "x2";

		#endregion

		#region Hash

		/// <summary>
		/// Hash- User password and cannot decrypt
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static string Hash(string data)
		{
			if (string.IsNullOrWhiteSpace(data))
			{
				return data;
			}

			using (SHA1CryptoServiceProvider hashsha1 = new SHA1CryptoServiceProvider())
			{
				byte[] arrValue = hashsha1.ComputeHash(UTF8Encoding.UTF8.GetBytes(data));
				hashsha1.Clear();
				return Convert.ToBase64String(arrValue);
			}
		}

		/// <summary>
		/// Hash with 20 character
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static string Hash20Char(string data)
		{
			using (var sha1 = SHA1.Create())
			{
				byte[] hasbyte = sha1.ComputeHash(UTF8Encoding.UTF8.GetBytes(data));

				var te = Convert.ToBase64String(hasbyte);
				var sb = new StringBuilder();
				foreach (byte b in hasbyte)
				{
					var hex = b.ToString(ByteToHexKey);
					sb.Append(hex);
				}

				return sb.ToString().Substring(0, 20);
			}
		}
		#endregion

	}
}
