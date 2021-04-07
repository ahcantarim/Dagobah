using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dagobah.Padawan.Presentation.AspNetCore.WebApplication.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Preencha o e-mail.")]
        [MaxLength(150, ErrorMessage = "Comprimento máximo de {0} caracteres.")]
        [MinLength(5, ErrorMessage = "Comprimento mínimo de {0} caracteres.")]
        [EmailAddress(ErrorMessage = "Preencha com um e-mail válido.")]
        [DisplayName("E-mail")]
        public string Email { get; private set; }

        [ScaffoldColumn(false)]
        public string Senha { get; private set; }

        [ScaffoldColumn(false)]
        public bool Confirmado { get; private set; }

        [ScaffoldColumn(false)]
        public DateTime? UltimoAcessoEm { get; private set; }
    }
}
