using Xunit;

namespace ProteinTranslation;

public class ProteinTranslationTests
{
    [Fact]
    public void Empty_rna_sequence_results_in_no_proteins()
    {
        Assert.Empty(ProteinTranslation.Proteins(""));
    }

    [Fact]
    public void Methionine_rna_sequence()
    {
        string[] expected = ["Methionine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("AUG"));
    }

    [Fact]
    public void Phenylalanine_rna_sequence_1()
    {
        string[] expected = ["Phenylalanine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUU"));
    }

    [Fact]
    public void Phenylalanine_rna_sequence_2()
    {
        string[] expected = ["Phenylalanine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUC"));
    }

    [Fact]
    public void Leucine_rna_sequence_1()
    {
        string[] expected = ["Leucine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUA"));
    }

    [Fact]
    public void Leucine_rna_sequence_2()
    {
        string[] expected = ["Leucine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUG"));
    }

    [Fact]
    public void Serine_rna_sequence_1()
    {
        string[] expected = ["Serine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UCU"));
    }

    [Fact]
    public void Serine_rna_sequence_2()
    {
        string[] expected = ["Serine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UCC"));
    }

    [Fact]
    public void Serine_rna_sequence_3()
    {
        string[] expected = ["Serine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UCA"));
    }

    [Fact]
    public void Serine_rna_sequence_4()
    {
        string[] expected = ["Serine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UCG"));
    }

    [Fact]
    public void Tyrosine_rna_sequence_1()
    {
        string[] expected = ["Tyrosine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UAU"));
    }

    [Fact]
    public void Tyrosine_rna_sequence_2()
    {
        string[] expected = ["Tyrosine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UAC"));
    }

    [Fact]
    public void Cysteine_rna_sequence_1()
    {
        string[] expected = ["Cysteine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGU"));
    }

    [Fact]
    public void Cysteine_rna_sequence_2()
    {
        string[] expected = ["Cysteine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGC"));
    }

    [Fact]
    public void Tryptophan_rna_sequence()
    {
        string[] expected = ["Tryptophan"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGG"));
    }

    [Fact]
    public void Stop_codon_rna_sequence_1()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAA"));
    }

    [Fact]
    public void Stop_codon_rna_sequence_2()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAG"));
    }

    [Fact]
    public void Stop_codon_rna_sequence_3()
    {
        Assert.Empty(ProteinTranslation.Proteins("UGA"));
    }

    [Fact]
    public void Sequence_of_two_protein_codons_translates_into_proteins()
    {
        string[] expected = ["Phenylalanine", "Phenylalanine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUUUUU"));
    }

    [Fact]
    public void Sequence_of_two_different_protein_codons_translates_into_proteins()
    {
        string[] expected = ["Leucine", "Leucine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUAUUG"));
    }

    [Fact]
    public void Translate_rna_strand_into_correct_protein_list()
    {
        string[] expected = ["Methionine", "Phenylalanine", "Tryptophan"];
        Assert.Equal(expected, ProteinTranslation.Proteins("AUGUUUUGG"));
    }

    [Fact]
    public void Translation_stops_if_stop_codon_at_beginning_of_sequence()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAGUGG"));
    }

    [Fact]
    public void Translation_stops_if_stop_codon_at_end_of_two_codon_sequence()
    {
        string[] expected = ["Tryptophan"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGGUAG"));
    }

    [Fact]
    public void Translation_stops_if_stop_codon_at_end_of_three_codon_sequence()
    {
        string[] expected = ["Methionine", "Phenylalanine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("AUGUUUUAA"));
    }

    [Fact]
    public void Translation_stops_if_stop_codon_in_middle_of_three_codon_sequence()
    {
        string[] expected = ["Tryptophan"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGGUAGUGG"));
    }

    [Fact]
    public void Translation_stops_if_stop_codon_in_middle_of_six_codon_sequence()
    {
        string[] expected = ["Tryptophan", "Cysteine", "Tyrosine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGGUGUUAUUAAUGGUUU"));
    }

    [Fact]
    public void Sequence_of_two_non_stop_codons_does_not_translate_to_a_stop_codon()
    {
        string[] expected = ["Methionine", "Methionine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("AUGAUG"));
    }
}