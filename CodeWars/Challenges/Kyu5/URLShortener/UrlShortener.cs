namespace Challenges.Kyu5.URLShortener;

using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5fee4559135609002c1a1841">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/6309fdbfa2f0b00001342ef4/groups/6334ad22b0221700016b6977">here</see>
/// </summary>
class UrlShortener {
    private const string BaseURL = "short.ly/";
    
    //bidirectional dictionary without custom class
    private Dictionary<string, string> urlIdMap = new();
    private Dictionary<string, string> idUrlMap = new();

    private char[] AlphaKey = new char[4] { '\0', '\0', '\0', '\0'}; //use stringbuilder if max length is undefined
    private void IncrementAlphaKey(int idx = 0)
    {
        if (idx == AlphaKey.Length) return;

        switch (AlphaKey[idx])
        {
            case 'z':
                IncrementAlphaKey(idx + 1);
                AlphaKey[idx] = 'a';
                break;
            case '\0':
                AlphaKey[idx] = 'a';
                break;
            default:
                AlphaKey[idx]++;
                break;
        }
    }
    
    public string Shorten(string longURL)
    {
        if (longURL.StartsWith(BaseURL))
            throw new ArgumentException("Invalid url. Can't shorten an already short url.");

        string shortUrl;
        if (urlIdMap.TryGetValue(longURL, out var key))
        {
            shortUrl = key;
        }
        else
        {
            IncrementAlphaKey();
            
            var nKey = new string(AlphaKey);
            nKey = nKey.TrimEnd('\0'); //null characters persist on string conversion

            shortUrl = nKey;
            urlIdMap.Add(longURL, nKey);
            idUrlMap.Add(nKey, longURL);
        }

        return $"{BaseURL}{shortUrl}";
    }

    public string Redirect(string shortURL)
    {
        if (!shortURL.StartsWith(BaseURL)) throw new ArgumentException("Invalid url. Base address wrong.");

        var key = shortURL[BaseURL.Length ..];

        if (idUrlMap.TryGetValue(key, out var url))
        {
            return url;
        }
        
        throw new ArgumentException("Invalid url. Url Does not exist.");
    }
}