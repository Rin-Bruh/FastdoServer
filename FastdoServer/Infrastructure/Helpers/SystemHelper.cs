using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using FastdoServer.Common.Helpers;

namespace FastdoServer.Infrastructure.Helpers
{
  public static class SystemHelper
  {
    private static readonly string Characters = "0123456789abcdefghijklmnopqrstuvwxyz";

    public static string RandomId()
    {
      DateTime date = DateTime.Now;

      var result = new StringBuilder();
      result.Append(DateTime.Now.ToString("yy"));
      result.Append(Characters[date.Month]);
      result.Append(Characters[date.Day]);

      var uid = Guid.NewGuid().ToString().Replace("-", "");
      var random = new Random();
      var length = 20;

      result.Append(uid.Substring(random.Next(0, uid.Length - length - 1), length));

      return result.ToString().ToUpper();
    }

    public static string RandomIdCompany()
    {
      DateTime date = DateTime.Now;

      var result = new StringBuilder();
      result.Append(DateTime.Now.ToString("yy"));
      result.Append(Characters[date.Month]);
      result.Append(Characters[date.Day]);

      var uid = Guid.NewGuid().ToString().Replace("-", "");
      var random = new Random();
      var length = 10;

      result.Append(uid.Substring(random.Next(0, uid.Length - length - 1), length));

      return result.ToString().ToUpper();
    }

    public static string RemoveDiacritics(string input)
    {
      string normalized = input.Normalize(NormalizationForm.FormD);
      char[] chars = normalized
          .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
          .ToArray();
      return new string(chars).Normalize(NormalizationForm.FormC).ToLower();
    }

    private static string RootPassword = "anonymous@2451995##";

    public static void CleanUpDispose<T>(List<T> list) where T : IDisposable
    {
      foreach (T item in list)
      {
        if (item != null)
          item.Dispose();
      }
      list.Clear();
      list.TrimExcess();
    }

    public static void CleanUp<T>(List<T> list)
    {
      list.Clear();
      list.TrimExcess();
    }

    public static async Task<string> GetRoot()
    {
      var data = await ReadFileAsync();

      // Nếu chưa hề có file hoặc mật khẩu
      if (!data.IsEmpty())
      {
        RootPassword = data;
      }

      return RootPassword;
    }

    public static async Task<string> CreateRoot()
    {
      // Tạo mật khẩu mới
      var newPass = await WriteToFile();
      if (!newPass.IsEmpty())
      {
        RootPassword = newPass;
      }

      return RootPassword;
    }

    private static async Task<string> WriteToFile()
    {
      var now = DateTime.Now;
      var random = Guid.NewGuid().ToString();
      var fileName = "root.txt";
      try
      {
        FileStream ostrm;
        StreamWriter writer;
        try
        {
          ostrm = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
          writer = new StreamWriter(ostrm);
          await writer.WriteAsync($"{random}");
        }
        catch (Exception e)
        {
          Console.WriteLine($"Cannot open {fileName} for writing");
          Console.WriteLine(e.ToString());
          return "";
        }

        writer.Close();
        ostrm.Close();

        return random;
      }
      catch
      {
        return "";
      }
    }

    private static async Task<string> ReadFileAsync()
    {
      var fileName = "root.txt";
      var value = "";
      try
      {
        FileStream ostrm;
        StreamReader reader;
        try
        {
          ostrm = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
          reader = new StreamReader(ostrm);
          value = await reader.ReadLineAsync();
        }
        catch (Exception e)
        {
          Console.WriteLine($"Cannot open {fileName} for read");
          Console.WriteLine(e.ToString());
          return value;
        }

        reader.Close();
        ostrm.Close();

        return value;

      }
      catch
      {
        return value;
      }
    }

    public static void AppendTextToFile(string content)
    {
      string filePath = Environment.CurrentDirectory + "\\wwwroot\\logs.txt";

      // Check if the file exists, if not create it
      if (!File.Exists(filePath))
      {
        File.Create(filePath).Close();
      }

      // Append the content to the file, and add a new line
      using (StreamWriter sw = File.AppendText(filePath))
      {
        sw.WriteLine(content);
      }
    }



    public static string GenerateVerfificationCodeHaveText()
    {
      string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

      int len = 4;
      var randomBytes = new byte[12];

      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(randomBytes);
      }

      var codeChars = randomBytes.Select(b => chars[b % chars.Length]).ToArray();

      return $"{new string(codeChars, 0, len)}-{new string(codeChars, 4, len)}-{new string(codeChars, 8, len)}";
    }
  }
}
