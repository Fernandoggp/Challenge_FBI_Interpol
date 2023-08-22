using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("WANTED")]
public class WantedModel
{

    [Display(Name = "Nome da pessoa")]
    [Required(ErrorMessage = "Nome da pessoa é obrigatório!")]
    [MaxLength(70, ErrorMessage = "O tamanho máximo para o campo nome é de 70 caracteres.")]
    [MinLength(2, ErrorMessage = "Digite um nome com 2 ou mais caracteres")]
    [Column("nome")]
    public string? Nome { get; set; }

    [HiddenInput]
    [Key]
    [Column("ID")]
    public string? WantedId { get; set; }

    [Display(Name = "Nacionalidade")]
    [Column("nacionalidade")]
    public string? Nacionality { get; set; }


    [Display(Name = "Causa")]
    [Column("causa")]
    public string? Restriction { get; set; }

    public WantedModel(string? nome, string? nacionality, string? restriction)
    {
        Nome = nome;
        Nacionality = nacionality;
        Restriction = restriction;
    }
}

