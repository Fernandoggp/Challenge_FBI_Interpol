using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("INTERPOL")]
public class InterpolModel
{
    public InterpolModel()
    {
    }

    [Display(Name = "Nome da pessoa")]
    [Required(ErrorMessage = "Nome da pessoa é obrigatório!")]
    [MaxLength(70, ErrorMessage = "O tamanho máximo para o campo nome é de 70 caracteres.")]
    [MinLength(2, ErrorMessage = "Digite um nome com 2 ou mais caracteres")]
    [Column("nome")]
    public string? Nome { get; set; }

    [HiddenInput]
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Display(Name = "Nacionalidade")]
    [Column("nacionalidade")]
    public string? Nacionality { get; set; }

    public InterpolModel(string? nome, string? id, string? nacionality)
    {
        Nome = nome;
        Id = id;
        Nacionality = nacionality;
    }
}

