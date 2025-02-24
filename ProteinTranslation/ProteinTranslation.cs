namespace ProteinTranslation;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> Dictionary = new()
    {
        { "AUG", "Methionine" },
        { "UUU", "Phenylalanine" },
        { "UUC", "Phenylalanine" },
        { "UUA", "Leucine" },
        { "UUG", "Leucine" },
        { "UCU", "Serine" },
        { "UCC", "Serine" },
        { "UCA", "Serine" },
        { "UCG", "Serine" },
        { "UAU", "Tyrosine" },
        { "UAC", "Tyrosine" },
        { "UGU", "Cysteine" },
        { "UGC", "Cysteine" },
        { "UGG", "Tryptophan" },
        { "UAA", "STOP" },
        { "UAG", "STOP" },
        { "UGA", "STOP" }
    };
    
    public static string[] Proteins(string strand)
    {
        List<string> proteins = [];
        
        for (var i = 0; i < strand.Length; i += 3)
        {
            var str = strand[i..(i + 3)];
            
            var protein = Dictionary[str];
            if (protein == "STOP") break;

            proteins.Add(protein);
        }

        return proteins.ToArray();
    }
}