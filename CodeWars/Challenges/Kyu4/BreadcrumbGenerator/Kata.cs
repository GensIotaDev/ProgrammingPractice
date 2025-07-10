using System.Text;
using System.Text.RegularExpressions;

namespace Challenges.Kyu4.BreadcrumbGenerator;

public class Kata
{
    private static Regex re = new Regex(@"(?>(?>(?>https?:\/\/)?www\.)?[^\/]+)([^\?#\.]+)");
    private static readonly string[] Ignore = ["the", "of", "in", "from", "by", "with", "and", "or", "for", "to", "at", "a"];
    
    public static string GenerateBC(string url, string separator)
    {
        var siteParts = re.Match(url).Groups[1].Value.Split('/').ToList();
        if(siteParts[^1] == "index" || siteParts[^1] == string.Empty) siteParts.RemoveAt(siteParts.Count - 1);
        
        
        StringBuilder builder = new StringBuilder();
        builder.AppendJoin(separator, GetCrumbs());

        return builder.ToString();

        IEnumerable<string> GetCrumbs()
        {
            const string spanform = "<span class=\"active\">{0}</span>";
            const string linkform = "<a href=\"{0}\">{1}</a>";
            
            for (var i = 0; i < siteParts.Count; i++)
            {
                string link = (i == 0)? @"/" : $"/{siteParts[i]}/";
                string text = (i == 0)? "HOME" : Shorten(siteParts[i]);

                if (i == siteParts.Count - 1)
                {
                    yield return string.Format(spanform, text);
                }
                else
                {
                    yield return string.Format(linkform, link, text);
                }
            }
        }
    }
    
    private static string Shorten(string item)
    {
        if (item.Length <= 30)
        {
            item = item.Replace('-', ' ');
        }
        else
        {
            var words = item.Split('-');
            item = new string(words.Except(Ignore).Select(s => s[0]).ToArray());
        }

        return item.ToUpper();
    }
}