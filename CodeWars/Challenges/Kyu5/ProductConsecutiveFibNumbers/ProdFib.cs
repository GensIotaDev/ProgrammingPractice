namespace Challenges.Kyu5.ProductConsecutiveFibNumbers;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5541f58a944b85ce6d00006a">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5543abb64e405654510001d6/groups/647e7147c675ce0001096383">here</see>
/// </summary>
public class ProdFib 
{
    private class ProductRecord
    {
        public ulong? Product { get; set; }
        public ulong FibNumber { get; set; }

        public ProductRecord(ulong? product, ulong fibNumber)
        {
            Product = product;
            FibNumber = fibNumber;
        }
    }
    
    private static List<ProductRecord> CachedProducts = new()
    {
        new ProductRecord(0, 0),
        new ProductRecord(1, 1),
        new ProductRecord(null, 1)
    };
  
    public static ulong[] productFib(ulong prod) 
    {
        //build out missing fibonacci values
        GenerateMissingCache(prod);
      
        //find closest product record
        var foundExact = BinarySearch(prod, out var closestIndex); 
        
        Console.WriteLine($"BinarySearch Index: {closestIndex}");
      
        return new[]
        {
            CachedProducts[closestIndex].FibNumber,
            CachedProducts[closestIndex+1].FibNumber,
            (foundExact) ? 1u : 0u
        };
    }
  
    private static void GenerateMissingCache(ulong target)
    {
        var last = CachedProducts[^2];
        var incomplete = CachedProducts[^1];

        while (last.Product < target)
        {
            var next = new ProductRecord(null, last.FibNumber + incomplete.FibNumber);
            incomplete.Product = incomplete.FibNumber * next.FibNumber;

            CachedProducts.Add(next);
            last = incomplete;
            incomplete = next;
        }
    }
    private static bool BinarySearch(ulong value, out int closestIndex)
    {
        int left = 0, 
            mid = 0, 
            right = CachedProducts.Count - 2;

        while (left <= right)
        {
            mid = (left + right) / 2;
            var temp = CachedProducts[mid].Product;

            if (temp == value)
            {
                closestIndex = mid;
                return true;
            }
            else if (temp < value)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        //bias towards upper index
        closestIndex = (left > right)? left : right;
        return false;
    }
}